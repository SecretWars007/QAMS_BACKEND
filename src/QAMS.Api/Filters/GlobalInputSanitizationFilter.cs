// src/QAMS.Api/Filters/GlobalInputSanitizationFilter.cs
using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections;
using System.Reflection;
using System.Text.RegularExpressions;

namespace QAMS.Api.Filters
{
    /// <summary>
    /// Filtro global que intercepta todas las peticiones a los controladores.
    /// Bloquea caracteres peligrosos (como comilla simple, acento grave, menor que, mayor que, igual, llave y barra invertida) para prevenir XSS e inyecciones.
    /// También aplica validaciones estructurales a fechas (rango razonable) y numéricos (no negativos si son Ids).
    /// </summary>
    public partial class GlobalInputSanitizationFilter : IActionFilter
    {
        // Regex para detectar caracteres peligrosos: comilla simple, backtick, angle brackets, equals, y backslash.
        [GeneratedRegex(@"['`<>=¡\\]", RegexOptions.Compiled)]
        private static partial Regex UnsafeRegex();

        public void OnActionExecuting(ActionExecutingContext context)
        {
            foreach (var arg in context.ActionArguments.Values)
            {
                if (arg != null && ContainsInvalidData(arg, out string errorMessage))
                {
                    context.Result = new BadRequestObjectResult(new 
                    { 
                        Message = errorMessage,
                        ErrorCode = "INVALID_INPUT_DATA"
                    });
                    return;
                }
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // No action needed after execution
        }

        private static bool ContainsInvalidData(object obj, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (obj is string str)
            {
                if (UnsafeRegex().IsMatch(str))
                {
                    errorMessage = "Los datos de entrada contienen caracteres prohibidos por seguridad (' ` < > = \\).";
                    return true;
                }
                return false;
            }

            var type = obj.GetType();
            
            // Ignorar tipos primitivos base a menos que queramos validarlos explícitamente
            if (type.Namespace?.StartsWith("System") == true && !type.Name.Contains("Date") && !type.IsPrimitive) 
                return false;

            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                                 .Where(p => p.CanRead);

            foreach (var prop in properties)
            {
                // Omitir campos que legítimamente necesitan caracteres especiales
                if (prop.Name.Contains("Password", StringComparison.OrdinalIgnoreCase) || 
                    prop.Name.Contains("Token", StringComparison.OrdinalIgnoreCase)) 
                    continue;

                var val = prop.GetValue(obj);
                if (val == null) continue;

                // Validación de cadenas de texto
                if (val is string s)
                {
                    if (UnsafeRegex().IsMatch(s)) 
                    {
                        errorMessage = $"El campo {prop.Name} contiene caracteres prohibidos por seguridad (' ` < > = \\).";
                        return true;
                    }
                }
                // Validación de listas de cadenas u objetos (1 nivel de profundidad)
                else if (val is IEnumerable list && val is not string)
                {
                    foreach (var item in list)
                    {
                        if (item is string ls && UnsafeRegex().IsMatch(ls)) 
                        {
                            errorMessage = $"Un elemento de la lista {prop.Name} contiene caracteres prohibidos (' ` < > = \\).";
                            return true;
                        }
                    }
                }
                // Validación de fechas lógicas
                else if (val is DateTime dt)
                {
                    if (dt.Year < 1900 || dt.Year > 2100)
                    {
                        errorMessage = $"La fecha en {prop.Name} no se encuentra dentro del rango válido (1900-2100).";
                        return true;
                    }
                }
                else if (val is DateOnly dto)
                {
                    if (dto.Year < 1900 || dto.Year > 2100)
                    {
                        errorMessage = $"La fecha en {prop.Name} no se encuentra dentro del rango válido (1900-2100).";
                        return true;
                    }
                }
                // Validación básica para números
                else if (IsNumericType(prop.PropertyType) && (prop.Name.EndsWith("Id") || prop.Name.EndsWith("Order") || prop.Name.Contains("Count") || prop.Name.Contains("Size")))
                {
                    if (Convert.ToDouble(val) < 0)
                    {
                        errorMessage = $"El campo numérico {prop.Name} no puede tener valores negativos.";
                        return true;
                    }
                }
            }

            return false;
        }

        private static bool IsNumericType(Type type)
        {
            return Type.GetTypeCode(Nullable.GetUnderlyingType(type) ?? type) switch
            {
                TypeCode.Byte or TypeCode.SByte or TypeCode.UInt16 or TypeCode.UInt32 or 
                TypeCode.UInt64 or TypeCode.Int16 or TypeCode.Int32 or TypeCode.Int64 or 
                TypeCode.Decimal or TypeCode.Double or TypeCode.Single => true,
                _ => false,
            };
        }
    }
}
