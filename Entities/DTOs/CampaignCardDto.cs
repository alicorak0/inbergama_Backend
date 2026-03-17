using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
   public class CampaignCardDto
    {
        public string CampaignName { get; set; }   // her zaman var
        public string Slug { get; set; }           // her zaman var
        public string? Image { get; set; }         // opsiyonel
        public string? ShortDesc { get; set; }     // opsiyonel
        public DateTime DateExpire { get; set; }   // kampanya bitiş tarihi

    }
}
