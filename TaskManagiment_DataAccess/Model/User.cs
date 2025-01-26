﻿using System.ComponentModel.DataAnnotations;
using TaskManagiment_Core.Common;

namespace TaskManagiment_DataAccess.Model
{
    public class User: BaseEntity, IAuditedEntity
    {
        [Required(ErrorMessage = "Foydalanuvchi nomini kiritish shart.")]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "Ism uzunligi kamida 2 va maksimal 15 ta belgidan iborat bo'lishi kerak.")]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Ism faqat harflar va bo'sh joylardan iborat bo'lishi kerak.")]
        public string FullName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Email manzilini kiritish shart.")]
        [EmailAddress(ErrorMessage = "Email manzil noto'g'ri formatda.")]
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;  
        public string Role { get; set; } = string.Empty;    
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
