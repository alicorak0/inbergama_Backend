using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
   public class Service : IEntity
    {
        [Key]
        public int Id { get; set; }

        [StringLength(60)]
        public string? Name { get; set; }

        [StringLength(21)]
        public string? Phone { get; set; }

        [StringLength(70)]
        public string? Image { get; set; }

    }
}
