using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebClient.Models;


namespace WebClient.Controllers
{
    public class AuthController : Controller
    {
        private IHttpClientFactory _httpClientFactory;      /// برای درخواستهای اچ تی تی پی استفاده میشه 

        public AuthController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Login()
        {
            return View();   // می سازیم loginViewModel  می خواهیم ویو برای لاگین بسازیم , پس اد نیو کلاس می کنیم و کلاسی به نام 
                             //  انجام دادیم , دوباره به اینجا بر میگردیم و با اد ویوو که می زنیم به اسم لاگین  و از نوع کرییت loginViewModel  پس از اینکه تعریف لازمه رو در فایل 

        }

        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            if (!ModelState.IsValid)    // اگر اعتبار ینجی هایی که گذاشتیم , انجام نشده بود 
            {
                return View(login);    // انگاه لاگین رو به ویوو برگردون تا اعتبار سنجیهای لازمه رو انجام بده 
            }

            var _client = _httpClientFactory.CreateClient("EshopClient");   // یک کلاینت ایجاد می کنیم
            var jsonBody = JsonConvert.SerializeObject(login);    // می خواد لاگین روردی رو به جیسان تبدیل کنه 
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json"); // باید یوزر نیم و پسورد رو جیسان کنم و برای ای پی ای بفرستم 
            var response = _client.PostAsync("/Api/Auth", content).Result; //   یعنی به ادرسی که جلوش دادیم پست کن و ای سرور : جواب رو به من برگردون
            if (response.IsSuccessStatusCode)   // اگر لاگین با موفقیت انجام شده بود 
            {
                var token = response.Content.ReadAsAsync<TokenModel>().Result; //    توکنی که سرور به ما داده بود رو باید دریافت کنیم و در فایل توکن مدل , مدلمون رو هم تعریف کردیم 
                                                                               //   این توکن رو که بدست بیاریم باید جایی نگهش داریم و در درخواستهای بعدی بفرستم تا سرور به ما دسترسی کامل رو بده 


                var claims = new List<Claim>()   //  حالا باید کاربر رو لاگین کنیم - یعنی انچه می خواهیم از کاربر در سیستم نگهداری کنیم
                {
                    new Claim(ClaimTypes.NameIdentifier,login.UserName),  // نام کاربر که همان یوزر نیم هست 
                    new Claim(ClaimTypes.Name,login.UserName),   // نام کاربری رو نگه می داریم 
                    new Claim("AccessToken",token.Token)   // حالا توکنش رو هم نگه می داریم
                };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme); // (به عنوان ورودی مثلا نوعش رو مشخص می کنیم) حالا کلایم رو ساختیم و می خوایم ستش کنیم
                var principal = new ClaimsPrincipal(identity);   // حالا ای دن تی تی که در خط بالا ساختیم رو بهش می دیم 
                var properties = new AuthenticationProperties
                {
                    IsPersistent = true,    // پایداری 
                    AllowRefresh = true     // تمدید زمان توکن 
                };
                HttpContext.SignInAsync(principal, properties);   //    در این مرحله , کاربر رو اتنتیکیت می کنه و کاربر رو به سیستم لاگین می ده   
                return Redirect("/Home");   // کاربر لاگین شه - موفقیت امیز بود 
            }
            else
            {
                ModelState.AddModelError("Username", "User Not Valid");   // اگر اطلاعات کاربر مشخص نبود 
                return View(login);
            }
            //  CustomerRepository حالا باید بریم سر فایل

        }
    }
}

