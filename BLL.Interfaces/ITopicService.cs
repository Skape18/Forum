using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.DTO.DTOs;

namespace BLL.Interfaces
{
    public interface ITopicService
    {
        Task<IEnumerable<TopicDto>> GetAllAsync();

        Task<TopicDto> GetByIdAsync(int id);

        Task CreateAsync(TopicDto topicDto);

        Task UpdateAsync(TopicDto topicDto);

        Task RemoveAsync(TopicDto topicsDto);
    }
}