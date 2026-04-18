using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
  public  class CategoryWithCardsDto
    {
        public BusinessCategory Category { get; set; }
        public List<BusinessCardDto> Cards { get; set; }
    }
}
