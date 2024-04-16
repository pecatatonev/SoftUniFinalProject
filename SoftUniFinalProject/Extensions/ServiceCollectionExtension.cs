using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoftUniFinalProject.Core.Contracts.Admin.Identity;
using SoftUniFinalProject.Core.Contracts.Attendance;
using SoftUniFinalProject.Core.Contracts.Comment;
using SoftUniFinalProject.Core.Contracts.Event;
using SoftUniFinalProject.Core.Contracts.Home;
using SoftUniFinalProject.Core.Contracts.Team;
using SoftUniFinalProject.Core.Services.Admin.UserService;
using SoftUniFinalProject.Core.Services.AttendanceService;
using SoftUniFinalProject.Core.Services.CommentService;
using SoftUniFinalProject.Core.Services.EventService;
using SoftUniFinalProject.Core.Services.HomeService;
using SoftUniFinalProject.Core.Services.TeamService;
using SoftUniFinalProject.Infrastructure.Data;
using SoftUniFinalProject.Infrastructure.Data.Common;
using SoftUniFinalProject.Infrastructure.Data.IdentityModels;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection service) 
        {
            service.AddLogging();

            service.AddScoped<ISponsorService, SponsorService>();
            service.AddScoped<ITeamService, TeamService>();
            service.AddScoped<IEventService, EventService>();
            service.AddScoped<IFootballGameService, FootballGameService>();
            service.AddScoped<IAttendanceService, AttendanceService>();
            service.AddScoped<ICommentService, CommentService>();
            service.AddScoped<IUserService, UserService >();

            service.AddTransient<IHomeService, HomeService>();


            service.AddControllersWithViews(options =>
            {
                options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
            });

            return service;
        }

        public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection");
            services.AddDbContext<FootballEventDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped<IRepository, Repository>();

           services.AddDatabaseDeveloperPageExceptionFilter();
            return services;
        }

        public static IServiceCollection AddApplicationIdentity(this IServiceCollection services, IConfiguration config)
        {
           services
                .AddDefaultIdentity<ApplicationUser>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.SignIn.RequireConfirmedEmail = false;
                    options.Password.RequireDigit = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequiredLength = 6;
                })
                .AddRoles<ApplicationRole>()
                .AddEntityFrameworkStores<FootballEventDbContext>();

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/User/Login";
                options.LogoutPath = "/User/Logout";
            });
            return services;
        }
    }
}
