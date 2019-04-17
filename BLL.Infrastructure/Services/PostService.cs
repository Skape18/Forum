using System.Collections.Generic;
using System.Linq;
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

            var author = await UnitOfWork.UserProfiles.GetByIdAsync(postDto.UserProfileId);
            author.Rating++;

            UnitOfWork.UserProfiles.Update(author);
            await UnitOfWork.SaveChangesAsync();

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

            //var postToDelete = Mapper.Map<PostDto, Post>(postDto);

  
            var users = await UnitOfWork.UserProfiles.GetWithIncludesAsync();
            var user = users.FirstOrDefault(u => u.Id == postDto.UserProfileId);

            user.Rating--;

            var post = await UnitOfWork.Posts.GetByIdAsync(postDto.Id);
            var replies = post.Replies;

            foreach (var reply in replies)
            {
                reply.RepliedPostId = null;
                UnitOfWork.Posts.Update(reply);
            }

            await UnitOfWork.SaveChangesAsync();

            UnitOfWork.Posts.Remove(post);
            UnitOfWork.UserProfiles.Update(user);
            await UnitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<PostDto>> GetPostsByThreadTitle(int threadId)
        {
            var posts = await UnitOfWork.Posts.GetAllAsync();

            var postsByThreadId = posts.Where(p => p.ThreadId == threadId);

            var postDtos = Mapper.Map<IEnumerable<Post>, List<PostDto>>(postsByThreadId);

            return postDtos;
        }
    }
}
