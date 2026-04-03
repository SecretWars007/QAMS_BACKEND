// src/QAMS.Domain/Common/IAuditable.cs
using System;

namespace QAMS.Domain.Common
{
    public interface IAuditable
    {
        DateTime CreatedAt { get; set; }
        Guid? CreatedByUserId { get; set; }
        DateTime? UpdatedAt { get; set; }
        Guid? UpdatedByUserId { get; set; }
    }
}
