using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
  public  class AddCommentDto
    {

        public string BusinessSlug { get; set; }  // Mekan slug
        public string ContentText { get; set; }   // Yorum metni
        public double Rating { get; set; }         // Puan

    }
}
