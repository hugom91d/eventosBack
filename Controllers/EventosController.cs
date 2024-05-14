using ApiEventos.Datos;
using ApiEventos.Modelo;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace ApiEventos.Controllers
{
    [ApiController]
    [Route("api/eventos")]
    [EnableCors("AllowAll")]
    public class EventosController : ControllerBase
    {
        
        [HttpGet]
        public async Task<ActionResult<List<Meventos>>> Get()
        {
            var function = new Deventos();
            var lista = await function.Mostrareventos();
            return lista;
        }

        [HttpPost]
        public async Task Post([FromBody] Meventos parametros)
        {
            var function = new Deventos();
            await function.InsertarEvento(parametros);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Meventos parametros)
        {
            var function = new Deventos();
            parametros.id = id;
            await function.EditarEvento(parametros);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var function = new Deventos();
            var parametros = new Meventos();
            parametros.id = id;
            await function.EliminarEvento(parametros);
            return NoContent();
        }
    }
}
