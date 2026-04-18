using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
   public class BusinessDetailDto
    {
        // İşletme temel bilgiler
        public int Id { get; set; }

        public string Name { get; set; }
        public string Slug { get; set; }
        public string? FullDesc { get; set; }
        public string? CoverImage { get; set; }
        public string? Phone { get; set; }
        public string? Adress { get; set; }
        public string? MapUrl { get; set; }

        public decimal? Rating { get; set; }
        public int CommentCount { get; set; }


        //navigation
        public ICollection<BusinessPhoto> Photos { get; set; }
        public ICollection<CampaignCardDto> Campaigns { get; set; }
    }
}
