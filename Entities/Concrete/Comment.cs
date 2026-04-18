using Core.Entities;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        public decimal Rating { get; set; }

        public DateTime CreatedTime { get; set; }


        // Navigation property
        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
