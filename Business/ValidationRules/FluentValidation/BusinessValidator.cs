using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    // Prodct girilen bilghieri  doğrulayacak sınıf
   public class BusinessValidator:AbstractValidator<Entities.Concrete.Business>
    {
        public BusinessValidator() 
        {
            RuleFor(b => b.BusinessName).MinimumLength(2).WithMessage("Ürün ismi iki karakterden uzun olmalı");
            RuleFor(b => b.BusinessName).NotEmpty().WithMessage("Ürün İsmi Boş olamaz");

            //Koşullu Valdiate  örneğin Category'e göre Kuralar getirme

            //  RuleFor(P => P.ProductName).Must(P => P[0] == 'A');     
           // RuleFor(p => p.ProductName).Must(StartWithA);
        }

        //private bool StartWithA(string arg)
        //{
        //    return arg.StartsWith("A");
        //}
    }
}
