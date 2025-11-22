using EstacionaFacil.Domain.Entities;
using EstacionaFacil.Domain.Services.Base;
using EstacionaFacil.Domain.Interfaces.Repositories;
using EstacionaFacil.Domain.Interfaces.Services;

namespace EstacionaFacil.Domain.Services
{
    public class ModeloService : EntidadeDescricaoService<Modelo>, IModeloService
    {
        public ModeloService(IModeloRepository repository) : base(repository) 
        {
        }
    }
}
