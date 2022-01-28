using HotChocolateGraphqlDemo.Api.Src.Data;
using HotChocolateGraphqlDemo.Api.Src.Data.Repositories;
using HotChocolateGraphqlDemo.Api.Src.Graphql;
using HotChocolateGraphqlDemo.Api.Src.Graphql.DataLoaders;
using HotChocolateGraphqlDemo.Api.Src.Graphql.Schema.AccountSchema;
using HotChocolateGraphqlDemo.Api.Src.Graphql.Schema.OwnerSchema;
using HotChocolateGraphqlDemo.Api.Src.Graphql.Schema.RoleSchema;
using HotChocolateGraphqlDemo.Api.Src.Graphql.Schema.UserSchema;
using HotChocolateGraphqlDemo.Api.Src.Services;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

using System;

namespace HotChocolateGraphqlDemo.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // DB CONNECTION
            string connectionString = Configuration.GetConnectionString("mysqlConString");
            services.AddPooledDbContextFactory<ApiDbContext>(options => options
                .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
                .LogTo(Console.WriteLine));

            // REPOSITORY
            services.AddScoped<IRepository, Repository>();
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            // SERVICES
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IOwnerService, OwnerService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IUserService, UserService>();

            services.AddControllers();

            // GRAPHQL
            services.AddGraphQLServer()
                .AddQueryType(descriptor => descriptor.Name(GraphqlConstants.Query))
                .AddType<AccountQueries>()
                .AddType<OwnerQueries>()
                .AddType<RoleQueries>()
                .AddType<UserQueries>()
                .AddMutationType(descriptor => descriptor.Name(GraphqlConstants.Mutation))
                .AddType<AccountMutations>()
                .AddType<OwnerMutations>()
                .AddProjections();

            // GRAPHQL DATALOADERS
            services.AddScoped<AccountsByOwnerIdGroupedDataLoader>();
            services.AddScoped<OwnerBatchDataLoader>();
            services.AddScoped<RoleBatchDataLoader>();
            services.AddScoped<UsersByRoleIdGroupedDataLoader>();

            services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc("v1", new OpenApiInfo { Title = "HotChocolateGraphqlDemo.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HotChocolateGraphqlDemo.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                // GRAPHQL ENDPOINT
                endpoints.MapGraphQL();
            });
        }
    }
}
