using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTO.DTOs;
using BLL.Interfaces;
using DAL.Domain.Entities;
using DAL.Interfaces;

namespace BLL.Infrastructure.Services
{
    public class PostService : BaseService, IPostService
    {

        public PostService(IUnitOfWork unitOfWork, IMapper mapper):base(unitOfWork, mapper)
        {
        }

        public async Task<IEnumerable<PostDto>> GetAllAsync()
        {
            var posts = await UnitOfWork.Posts.GetAllAsync();

            return Mapper.Map<IEnumerable<Post>, List<PostDto>>(posts);
        }

        public async Task<IEnumerable<PostDto>> GetAllSortedByDate()
        {
            var posts = await UnitOfWork.Posts.GetWithPredicatesAsync(n => n.PostDate);

            var postDtos = Mapper.Map<IEnumerable<Post>, List<PostDto>>(posts);

            return postDtos;
        }


        public async Task<PostDto> GetByIdAsync(int id)
        {
            var post = await UnitOfWork.Posts.GetByIdAsync(id);

            if (post != null)
                return Mapper.Map<Post, PostDto>(post);

            return null;
        }

        public async Task CreateAsync(PostDto postDto)
        {
            if (postDto == null)
                return;

            var post = Mapper.Map<PostDto, Post>(postDto);

            await UnitOfWork.Posts.CreateAsync(post);
            await UnitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(PostDto postDto)
        {
            if (postDto == null)
                return;

            var post = Mapper.Map<PostDto, Post>(postDto);

            UnitOfWork.Posts.Update(post);

            await UnitOfWork.SaveChangesAsync();
        }

        public async Task RemoveAsync(PostDto postDto)
        {
            if (postDto == null)
                return;

            var post = Mapper.Map<PostDto, Post>(postDto);

            UnitOfWork.Posts.Remove(post);
            await UnitOfWork.SaveChangesAsync();
        }

        public async Task RemoveAsync(int id)
        {
            var post = await UnitOfWork.Posts.GetByIdAsync(id);

            if (post == null)
                return;

            UnitOfWork.Posts.Remove(post);
            await UnitOfWork.SaveChangesAsync();
        }
    }
}
