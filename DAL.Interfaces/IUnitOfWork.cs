using DAL.Interfaces.Repositories;
using System;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
            IPostRepository Posts { get; }
            IThreadRepository Threads { get; }
            ITopicRepository Topics { get; }
            IUserProfileRepository UserProfiles { get; }
            INotificationRepository Notifications { get; }
            ITagRepository Tags { get; }

            Task SaveChangesAsync();    
    }
}
