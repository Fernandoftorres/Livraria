using System;
using System.Collections.Generic;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Livraria.Application.Interfaces;
using Livraria.Application.ViewModels;
using Livraria.Domain.Commands;
using Livraria.Domain.Core.Bus;
using System.Linq;
using Livraria.Domain.Interfaces;

namespace Livraria.Application.Services
{
    public class LivroAppService : ILivroAppService
    {
        private readonly IMapper _mapper;
        private readonly ILivroRepository _livroRepository;
        private readonly IMediatorHandler Bus;

        public LivroAppService(IMapper mapper,
                                  ILivroRepository livroRepository,
                                  IMediatorHandler bus)
        {
            _mapper = mapper;
            _livroRepository = livroRepository;
            Bus = bus;
        }

        public IEnumerable<LivroViewModel> GetAll()
        {
            return _livroRepository
                .GetAll()
                .OrderBy(livro => livro.Titulo)
                .ProjectTo<LivroViewModel>();
        }

        public LivroViewModel GetById(Guid id)
        {
            return _mapper.Map<LivroViewModel>(_livroRepository.GetById(id));
        }

        public void Register(LivroViewModel livroViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewLivroCommand>(livroViewModel);
            Bus.SendCommand(registerCommand);
        }

        public void Update(LivroViewModel livroViewModel)
        {
            var updateCommand = _mapper.Map<UpdateLivroCommand>(livroViewModel);
            Bus.SendCommand(updateCommand);
        }

        public void Remove(Guid id)
        {
            var removeCommand = new RemoveLivroCommand(id);
            Bus.SendCommand(removeCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
