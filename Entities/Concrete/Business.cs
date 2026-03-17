using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
  public class Business:IEntity
    {

        [Key]
        public int BusinessId { get; set; }
        public int CategoryId { get; set; }

        [Required]
        [StringLength(50)]
        public string BusinessName { get; set; }


        [StringLength(100)]
        public string? ShortDesc { get; set; }

        public string? FullDesc { get; set; }

        [StringLength(90)]
        public string? CoverImage { get; set; }


        [StringLength(30)]
        public string? Phone { get; set; }

        [StringLength(120)]
        public string? Adress { get; set; }


        [StringLength(600)]
        public string? MapUrl { get; set; }

        public double? Rating { get; set; } = 0;

        public int? ViewsCount { get; set; } = 0;

        [Required]
        [StringLength(50)]
        public string Slug { get; set; }

        
    }
}
