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
    public class CidadeController : ControllerBase
    {
        private readonly IRepository _repo;
        public CidadeController(IRepository repo)
        {
            _repo = repo;
            
        }

        [HttpGet] 
        public async Task<IActionResult> Get(){
            try{
                var result = await _repo.GetAllCidadesAsync(true);
                return Ok(result);
            }
            catch(Exception ex)
            {
            return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpGet("{CidadeId}")] 
        public async Task<IActionResult> GetByCidadeId(int cidadeId){
            try{
                var result = await _repo.GetCidadeAsyncById(cidadeId, true);
                return Ok(result);
            }
            catch(Exception ex)
            {
            return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> post(Cidade model){
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

        [HttpPut("{cidadeId}")]
        public async Task<IActionResult> put(int cidadeId, Cidade model){
            try
            {
                var cidade = await _repo.GetCidadeAsyncById(cidadeId, false);
                if(cidade == null) return NotFound();

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

        [HttpDelete("{cidadeId}")]
        public async Task<IActionResult> delete(int cidadeId){
            try
            {
                var cidade = await _repo.GetCidadeAsyncById(cidadeId, false);
                if(cidade == null) return NotFound();

                _repo.Delete(cidade);
                
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