using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTO.DTOs;
using BLL.Interfaces;
using DAL.Domain.Entities;
using DAL.Interfaces;

namespace BLL.Infrastructure.Services
{
    public class ThreadService : BaseService, IThreadService
    {
        public ThreadService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<IEnumerable<ThreadDto>> GetAllAsync()
        {
            var threads = await UnitOfWork.Threads.GetAllAsync();

            return Mapper.Map<IEnumerable<Thread>, List<ThreadDto>>(threads);
        }

        public async Task<IEnumerable<ThreadDto>> GetAllSortedByDate()
        {
            var threads = await UnitOfWork.Threads.GetWithPredicatesAsync(n => n.ThreadOpenedDate);

            return Mapper.Map<IEnumerable<Thread>, List<ThreadDto>>(threads);
        }

        public async Task<IEnumerable<ThreadDto>> GetOpened()
        {
            var openedThreads = await UnitOfWork.Threads.GetWithPredicatesAsync(null, t => t.IsOpen);

            return Mapper.Map<IEnumerable<Thread>, List<ThreadDto>>(openedThreads);
        }

        public async Task<ThreadDto> GetByIdAsync(int id)
        {
            var thread = await UnitOfWork.Threads.GetByIdAsync(id);

            if (thread != null)
                return Mapper.Map<Thread, ThreadDto>(thread);

            return null;
        }

        public async Task CreateAsync(ThreadDto threadDto)
        {
            if (threadDto == null)
                return;

            var thread = Mapper.Map<ThreadDto, Thread>(threadDto);

            await UnitOfWork.Threads.CreateAsync(thread);
            await UnitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(ThreadDto threadDto)
        {
            if (threadDto == null)
                return;

            var thread = Mapper.Map<ThreadDto, Thread>(threadDto);

            UnitOfWork.Threads.Update(thread);

            await UnitOfWork.SaveChangesAsync();
        }

        public async Task RemoveAsync(ThreadDto threadDto)
        {
            if (threadDto == null)
                return;

            var thread = Mapper.Map<ThreadDto, Thread>(threadDto);

            UnitOfWork.Threads.Remove(thread);
            await UnitOfWork.SaveChangesAsync();
        }

        public async Task CloseThread(int threadId)
        {
            var thread = await UnitOfWork.Threads.GetByIdAsync(threadId);

            if (thread == null)
                return;

            thread.IsOpen = false;

            UnitOfWork.Threads.Update(thread);
            await UnitOfWork.SaveChangesAsync();
        }
    }
}
