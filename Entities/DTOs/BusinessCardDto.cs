using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
   public class BusinessCardDto:IDto
    {
        public string Name { get; set; }      // her zaman var
        public string Slug { get; set; }      // her zaman var
        public string Image { get; set; }    // opsiyonel olabilir
        public string ShortDesc { get; set; } // opsiyonel olabilir
        public double? Rating { get; set; }
        public int CommentCount { get; set; } // yorum sayısı
    }
}
