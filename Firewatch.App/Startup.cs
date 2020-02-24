using System;
using System.Net.Http;
using System.Net.Http.Headers;
using AutoMapper;
using Firewatch.Data.Repositories;
using Firewatch.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Firewatch.App
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            RegisterHttpClient<IInstanceRepository, InstanceRepository>(services);
            RegisterHttpClient<ISolutionRepository, SolutionRepository>(services);
            RegisterHttpClient<ISystemUserRepository, SystemUserRepository>(services);

            services.AddSingleton<IInstanceService, InstanceService>();
            services.AddSingleton<ISystemUserService, SystemUserService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }

        public static void RegisterHttpClient<T, TU>(IServiceCollection services) where T : class where TU : class, T
        {
            services.AddHttpClient<T, TU>(httpClient =>
            {
                httpClient.BaseAddress = new Uri("https://d-crm");
                httpClient.Timeout = new TimeSpan(0, 0, 120);
                httpClient.DefaultRequestHeaders.Clear();

                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));

            }).ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler()
            {
                UseDefaultCredentials = true,
                AutomaticDecompression = System.Net.DecompressionMethods.GZip
            });
        }
    }
}
