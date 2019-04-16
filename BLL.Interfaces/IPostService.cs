using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.DTO.DTOs;

namespace BLL.Interfaces
{
    public interface IPostService
    {
        Task<IEnumerable<PostDto>> GetAllAsync();

        Task<PostDto> GetByIdAsync(int id);

        Task CreateAsync(PostDto postDto);

        Task UpdateAsync(PostDto postDto);

        Task RemoveAsync(PostDto postDto);

        Task<IEnumerable<PostDto>> GetPostsByThreadTitle(int threadId);
    }
}