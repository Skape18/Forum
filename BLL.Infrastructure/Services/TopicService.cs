using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTO.DTOs;
using BLL.Infrastructure.Exceptions;
using BLL.Interfaces;
using DAL.Domain.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BLL.Infrastructure.Services
{
    public class TopicService : BaseService, ITopicService
    {
        private readonly string _defaultTopicImagePath;

        public TopicService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
            _defaultTopicImagePath = @"topic_images/default_topic_image.jpg";  
        }

        public async Task<IEnumerable<TopicDto>> GetAllAsync()
        {
            var topics = await UnitOfWork.Topics.GetAllAsync().ToListAsync();

            return Mapper.Map<IEnumerable<Topic>, List<TopicDto>>(topics);
        }

        public async Task<TopicDto> GetByIdAsync(int id)
        {
            var topic = await UnitOfWork.Topics.GetByIdAsync(id);

            if (topic == null)
                throw new DbQueryResultNullException("Db query result is null", "topics");

            return Mapper.Map<Topic, TopicDto>(topic);
        }

        public async Task CreateAsync(TopicDto topicDto)
        {
            if (topicDto == null)
                throw new ArgumentNullException("topicDto", "Argument is null");

            if (topicDto.ImagePath == null)
                topicDto.ImagePath = _defaultTopicImagePath;


            var topic = Mapper.Map<TopicDto, Topic>(topicDto);

            

            await UnitOfWork.Topics.CreateAsync(topic);
            await UnitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(TopicDto topicDto)
        {
            if (topicDto == null)
                throw new ArgumentNullException("topicDto", "Argument is null");

            var topic = Mapper.Map<TopicDto, Topic>(topicDto);

            UnitOfWork.Topics.Update(topic);

            await UnitOfWork.SaveChangesAsync();
        }

        public async Task RemoveAsync(TopicDto topicDto)
        {
            if (topicDto == null)
                throw new ArgumentNullException("topicDto", "Argument is null");

            var topic = Mapper.Map<TopicDto, Topic>(topicDto);

            UnitOfWork.Topics.Remove(topic);
            await UnitOfWork.SaveChangesAsync();
        }

        public async Task CreateTopicWithImage(TopicDto topicDto, string fileName, string rootPath, byte[] image)
        {
            string imageName = Path.GetFileNameWithoutExtension(fileName) + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(fileName);

            string imagePath = Path.Combine("topic_images", imageName);

            string fullPath = Path.Combine(rootPath, imagePath);

            File.WriteAllBytes(fullPath, image);
  
            topicDto.ImagePath = imagePath;

            var topic = Mapper.Map<TopicDto, Topic>(topicDto);

            await UnitOfWork.Topics.CreateAsync(topic);
            await UnitOfWork.SaveChangesAsync();
        }
    }
}
