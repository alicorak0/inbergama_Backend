using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
  public  class BusinessPhoto : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int BusinessId {  get; set; }    

        public string? Image {  get; set; }


        //Navigation
        public Business Business { get; set; }  // Navigation

    }
}
