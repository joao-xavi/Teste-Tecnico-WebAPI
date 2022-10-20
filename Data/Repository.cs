using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Siemens_WEBAPI.Models;

namespace Siemens_WEBAPI.Data
{
    public class Repository : IRepository
    {
        private readonly DataContext _context;

        public Repository(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<Cliente[]> GetAllClientesAsync(bool includeCidade = false)
        {
            IQueryable<Cliente> query = _context.Cliente;

            if (includeCidade) 
            {
                query = query.Include(pe => pe.Cidade);
            }

            query = query.AsNoTracking()
                         .OrderBy(c => c.id);

            return await query.ToArrayAsync();
        }
        public async Task<Cliente> GetClienteAsyncById(int clienteId, bool includeCidade)
        {
            IQueryable<Cliente> query = _context.Cliente;

            if (includeCidade)
            {
                query = query.Include(a => a.Cidade);
            }

            query = query.AsNoTracking()
                         .OrderBy(cliente => cliente.id)
                         .Where(cliente => cliente.id == clienteId);

            return await query.FirstOrDefaultAsync();
        }
        public async Task<Cidade[]> GetClientesAsyncByCidadeId(int cidadeId, bool includeCliente)
        {
            IQueryable<Cidade> query = _context.Cidade;

            if (includeCliente)
            {
                query = query.Include(p => p.Clientes);
            }

            query = query.AsNoTracking()
                         .OrderBy(cidade => cidade.id)
                         .Where(cidade => cidade.Clientes.Any(ad => ad.CidadeId == cidadeId));

            return await query.ToArrayAsync();
        }

        public async Task<Cidade[]> GetAllCidadesAsync(bool includeClientes = true)
        {
            IQueryable<Cidade> query = _context.Cidade;

            if (includeClientes)
            {
                query = query.Include(c => c.Clientes);
            }

            query = query.AsNoTracking()
                         .OrderBy(cidade => cidade.id);

            return await query.ToArrayAsync();
        }
        public async Task<Cidade> GetCidadeAsyncById(int cidadeId, bool includeCliente = true)
        {
            IQueryable<Cidade> query = _context.Cidade;

            if (includeCliente)
            {
                query = query.Include(pe => pe.Clientes);
            }

            query = query.AsNoTracking()
                         .OrderBy(cidade => cidade.id)
                         .Where(cidade => cidade.id == cidadeId);

            return await query.FirstOrDefaultAsync();
        }
    }
}