using System.Linq;
using GraphQL.Server;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Training.OrdersModule.Core;
using Training.OrdersModule.Core.Models;
using Training.OrdersModule.Data.Models;
using Training.OrdersModule.Data.Repositories;
using Training.OrdersModule.Data.Services;
using Training.OrdersModule.Xapi.Extensions;
using VirtoCommerce.OrdersModule.Core.Model;
using VirtoCommerce.OrdersModule.Core.Model.Search;
using VirtoCommerce.OrdersModule.Core.Services;
using VirtoCommerce.OrdersModule.Data.Model;
using VirtoCommerce.OrdersModule.Data.Repositories;
using VirtoCommerce.Platform.Core.Common;
using VirtoCommerce.Platform.Core.Modularity;
using VirtoCommerce.Platform.Core.Security;
using VirtoCommerce.Platform.Core.Settings;

namespace Training.OrdersModule.Web
{
    public class Module : IModule, IHasConfiguration
    {
        public ManifestModuleInfo ModuleInfo { get; set; }
        public IConfiguration Configuration { get; set; }

        public void Initialize(IServiceCollection serviceCollection)
        {
            AbstractTypeFactory<CustomerOrder>.OverrideType<CustomerOrder, TrainingOrder>();
            AbstractTypeFactory<CustomerOrderEntity>.OverrideType<CustomerOrderEntity, TrainingOrderEntity>();
            AbstractTypeFactory<CustomerOrderSearchCriteria>.OverrideType<CustomerOrderSearchCriteria, TrainingOrderSearchCriteria>();

            serviceCollection.AddDbContext<TrainingOrderDbContext>((provider, options) =>
            {
                var configuration = provider.GetService<IConfiguration>();
                var connectionString = configuration.GetConnectionString("VirtoCommerce.Orders") ?? configuration.GetConnectionString("VirtoCommerce");

                options.UseSqlServer(connectionString);
            });

            serviceCollection.AddTransient<IOrderRepository, TrainingOrderRepository>();

            serviceCollection.AddTransient<ICustomerOrderSearchService, TrainingOrderSearchService>();

            var graphQlBuilder = serviceCollection.AddGraphQL(options =>
                {
                    options.EnableMetrics = false;
                })
                .AddNewtonsoftJson(deserializerSettings => { }, serializerSettings => { })
                .AddErrorInfoProvider(options =>
                {
                    options.ExposeExtensions = true;
                    options.ExposeExceptionStackTrace = true;
                });

            serviceCollection.AddXTrainingOrder(graphQlBuilder);
        }

        public void PostInitialize(IApplicationBuilder appBuilder)
        {
            using (var serviceScope = appBuilder.ApplicationServices.CreateScope())
            using (var dbContext = serviceScope.ServiceProvider.GetRequiredService<TrainingOrderDbContext>())
            {
                dbContext.Database.EnsureCreated();
                dbContext.Database.Migrate();
            }

            // Register settings
            var settingsRegistrar = appBuilder.ApplicationServices.GetRequiredService<ISettingsRegistrar>();
            settingsRegistrar.RegisterSettings(ModuleConstants.Settings.AllSettings, ModuleInfo.Id);

            // Register permissions
            var permissionsRegistrar = appBuilder.ApplicationServices.GetRequiredService<IPermissionsRegistrar>();
            permissionsRegistrar.RegisterPermissions(ModuleConstants.Security.Permissions.AllPermissions
                .Select(x => new Permission { ModuleId = ModuleInfo.Id, GroupName = "TrainingOrdersModule", Name = x })
                .ToArray());
        }

        public void Uninstall()
        {
        }
    }
}
