﻿using GamesApi.Domain.Base;
using GamesApi.Web.Definitions.Base;

namespace GamesApi.Web.Definitions.Cors
{
    /// <summary>
    /// Cors configurations
    /// </summary>
    public class CorsDefinition : AppDefinition
    {
        /// <summary>
        /// Configure services for current microservice
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public override void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                builder => builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            });
        }
    }
}