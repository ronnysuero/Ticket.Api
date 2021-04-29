using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Ticket.Data.Interfaces;
using Ticket.Domain.Interfaces;
using Ticket.Domain.Models;

namespace Ticket.Domain.Service
{
    public class TicketService : ITicketService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public TicketService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<TicketModel> Insert(TicketModel model)
        {
            var entity = _mapper.Map<Data.Entities.Ticket>(model);

            entity.Id = 0;
            await _unitOfWork.Ticket.InsertAsync(entity);
            await _unitOfWork.SaveAsync();

            return _mapper.Map<TicketModel>(entity);
        }

        public async Task<TicketModel> GetById(int id)
        {
            var entity = await _unitOfWork.Ticket.GetByIdAsync(id);
            return _mapper.Map<TicketModel>(entity);
        }

        public async Task<IEnumerable<TicketModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<TicketModel>>(await _unitOfWork.Ticket.GetAsync());
        }

        public async Task<TicketModel> Update(TicketModel model)
        {
            var result = await _unitOfWork.Ticket.GetByIdAsync(model.Id);

            if (result == null) throw new Exception("Ticket not found");

            var entity = _mapper.Map<Data.Entities.Ticket>(model);
            entity.Id = model.Id;

            _unitOfWork.Ticket.Update(entity);
            await _unitOfWork.SaveAsync();

            return _mapper.Map<TicketModel>(entity);
        }

        public async Task<bool> Delete(int id)
        {
            var result = await _unitOfWork.Ticket.GetByIdAsync(id);

            if (result == null) throw new Exception("Ticket not found");

            _unitOfWork.Ticket.Delete(id);

            return await _unitOfWork.SaveAsync() > 0;
        }
    }
}