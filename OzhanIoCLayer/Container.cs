using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OzhanCoreLayer.Services.AccountServices;
using OzhanCoreLayer.Services.AdminAccounts;
using OzhanCoreLayer.Services.BaseProducts;
using OzhanCoreLayer.Services.PermissionServices;
using OzhanCoreLayer.Services.Products;
using OzhanCoreLayer.Services.UserPanelServices;
using OzhanCoreLayer.Utilities.Security;
using OzhanCoreLayer.Utilities.ViewToString;
using OzhanDataLayer.Context;

namespace OzhanIoCLayer
{
    public static class Container
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<OzhanContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("OzhanFinalAttempConnection1"));
            });

            #region IoC

            services.AddSingleton<ISecurityService, SecurityService>();
            services.AddTransient<IAccountServices, AccountServices>();
            services.AddTransient<IUserPanelServices, UserPanelServices>();
            services.AddTransient<IPermissionServices, PermissionServices>();
            services.AddTransient<IProductServices, ProductServices>();
            services.AddTransient<IBaseProductServices, BaseProductServices>();
            services.AddTransient<IAdminAccountService, AdminAccount>();
            services.AddTransient<IViewRenderService, RenderViewToString>();

            #endregion
            return services;
        }

    }
}
