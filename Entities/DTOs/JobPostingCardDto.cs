using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
  public  class JobPostingCardDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? CoverImage { get; set; }
        public string? ShortDesc { get; set; }
        public string Slug { get; set; }
    }
}
