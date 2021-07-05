using TemplateWebAPI.Application.Commands;
using TemplateWebAPI.Application.Events;
using TemplateWebAPI.Application.ViewModels;
using TemplateWebAPI.Domain.Entites;

namespace $safeprojectname$.Mapper
{
    public class ProdutoMappingProfile : MappingProfile
    {
        public ProdutoMappingProfile()
        {
            CreateMap<AcidionarProdutoViewModel, AdicionarProdutoCommand>().ReverseMap();
            CreateMap<Produto, AdicionarProdutoCommand>().ReverseMap();
            CreateMap<AdicionarProdutoCommand, ProdutoAdiconadoEvent>()
                .ConstructUsing(p => new ProdutoAdiconadoEvent(p.Id,  p.Descricao, p.Valor))
                .ForMember(x => x.MessageType, opt => opt.Ignore())
                .ForMember(x => x.Timestamp, opt => opt.Ignore())
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
