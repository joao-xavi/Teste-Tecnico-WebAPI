using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Siemens_WEBAPI.Models;

namespace Siemens_WEBAPI.Data
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        Task<Cliente[]> GetAllClientesAsync(bool includeCidade);        
        Task<Cidade[]> GetClientesAsyncByCidadeId(int cidadeId, bool includeCliente);
        Task<Cliente> GetClienteAsyncById(int clienteId, bool includeCidade);
        
        Task<Cidade[]> GetAllCidadesAsync(bool includeAluno);
        Task<Cidade> GetCidadeAsyncById(int cidadeId, bool includeCliente);

    }
}
