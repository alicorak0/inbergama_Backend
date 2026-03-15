using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete
{
   public class User : IEntity
    {
        [Key]
        public int UserId { get; set; }

        [StringLength(50)]
        public string? FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        public byte[]? PasswordHash { get; set; }

        public byte[]? PasswordSalt { get; set; }

        [StringLength(90)]
        public string? ProfilePhoto { get; set; }

        public bool IsEmailVerified { get; set; }

        [StringLength(7)]
        public string? EmailVerificationCode { get; set; }

        public DateTime? EmailCodeExpire { get; set; }

        public bool UserStatus { get; set; }


    }


}
