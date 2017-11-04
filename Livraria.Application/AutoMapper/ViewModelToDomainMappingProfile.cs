using AutoMapper;
using Livraria.Application.ViewModels;
using Livraria.Domain.Commands;

namespace Livraria.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<LivroViewModel, RegisterNewLivroCommand>()
                .ConstructUsing(c => new RegisterNewLivroCommand(c.Titulo,
                                                                 c.Autor, 
                                                                 c.AnoPublicacao,
                                                                 c.Quantidade));
            CreateMap<LivroViewModel, UpdateLivroCommand>()
                .ConstructUsing(c => new UpdateLivroCommand(c.Id, 
                                                            c.Titulo, 
                                                            c.Autor, 
                                                            c.AnoPublicacao,
                                                            c.Quantidade));
        }
    }
}
