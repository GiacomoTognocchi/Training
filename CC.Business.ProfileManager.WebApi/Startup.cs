using CC.Core.Common;
using CC.Core.Web.Startup;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System;

namespace CC.Business.ProfileManager.WebApi.CribisComX
{
    /// <summary>
    /// Startup
    /// </summary>
    /// <seealso cref="Core.Web.Startup.CCStartupBase{ConfigurationObject}" />
    public class Startup : CCStartupBase<ConfigurationObject>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup" /> class.
        /// </summary>
        /// <param name="env">The env.</param>
        public Startup(IHostingEnvironment env) : base(env)
        {
            //TODO
            //Get all localized resources and store its in memory
        }

        /// <summary>
        /// Adds the additional dependencies.
        /// </summary>
        /// <param name="services">The services.</param>
        public override void AddAdditionalDependencies(IServiceCollection services)
        {
            //StartupExtensions.AddAccountCommands<ConfigurationObject>(services);
            ////StartupExtensions.AddDomainCommands<ConfigurationObject>(services);
            //base.AddAdditionalDependencies(services);
            //services.AddTransient<IProspectCheckinRepository, ProspectCheckinRepository<ConfigurationObject, ServiceRegistry >> ();
        }

        /// <summary>
        /// Gets the cc service ctor.
        /// </summary>
        /// <returns></returns>
        public override Func<string, ICCService> GetCCServiceCtor()
        {
            return (e) => new CribisComX(e);
        }

        /// <summary>
        /// Configures the inner services.
        /// </summary>
        /// <param name="app">The application.</param>
        protected override void ConfigureInnerServices(IApplicationBuilder app)
        {
            base.ConfigureInnerServices(app);
        }
    }


    /// <summary>
    /// CribisComX
    /// </summary>
    /// <seealso cref="CC.Core.Common.ICCService" />
    public class CribisComX : ICCService
    {
        /// <summary>
        /// Gets the name of the service.
        /// </summary>
        /// <value>
        /// The name of the service.
        /// </value>
        public string ServiceName => "BackendProfileManagerCCXService";

        /// <summary>
        /// Gets the name of the application group.
        /// </summary>
        /// <value>
        /// The name of the application group.
        /// </value>
        public string ApplicationGroupName => "ProfileApplicationGroup";

        /// <summary>
        /// Gets the name of the application.
        /// </summary>
        /// <value>
        /// The name of the application.
        /// </value>
        public string ApplicationName => "CCx";

        /// <summary>
        /// Gets the name of the service role.
        /// </summary>
        /// <value>
        /// The name of the service role.
        /// </value>
        public string ServiceRoleName => "Backend";

        /// <summary>
        /// Gets the environment.
        /// </summary>
        /// <value>
        /// The environment.
        /// </value>
        public string Environment => environment;

        /// <summary>
        /// Gets the service registry.
        /// </summary>
        /// <value>
        /// The service registry.
        /// </value>
        public IServiceRegistry ServiceRegistry => new ServiceRegistry();

        /// <summary>
        /// The environment
        /// </summary>
        string environment;

        /// <summary>
        /// Initializes a new instance of the <see cref="CribisComX"/> class.
        /// </summary>
        /// <param name="environment">The environment.</param>
        public CribisComX(string environment)
        {
            this.environment = environment;
        }

        /// <summary>
        /// Gets a value indicating whether this instance is public service.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is public service; otherwise, <c>false</c>.
        /// </value>
        public bool IsPublicService => true;

        /// <summary>
        /// Gets the required domains.
        /// </summary>
        /// <value>
        /// The required domains.
        /// </value>
        public List<string> RequiredDomains => new List<string>();
    }
}
