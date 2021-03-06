﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JukeApiLibrary;
using JukeApiModel;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using UserMemoryRepository;

namespace JukeCleanApi
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
            var repo = new MemoryRepository();
            repo.AddUser("admin", "1234");
            repo.AddUser("dummy", "password");

            var library = new MemorySongLibrary(new List<Song>() {
                new Song("Lovelove","Love first","Love me now"),
                new Song("Badass Inc.","That's a bad ass","I want ass")
            });

            ApiConfiguration.UserRepository = repo;
            ApiConfiguration.SongLibrary = library;


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
