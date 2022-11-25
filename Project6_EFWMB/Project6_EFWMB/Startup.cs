using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Project6_EFWMB.Application.BillDetailServices;
using Project6_EFWMB.Application.CustomerServices;
using Project6_EFWMB.Application.MenuServices;
using Project6_EFWMB.Application.TableServices;
using Project6_EFWMB.Application.TransactionServices;
using Project6_EFWMB.ConfigProfile;
using Project6_EFWMB.Database;
using Project6_EFWMB.Views.BillViews;
using Project6_EFWMB.Views.MenuViews;
using Project6_EFWMB.Views.ReportViews;
using Project6_EFWMB.Views.TableViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project6_EFWMB
{
    public class Startup
    {
        IConfigurationRoot Configuration { get; }
        public IServiceProvider Provider { get; }

        public Startup()
        {
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false);
            Configuration = builder.Build();
            Provider = ConfigureServices();
        }

        private IServiceProvider? ConfigureServices()
        {
            var services = new ServiceCollection();

            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ConfigurationProfile());
            });

            var mapper = config.CreateMapper();

            services.AddLogging();
            services.AddSingleton<IConfigurationRoot>(Configuration);

            services.AddSingleton(mapper);
            services.AddSingleton<IMenuAppService, MenuAppService>();
            services.AddSingleton<ITableAppService, TableAppService>();
            services.AddSingleton<IBillAppService, BillAppService>();
            services.AddSingleton<ICustomerAppService, CustomerAppService>();
            services.AddSingleton<IBillDetailAppService, BillDetailAppService>();

            services.AddDbContext<WarungContext>(options =>
            {
                options.UseNpgsql(Configuration.GetConnectionString("DBConnection"), builder =>
                                    builder.MigrationsAssembly("migration.presentence"));
            }, ServiceLifetime.Singleton);

            services.AddSingleton<GetAllMenuView>();

            services.AddSingleton<TableView>();
            services.AddSingleton<GetAllTableView>();
            services.AddSingleton<UpdateTableView>();


            services.AddSingleton<BillView>();
            services.AddSingleton<GetAllBillView>();
            services.AddSingleton<CreateBillView>();
            services.AddSingleton<CreateCustomerView>();

            services.AddSingleton<ReportView>();


            return services.BuildServiceProvider();
            
        }
    }
}
