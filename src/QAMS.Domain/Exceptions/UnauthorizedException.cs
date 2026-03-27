// src/QAMS.Domain/Exceptions/UnauthorizedException.cs
using System;

namespace QAMS.Domain.Exceptions
{
    public class UnauthorizedException(string message) : System.Exception(message)
    {
    }
}
