using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class InfluencerCardDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public string Url { get; set; }
        public string? CoverImage { get; set; }
    }
}
