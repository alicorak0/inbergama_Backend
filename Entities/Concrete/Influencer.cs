using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
   public class Influencer : IEntity
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string? LastName { get; set; }

        [Required]
        [StringLength(100)]
        public string Url { get; set; }

        [StringLength(50)]
        public string? CoverImage { get; set; }
    }
}
