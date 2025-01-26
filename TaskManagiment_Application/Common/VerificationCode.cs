﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TaskManagiment_Core.Common;
using TaskManagiment_DataAccess.Model;

namespace TaskManagiment_Application.Common
{
    public sealed class VerificationCode : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Email { get; set; }
        public string Code { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime ExpiresAt { get; set; }
        public Guid UserId { get; set; }
        public User? User { get; set; }
    }
}
