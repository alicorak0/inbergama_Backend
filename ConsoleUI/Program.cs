using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Microsoft.IdentityModel.Tokens;
using System.Text.RegularExpressions;


//InMemoryProductDal mp = new InMemoryProductDal();

// static void CategoryTest()
//{
//    CategoryManager categoryManager = new CategoryManager(new EfCategoryDal()); // Memory akış biçimini seçtim aslında

//    foreach (var category in categoryManager.GetAll().Data) // ben business katmanıyla ilgilenirim GetAll'i Dal'dan çağrıacak Kategori Servisi
//    {
//        Console.WriteLine(category.CategoryName);
//   }
//}

Console.WriteLine(GenerateSlug("Coffe Componny Bergama"));

  string GenerateSlug(string phrase)
{
    if (string.IsNullOrWhiteSpace(phrase))
        return "";

    // Küçük harfe çevir
    string str = phrase.ToLowerInvariant();

    // Türkçe karakterleri normal harfe çevir
    str = str.Replace("ç", "c")
             .Replace("ğ", "g")
             .Replace("ı", "i")
             .Replace("ö", "o")
             .Replace("ş", "s")
             .Replace("ü", "u");

    // Özel karakterleri kaldır
    str = Regex.Replace(str, @"[^a-z0-9\s-]", "");

    // Boşlukları ve tireleri normalize et
    str = Regex.Replace(str, @"\s+", "-").Trim('-');

    // Ardışık tireleri tek tireye indir
    str = Regex.Replace(str, @"-+", "-");

    return str;
}






//void ProducTest2()
//{
//    ProductManager productManager = new ProductManager(new EfProductDal(), new EfCategoryDal()); // Memory akış biçimini seçtim aslında

//    var result = productManager.GetProductDetails();

//    if (result.Success == true)
//    {
//        foreach (var product in result.Data)
//        {
//            Console.WriteLine(product.ProductName + "/"+product.CategoryName);      
//        }
//    }
//    else
//    {
//        Console.WriteLine(result.Message);  
//    }

//}


