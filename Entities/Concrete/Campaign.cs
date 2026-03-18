using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
   public class Campaign : IEntity
    {
        [Key]
        public int CampaignId { get; set; }

        [Required]
        [StringLength(80)]
        public string CampaignName { get; set; }

        [StringLength(80)]
        public string? ShortDesc { get; set; }

        public string? FullDesc { get; set; }

        [Required]
        public DateTime DateExpire { get; set; }

        [StringLength(70)]
        public string? Image { get; set; }

        [StringLength(650)]
        public string? LocationUrl { get; set; }

        // Navigation property (Business nesnesi) kaldırıldı.
        // Sadece ham Foreign Key alanı kaldı.
        public int BusinessId { get; set; }

        [Required]
        [StringLength(50)]
        public string Slug { get; set; }


        // Navigation property       Business bilgilerine erişmek için
        public Business Business { get; set; }
    }
}
