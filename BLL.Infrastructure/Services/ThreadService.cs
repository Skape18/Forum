using System;
using System.Collections.Generic;
using System.Linq;
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
    public class ThreadService : BaseService, IThreadService
    {
        public ThreadService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<IEnumerable<ThreadDto>> GetAllAsync()
        {
            var threads = await UnitOfWork.Threads.GetAllAsync().ToListAsync();

            return Mapper.Map<IEnumerable<Thread>, List<ThreadDto>>(threads);
        }

        public async Task<ThreadDto> GetByIdAsync(int id)
        {
            var thread = await UnitOfWork.Threads.GetByIdAsync(id);

            if (thread == null)
                throw new DbQueryResultNullException("Db query result is null", "threads");


            var threadDto = Mapper.Map<Thread, ThreadDto>(thread);

            return threadDto;
        }

        public async Task CreateAsync(ThreadDto threadDto)
        {
            if (threadDto == null)
                throw new ArgumentNullException("threadDto", "Argument is null");

            var thread = Mapper.Map<ThreadDto, Thread>(threadDto);

            await UnitOfWork.Threads.CreateAsync(thread);
            await UnitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(ThreadDto threadDto)
        {
            if (threadDto == null)
                throw new ArgumentNullException("threadDto", "Argument is null");

            var thread = Mapper.Map<ThreadDto, Thread>(threadDto);

            UnitOfWork.Threads.Update(thread);

            await UnitOfWork.SaveChangesAsync();
        }

        public async Task RemoveAsync(ThreadDto threadDto)
        {
            if (threadDto == null)
                throw new ArgumentNullException("threadDto", "Argument is null");

            var thread = Mapper.Map<ThreadDto, Thread>(threadDto);

            UnitOfWork.Threads.Remove(thread);
            await UnitOfWork.SaveChangesAsync();
        }

        public async Task CloseThread(int threadId)
        {
            var thread = await UnitOfWork.Threads.GetByIdAsync(threadId);

            if (thread == null)
                throw new DbQueryResultNullException("Db query result is null", "threads");

            thread.IsOpen = false;

            UnitOfWork.Threads.Update(thread);
            await UnitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<ThreadDto>> GetThreadsByTopicId(int topicId)
        {
            var threads = await UnitOfWork.Threads.GetAllAsync().ToListAsync();

            var threadsByTopicId = threads.Where(t => t.TopicId == topicId);

            var threadsByTopicTitleDtos = Mapper.Map<IEnumerable<Thread>, List<ThreadDto>>(threadsByTopicId);

            return threadsByTopicTitleDtos;
        }

        public async Task<bool> Deactivate(int threadId)
        {
            var thread = await UnitOfWork.Threads.GetByIdAsync(threadId);

            if (thread == null)
                throw new DbQueryResultNullException("Db query result is null", "threads");

            thread.IsOpen = false;
            thread.ThreadClosedDate = DateTime.Now;
            
            UnitOfWork.Threads.Update(thread);
            await UnitOfWork.SaveChangesAsync();

            return true;
        }
    }
}
