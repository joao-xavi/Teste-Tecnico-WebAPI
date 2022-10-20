using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Siemens_WEBAPI.Data;
using Siemens_WEBAPI.Models;

namespace Siemens_WEBAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {  
        private readonly IRepository _repo;
        public ClienteController(IRepository repo)
        {
            _repo = repo;
            
        }

        [HttpGet] 
        public async Task<IActionResult> Get(){
            try{
                var result = await _repo.GetAllClientesAsync(true);
                return Ok(result);
            }
            catch(Exception ex)
            {
            return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpGet("{ClienteId}")] 
        public async Task<IActionResult> GetByClienteId(int ClienteId){
            try{
                var result = await _repo.GetClienteAsyncById(ClienteId, true);
                return Ok(result);
            }
            catch(Exception ex)
            {
            return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpGet("ByCidade/{cidadeId}")]
        public async Task<IActionResult> GetByCidadeId(int cidadeId){
            try
            {
                var result = await _repo.GetClientesAsyncByCidadeId(cidadeId, true);
                return Ok(result);
            }
            catch(Exception ex)
            {
            return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> post(Cliente model){
            try
            {
                _repo.Add(model);
                if(await _repo.SaveChangesAsync()){
                    return Ok(model);
                }
            }
            catch(Exception ex)
            {
            return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest("Unexpected error");
        }

        [HttpPut("{clienteId}")]
        public async Task<IActionResult> put(int clienteId, Cliente model){
            try
            {
                var cliente = await _repo.GetClienteAsyncById(clienteId, false);
                if(cliente == null) return NotFound();

                _repo.Update(model);

                if(await _repo.SaveChangesAsync()){
                    return Ok(model);
                }
            }
            catch(Exception ex)
            {
            return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest("Unexpected error");
        }

        [HttpDelete("{clienteId}")]
        public async Task<IActionResult> delete(int clienteId){
            try
            {
                var cliente = await _repo.GetClienteAsyncById(clienteId, false);
                if(cliente == null) return NotFound();

                _repo.Delete(cliente);
                
                if(await _repo.SaveChangesAsync()){
                    return Ok("Deletado");
                }
            }
            catch(Exception ex)
            {
            return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest("Unexpected error");
        }
    }
}