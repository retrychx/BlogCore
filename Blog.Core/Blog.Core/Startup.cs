using System;
using System.Collections.Generic;
using System.IO;
using Autofac;
using Blog.Core.AuthHelper.OverWrite;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.Swagger;
using Autofac.Extensions.DependencyInjection;
using System.Reflection;
using Blog.Core.AOP;
using Autofac.Extras.DynamicProxy;
using Blog.Core.Common.Redis;
using AutoMapper;

namespace Blog.Core
{
    /// <summary>
    /// Startup.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Blog.Core.Startup"/> class.
        /// </summary>
        /// <param name="configuration">Configuration.</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <value>The configuration.</value>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Configures the services.
        /// </summary>
        /// <param name="services">Services.</param>
        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            //记得把缓存注入
            services.AddScoped<ICaching, MemoryCaching>();

            //Redis注入
            services.AddScoped<IRedisCacheManager, RedisCacheManager>();

            //注入服务
            services.AddAutoMapper(typeof(Startup));

            services.AddMvc();

            #region Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "V1.0.0",
                    Title = "Blog.Core.API",
                    Description = "框架说明文档",
                    TermsOfService = "None",
                    Contact = new Swashbuckle.AspNetCore.Swagger.Contact
                    {
                        Name = "Blog.Core",
                        Email = "retrychx@163.com"
                    }
                });

                #region xml路径配置
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var xmlPath = Path.Combine(basePath, "Blog.Core.xml");
                c.IncludeXmlComments(xmlPath, true);

                var xmlModePath = Path.Combine(basePath, "Blog.Core.Model.xml");
                c.IncludeXmlComments(xmlModePath);
                #endregion

                #region Token绑定到ConfigureServices
                var security = new Dictionary<string, IEnumerable<string>> { { "Blog.Core", new string[] { } }, };
                c.AddSecurityRequirement(security);
                c.AddSecurityDefinition("Blog.Core", new ApiKeyScheme
                {
                    Description = "JWT授权(数据将在请求头中进行传输)直接在下框中{token}\"",
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey"
                });
                #endregion
            });
            #endregion

            #region Token服务注册
            services.AddSingleton<IMemoryCache>(factory =>
            {
                var cache = new MemoryCache(new MemoryCacheOptions());
                return cache;
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Client", policy => policy.RequireRole("Client").Build());
                options.AddPolicy("Admin", policy => policy.RequireRole("Admin").Build());
                options.AddPolicy("AdminOrClient", policy => policy.RequireRole("Admin,Client").Build());
            });
            #endregion

            #region AutoFac
            //实例化 AutoFac 容器
            var builder = new ContainerBuilder();

            //注册拦截器
            builder.RegisterType<BlogCacheAOP>();

            //注册要通过反射创建的组件
            //builder.RegisterType<AdvertisementServices>().As<IAdvertisementServices>();
            var path = PlatformServices.Default.Application.ApplicationBasePath;

            var servicesPath = Path.Combine(path, "Blog.Core.Services.dll");
            var assemblysServices = Assembly.LoadFile(servicesPath);
            builder.RegisterAssemblyTypes(assemblysServices)
                   .AsImplementedInterfaces()
                   .InstancePerLifetimeScope()
                   .EnableInterfaceInterceptors()
                   .InterceptedBy(typeof(BlogCacheAOP));

            var repositoryPath = Path.Combine(path, "Blog.Core.Repository.dll");
            var assemblysRepository = Assembly.LoadFile(repositoryPath);
            builder.RegisterAssemblyTypes(assemblysRepository).AsImplementedInterfaces();

            //将services填充AutoFac容器生成器
            builder.Populate(services);

            //使用已进行的组件登记创建新容器
            var ApplicationContainer = builder.Build();
            #endregion

            //第三方IOC接管
            return new AutofacServiceProvider(ApplicationContainer);
        }

        /// <summary>
        /// Configure the specified app and env.
        /// </summary>
        /// <param name="app">App.</param>
        /// <param name="env">Env.</param>
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            #region Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiHelp V1");
            });
            #endregion

            //使用中间件
            app.UseMiddleware<JwtTokenAuth>();

            app.UseMvc();
        }
    }
}
