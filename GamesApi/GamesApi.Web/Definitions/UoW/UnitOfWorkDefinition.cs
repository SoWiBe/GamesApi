using Calabonga.UnitOfWork;
using GamesApi.Infrastructure;
using GamesApi.Web.Definitions.Base;

namespace GamesApi.Web.Definitions.UoW
{
    /// <summary>
    /// Unit of Work registration as MicroserviceDefinition
    /// </summary>
    public class UnitOfWorkDefinition : AppDefinition
    {
        /// <summary>
        /// Configure services for current microservice
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public override void ConfigureServices(IServiceCollection services, IConfiguration configuration)
            => services.AddUnitOfWork<ApplicationDbContext>();
    }
}