using Microsoft.Data.SqlClient;
using ProjectManager.ASPMVC.Handlers;
using ProjectManager.COMMON.Repositories;

namespace ProjectManager.ASPMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            string connectionString = builder.Configuration.GetConnectionString("ProjectManager.Database")!;

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddHttpContextAccessor();
            builder.Services.AddScoped<UserSessionManager>();
            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddSession(options =>
            {
                options.Cookie.Name = "ProjectManager.Session";
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
                options.IdleTimeout = TimeSpan.FromMinutes(120);
            });
            builder.Services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
                options.Secure = CookieSecurePolicy.Always;
            });

            builder.Services.AddScoped<SqlConnection>(serviceProdiver =>
            new SqlConnection(connectionString));

            builder.Services.AddScoped<IRepo_User<DAL.Entities.User>, DAL.Services.UserService>();
            builder.Services.AddScoped<IRepo_Employee<DAL.Entities.Employee>, DAL.Services.EmployeeService>();
            builder.Services.AddScoped<IRepo_Project<DAL.Entities.Project>, DAL.Services.ProjetService>();
            builder.Services.AddScoped<IRepo_Post<DAL.Entities.Post>, DAL.Services.PostService>();
            builder.Services.AddScoped<IRepo_TakePart<DAL.Entities.TakePart>, DAL.Services.TakePartService>();

            builder.Services.AddScoped<IRepo_User<BLL.Entities.User>, BLL.Services.UserService>();
            builder.Services.AddScoped<IRepo_Employee<BLL.Entities.Employee>, BLL.Services.EmployeeService>();
            builder.Services.AddScoped<IRepo_Project<BLL.Entities.Project>, BLL.Services.ProjectService>();
            builder.Services.AddScoped<IRepo_Post<BLL.Entities.Post>, BLL.Services.PostService>();
            builder.Services.AddScoped<IRepo_TakePart<BLL.Entities.TakePart>, BLL.Services.TakePartService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseSession();
            app.UseCookiePolicy();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
