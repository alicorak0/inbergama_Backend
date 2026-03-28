using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
   public class EventDetailDto
    {
        public int Id { get; set; }

        public string EventName { get; set; }

        public string? LocationUrl { get; set; }
        public DateTime Date { get; set; }

        public string? FullDescp { get; set; }

        public string? Image { get; set; }

        [StringLength(50)]
        public string? ContactPhone { get; set; }
    }
}
