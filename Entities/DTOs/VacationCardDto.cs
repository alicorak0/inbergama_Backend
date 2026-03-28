using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
  public  class VacationCardDto
    {
        public int Id { get; set; }

        public string VacationName { get; set; }

        public string Slug { get; set; }
        public string? Image { get; set; }

    }
}
