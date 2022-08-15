﻿using FluentValidation;
using GamesApi.Web.Definitions.Base;
using Microsoft.AspNetCore.Mvc;

namespace GamesApi.Web.Definitions.FluentValidating
{
    /// <summary>
    /// FluentValidation registration as MicroserviceDefinition
    /// </summary>
    public class FluentValidationDefinition : AppDefinition
    {
        /// <summary>
        /// Configure services for current microservice
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public override void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddValidatorsFromAssembly(typeof(Program).Assembly);
        }
    }
}