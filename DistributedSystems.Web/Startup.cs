using System.Reflection;
using Autofac;
using DistributedSystems.Web.Database;
using DistributedSystems.Web.Extensions;
using DistributedSystems.Web.Options;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;

namespace DistributedSystems.Web
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddRouting(options => options.LowercaseUrls = true);

            services.AddDbContext<ApplicationDbContext>((ctx, options) =>
                options.UseNpgsql(ctx.GetRequiredService<IConfiguration>()
                                     .GetConnectionString("PostgreSQL")));

            services.AddOptions<RabbitOptions>()
                    .BindConfiguration("RabbitMQ");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(GetType().GetTypeInfo().Assembly)
                   .PublicOnly()
                   .AsSelf()
                   .AsImplementedInterfaces()
                   .InstancePerLifetimeScope();

            builder
                .RegisterAssemblyTypes(GetType().GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>))
                .AsImplementedInterfaces();

            builder.Register<ServiceFactory>(context =>
            {
                var ctx = context.Resolve<IComponentContext>();
                return t => ctx.Resolve(t);
            });

            builder
                .RegisterType<Mediator>()
                .As<IMediator>()
                .InstancePerLifetimeScope();

            builder.Register(ctx => ctx.Resolve<ApplicationDbContext>())
                   .AsImplementedInterfaces();

            builder.Register(ctx =>
                   {
                       var options = ctx.Resolve<IOptions<RabbitOptions>>()
                                        .Value;

                       return new ConnectionFactory
                       {
                           HostName = options.Host,
                           UserName = options.Username,
                           Password = options.Password,
                           Port = options.Port ?? AmqpTcpEndpoint.UseDefaultPort,
                           RequestedHeartbeat = options.HeartbeatTimeout
                       };
                   })
                   .AsImplementedInterfaces()
                   .SingleInstance();

            builder.Register(ctx => ctx.Resolve<IAsyncConnectionFactory>()
                                       .CreateConnection())
                   .AsImplementedInterfaces()
                   .SingleInstance();

            builder.Register(ctx => ctx.Resolve<IConnection>()
                                       .CreateModel())
                   .AsImplementedInterfaces()
                   .SingleInstance();

            builder.RegisterBuildCallback(ctx =>
            {
                var exchange = ctx.Resolve<IOptions<RabbitOptions>>()
                                  .Value.Exchange;

                ctx.Resolve<IModel>()
                   .ExchangeDeclare(exchange, ExchangeType.Topic);
            });

            builder.RunMigrations<ApplicationDbContext>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}