using System;
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
    public class TopicService : BaseService, ITopicService
    {
        private string _defaultTopicImagePath;

        public TopicService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
            _defaultTopicImagePath = @"topic_images/default_topic_image.jpg";  
        }

        public async Task<IEnumerable<TopicDto>> GetAllAsync()
        {
            var topics = await UnitOfWork.Topics.GetAllAsync();

            return Mapper.Map<IEnumerable<Topic>, List<TopicDto>>(topics);
        }

        public async Task<TopicDto> GetByIdAsync(int id)
        {
            var topic = await UnitOfWork.Topics.GetByIdAsync(id);

            if (topic != null)
                return Mapper.Map<Topic, TopicDto>(topic);

            return null;
        }

        public async Task CreateAsync(TopicDto topicDto)
        {
            if (topicDto == null)
                return;

            if (topicDto.ImagePath == null)
                topicDto.ImagePath = _defaultTopicImagePath;


            var topic = Mapper.Map<TopicDto, Topic>(topicDto);

            

            await UnitOfWork.Topics.CreateAsync(topic);
            await UnitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(TopicDto topicDto)
        {
            if (topicDto == null)
                return;

            var topic = Mapper.Map<TopicDto, Topic>(topicDto);

            UnitOfWork.Topics.Update(topic);

            await UnitOfWork.SaveChangesAsync();
        }

        public async Task RemoveAsync(TopicDto topicsDto)
        {
            if (topicsDto == null)
                return;

            var topic = Mapper.Map<TopicDto, Topic>(topicsDto);

            UnitOfWork.Topics.Remove(topic);
            await UnitOfWork.SaveChangesAsync();
        }
    }
}
