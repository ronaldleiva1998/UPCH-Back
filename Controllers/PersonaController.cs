using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using pjPruebaUpch.Models;

using Microsoft.AspNetCore.Cors;


namespace pjPruebaUpch.Controllers
{
    [EnableCors("ReglasCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        public readonly DBUPCHContext _dbcontext;

        public PersonaController(DBUPCHContext _context)
        {
            _dbcontext = _context;
        }

        [HttpGet]
        [Route("Lista")]

        public IActionResult Lista()
        {
            List<Persona> lista = new List<Persona>();

            try
            {
                lista = _dbcontext.Personas.ToList();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = lista });
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = lista });
            }
        }


        [HttpGet]
        [Route("Obtener/{idPersona:int}")]

        public IActionResult Obtener(int idPersona)
        {
            Persona oPersona = _dbcontext.Personas.Find(idPersona)!;

            if(oPersona == null)
            {
                return BadRequest("Persona no encontrada");
            }

            try
            {
                oPersona = _dbcontext.Personas.FirstOrDefault(p => p.IdPersona == idPersona)!;

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = oPersona });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = oPersona });
            }
        }


        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody] Persona objeto)
        {
            try
            {
                _dbcontext.Personas.Add(objeto);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok"});
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }
        }

        [HttpPut]
        [Route("Editar")]
        public IActionResult Editar([FromBody] Persona objeto)
        {
            Persona oPersona = _dbcontext.Personas.Find(objeto.IdPersona)!;

            if (oPersona == null)
            {
                return BadRequest("Persona no encontrada");
            }

            try
            {
                oPersona.NumeroDocumento = objeto.NumeroDocumento is null ? oPersona.NumeroDocumento : objeto.NumeroDocumento;
                oPersona.Nombres = objeto.Nombres is null ? oPersona.Nombres : objeto.Nombres;
                oPersona.ApellidoPaterno = objeto.ApellidoPaterno is null ? oPersona.ApellidoPaterno : objeto.ApellidoPaterno;
                oPersona.ApellidoMaterno = objeto.ApellidoMaterno is null ? oPersona.ApellidoMaterno : objeto.ApellidoMaterno;
                oPersona.NumeroTelefono = objeto.NumeroTelefono is null ? oPersona.NumeroTelefono : objeto.NumeroTelefono;
                oPersona.Correo = objeto.Correo is null ? oPersona.Correo : objeto.Correo;
                oPersona.Direccion = objeto.Direccion is null ? oPersona.Direccion : objeto.Direccion;

                _dbcontext.Personas.Update(oPersona);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }
        }


        [HttpDelete]
        [Route("Eliminar/{idPersona:int}")]
        public IActionResult Eliminar(int idPersona)
        {
            Persona oPersona = _dbcontext.Personas.Find(idPersona)!;

            if (oPersona == null)
            {
                return BadRequest("Persona no encontrada");
            }

            try
            {
              

                _dbcontext.Personas.Remove(oPersona);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }

        }

    }
}
