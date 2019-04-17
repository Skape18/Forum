using BLL.Infrastructure.Services;
using BLL.Interfaces;
using DAL.EntityFramework;
using DAL.EntityFramework.Contexts;
using DAL.EntityFramework.Repositories;
using DAL.Interfaces;
using DAL.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Forum.Extensions
{
    public static class DependencyResolverExtension
    {
        public static void ResolveApplicationDependencies(this IServiceCollection services)
        {

            services.AddScoped<DbContext, ApplicationContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<INotificationRepository, NotificationRepository>();
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IThreadRepository, ThreadRepository>();
            services.AddScoped<ITopicRepository, TopicRepository>();
            services.AddScoped<IUserProfileRepository, UserProfileRepository>();

            services.AddScoped<IPostService, PostService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IThreadService, ThreadService>();
            services.AddScoped<ITopicService, TopicService>();
            services.AddScoped<INotificationService, NotificationService>();
        }
    }
}
