// src/QAMS.Domain/Common/ISoftDelete.cs
using System;

namespace QAMS.Domain.Common
{
    public interface ISoftDelete
    {
        bool IsDeleted { get; set; }
        DateTime? DeletedAt { get; set; }
        Guid? DeletedByUserId { get; set; }
    }
}
