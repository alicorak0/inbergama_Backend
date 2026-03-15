using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
  public  class Vacation:IEntity
    {
        [Key]
        public int VacationId { get; set; }

        [Required]
        [StringLength(80)]
        public string VacationName { get; set; }

        [StringLength(80)]
        public string? Image { get; set; }

        public string? FullDescp { get; set; }

        [StringLength(650)]
        public string? LocationUrl { get; set; }

        [Required]
        [StringLength(50)]
        public string Slug { get; set; }


        //navigation
        public ICollection<VacationPhoto> Photos { get; set; }
    }
}
