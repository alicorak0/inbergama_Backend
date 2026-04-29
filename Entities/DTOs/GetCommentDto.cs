using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
  public  class GetCommentDto
    {
        public string ContentText { get; set; }
        public decimal Rating { get; set; }
        public DateTime CreatedTime { get; set; }
        public string FirstName { get; set; }

        public int userId { get; set; } 
        public string LastName { get; set; }
        public string ProfilePhoto { get; set; }
    }
}
