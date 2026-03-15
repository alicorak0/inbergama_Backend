using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
  public  class Comment : IEntity
    {

        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }

        public int BusinessId { get; set; }

        [Required]
        [StringLength(100)]
        public string ContentText { get; set; }

        public float Rating { get; set; }

        public DateTime CreatedTime { get; set; }
    }
}
