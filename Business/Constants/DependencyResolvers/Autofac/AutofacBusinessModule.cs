using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Concrete.EntityFramework;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using Core.Utilities.İnterceptors;
using Business.CCS;
using Core.Utilities.Security.JWT;
using Microsoft.AspNetCore.Http;


namespace Business.Constants.DependencyResolvers.Autofac
{
   public class AutofacBusinessModule:Module
    {

        protected override void Load(ContainerBuilder builder)
        {     //IProductService isterse ProductManager verilir
                                                                                     // builder.RegisterType<FileLogger>().As<ILogger>().SingleInstance(); // kim isterse aynı objeyi referansı verir
                                                                                     //Logeri kaydetme  birisi ILogger isterse arka planda oluştur FileLoger
             //for categories


            //authorization and login/sign in
            //builder.RegisterType<UserManager>().As<IUserService>().SingleInstance(); // kim isterse aynı objeyi referansı verir
            //builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance(); // kim isterse aynı objeyi referansı verir

            //builder.RegisterType<AuthManager>().As<IAuthService>().SingleInstance(); // kim isterse aynı objeyi referansı verir
            builder.RegisterType<JwtHelper>().As<ITokenHelper>().SingleInstance(); // kim isterse aynı objeyi referansı verir

            //   builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>().SingleInstance(); // kim isterse aynı objeyi referansı verir







            //validation kısmını etkinleltir startup aşamasında
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();

        }
    }
}
