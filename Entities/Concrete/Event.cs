using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Event : IEntity
    {
        [Key]
        public int EventId { get; set; }

        [Required]
        [StringLength(80)]
        public string EventName { get; set; }

        [StringLength(650)]
        public string? LocationUrl { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public string? FullDescp { get; set; }

        [StringLength(90)]
        public string? Image { get; set; }

        [StringLength(50)]
        public string? ContactPhone { get; set; }

        [Required]
        [StringLength(50)]
        public string Slug { get; set; }

    }
}
