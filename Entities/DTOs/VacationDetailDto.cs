using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
  public  class VacationDetailDto
    {
        // Tatil temel bilgiler
        public string VacationName { get; set; }
        public string Slug { get; set; }
        public string? Image { get; set; }
        public string? FullDescp { get; set; }
        public string? LocationUrl { get; set; }

        // navigation
        public ICollection<VacationPhoto> Photos { get; set; }
    }
}
