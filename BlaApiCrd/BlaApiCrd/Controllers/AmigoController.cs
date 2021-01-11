using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonCrd.Models;
using CommonCrd.DataServices;
using static CommonCrd.Code.GLB;
using Microsoft.AspNetCore.Authorization;

namespace BlaApiCrd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]


    public class AmigoController : ControllerBase
    {
        // GET: api/<AmigoController>    
        
        [HttpGet("Gumbo")]
        //[Authorize]
        public async Task<IActionResult> GetAllAsync()    // 
        {
            AmigosDal am = new AmigosDal();
            var Lista = await am.ListarAsync( "Nome");
            return Ok( Lista);
        }

        // GET api/<AmigoController>/5
        [HttpGet("GetById/{id}")]       
        public AmigosMd GetById(int id)
        {
            AmigosDal am = new AmigosDal();
            return am.GetById(id);
        }

        // GET api/<AmigoController>/5
        [HttpGet("GetByIdAsync/{id}")]        
        public AmigosMd GetByIdAsync(int id)
        {
            AmigosDal am = new AmigosDal();
            return (AmigosMd)am.GetByIdAsync(id).Result;
        }

        // POST api/<AmigoController>
        [HttpPost("Post")]
        public CodeMsg Post([FromBody] AmigosMd amg)
        {
            CodeMsg cm;
            try
            {
                AmigosDal am = new AmigosDal();
                cm = am.Incluir(amg);
            } catch (Exception) { throw; }
            return cm;
        }

        //// PUT api/<AmigoController>/5
        [HttpPut("{id}")]
        public CodeMsg Put(int id, [FromBody] AmigosMd amg)
        {
            CodeMsg cm;
            try
            {
                AmigosDal am = new AmigosDal();
                cm = am.Incluir(amg);
            } catch (Exception) { throw; }
            return cm;
        }

        // DELETE api/<AmigoController>/5
        [HttpDelete("delete")]
        public CodeMsg Delete(int RowId)
        {
            CodeMsg cm;
            try
            {                
                AmigosDal am = new AmigosDal();
                cm = am.Deletar(RowId);                
            } catch (Exception) { throw; }
            return cm;
        }
        [HttpDelete("DeleteAsync")]
        public async Task<CodeMsg> DeleteAsync(int RowId)
        {
            CodeMsg cm;
            try
            {                
                AmigosDal am = new AmigosDal();
                cm = await am.DeletarAsync(RowId);
            }  catch (Exception) { throw; }
            return cm;
        }
    }
}
