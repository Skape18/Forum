using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.DTO.DTOs;

namespace BLL.Interfaces
{
    public interface IThreadService
    {
        Task<IEnumerable<ThreadDto>> GetAllAsync();
        
        Task<ThreadDto> GetByIdAsync(int id);
        
        Task CreateAsync(ThreadDto threadDto);

        Task UpdateAsync(ThreadDto threadDto);

        Task RemoveAsync(ThreadDto threadDto);

        Task<IEnumerable<ThreadDto>> GetThreadsByTopicId(int topicId);

        Task<bool> Deactivate(int threadId);
    }
}