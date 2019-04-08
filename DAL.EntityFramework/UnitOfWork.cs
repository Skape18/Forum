using System;
using System.Threading.Tasks;
using DAL.EntityFramework.Contexts;
using DAL.Interfaces;
using DAL.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DAL.EntityFramework
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context; 

        public UnitOfWork(DbContext context, IPostRepository postRepository,
            IThreadRepository threadRepository, INotificationRepository notificationRepository,
            IUserProfileRepository userProfileRepository, ITopicRepository topicRepository)
        {
            _context = context;
            Posts = postRepository;
            Threads = threadRepository;
            Notifications = notificationRepository;
            UserProfiles = userProfileRepository;
            Topics = topicRepository;
        }


        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public IPostRepository Posts { get; }
        public IThreadRepository Threads { get; }
        public ITopicRepository Topics { get; }
        public IUserProfileRepository UserProfiles { get; }
        public INotificationRepository Notifications { get; }
    }
}
