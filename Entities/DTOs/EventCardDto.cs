using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
   public class EventCardDto
    {
        public string EventName { get; set; }

        public DateTime Date { get; set; }

        public string? Image { get; set; }

        public string Slug { get; set; }

    }
}
