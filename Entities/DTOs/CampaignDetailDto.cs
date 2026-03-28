using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
   public class CampaignDetailDto
    {
        public int Id { get; set; }

        public string CampaignName { get; set; }
        public string Slug { get; set; }
        public string? Image { get; set; }
        public string? FullDesc { get; set; }
        public DateTime DateExpire { get; set; }

        // Business bilgilerini DTO’ya ekliyoruz
        public string? LocationUrl { get; set; }
        public string? Phone { get; set; }
    }
}
