using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
   public class JobPosting : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        public string? Description { get; set; }

        [StringLength(500)]
        public string? CoverImage { get; set; }

        [StringLength(50)]
        public string? ShortDesc { get; set; }

        [StringLength(650)]
        public string? MapUrl { get; set; }

        [StringLength(16)]
        public string? ContactPhone { get; set; }

        [Required]
        [StringLength(50)]
        public string Slug { get; set; }
    }
}
