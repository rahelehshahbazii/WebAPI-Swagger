using EshopAPI.Contract;
using EshopAPI.Models;
using EshopAPI.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.Swagger;
using System;
using System.IO;
using System.Text;

namespace EshopAPI
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

            services.AddMvc();
            services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info { Title = "My First Swagger" });
           
                swagger.IncludeXmlComments(Path.Combine(Directory.GetCurrentDirectory(), @"bin\Debug\netcoreapp3.1", "EshopAPI.xml"));
            });

            services.AddControllers();
            services.AddDbContext<EshopApi_DBContext>(options =>
            {

                options.UseSqlServer("Server=DESKTOP-0BBCI3J; Initial Catalog = EshopApi_DB; user Id = Raheleh; Password = Sh091023$#;Trusted_Connection=True;");
            });

            services.AddHttpClient("EshopClient", client =>
            {

                 client.BaseAddress = new Uri("http://localhost:53085");
            });

            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<ISalesPersonsRepository, SalesPersonsRepository>();
            services.AddResponseCaching();
            services.AddMemoryCache();

            //JWT
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters()
                    // evaluate Token on the Server side 
                    {
                        ValidateIssuer = true,        //توکن سمت سرور اعتبار سنجی شود ؟ 
                        ValidateAudience = false,    //توکن سمت کلاینت اعتبار سنجی شود ؟ 
                        ValidateLifetime = true,    // توکن دارای تاریخ انقضا باشد 
                        ValidateIssuerSigningKey = true,          // توکن اعتبار سنجی شود ؟
                        ValidIssuer = "http://localhost:5395",   //  سرور ولید رو مشخص می کنیم که می تونه اعتبار سینجی را انجام دهد 
                                                                // رمز نگاری کن  OurVerifyTopLearn  کلید رمزنگاری که توکن بر اساس ان رمز نگاری می شه اینجا داده می شه --مثلا  بر اساس کلید
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("OurVerifyTopLearn"))
                    };

                    // حالا باید اجازه دهیم تا اپلیکیشن های دیگه هم بتونن از این استفاده کنن
                    services.AddCors(options =>
                    {
                        //  پالیسی می خواهیم بدیم 
                        options.AddPolicy("EnableCourse" ,builder =>
                        {
                            builder.AllowAnyOrigin()   // بقیه به این احراز هویت دسترسی دارند  
                            .AllowAnyHeader()         //  تو هدر ست می شه 
                            .AllowAnyMethod()        //  تو متدهای اچ تی تی پی هم هست 
                            .AllowCredentials()     // گواهینامه دارند یا ندارند 
                            .Build();
                        });
                    });
                }
               );


            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie( options =>
                {
                    options.LoginPath = "/Auth/Login";
                    options.LogoutPath = "/Auth/SignOut";
                    options.Cookie.Name = "Auth.Coo";


                });

           // services.AddTransient<CustomerRepository,CustomerRepository>();
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}
            //else
            //{
            //    app.UseExceptionHandler("/Home/Error");
            //}


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseResponseCaching();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My First Swagger");
            });

            app.UseCors("EnableCors");
            app.UseAuthentication();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseResponseCaching();
           
            // تعریف میدل ویر 
            app.UseCors("EnableCors");    // می گیم که اپلیکیشن که تعریف کنه از این کرس استفاده کنه 
            app.UseAuthentication();      // هست Jwt تعریف کرده بودم استفاده کنم که از نوع add authentication حالا می خوام از احراز هویتی که در   
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
