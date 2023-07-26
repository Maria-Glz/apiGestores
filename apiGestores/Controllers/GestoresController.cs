using apiGestores.Context;
using apiGestores.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace apiGestores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GestoresController : ControllerBase
    {
        private readonly AppDbContext context;

        public GestoresController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.gestores_db.ToList());

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }//Get

        [HttpGet("{id}", Name = "GetGestor")]

        public ActionResult Get(int id)
        {
            try
            {
                //mediante LINQ se busca dentro de los registros cual es el que coincide con id mandado con el usuario para regresarlo con el ok
                var gestor = context.gestores_db.FirstOrDefault(g => g.id == id);
                return Ok(gestor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }//Get

        [HttpPost]
        public ActionResult Post([FromBody] Gestores_bd gestor)
        {
            try
            {
                context.gestores_db.Add(gestor);
                context.SaveChanges();
                return CreatedAtRoute("GetGestor", new { id = gestor.id }, gestor); //se retorna al usuario lo que se inserto
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }//Post

        [HttpPut("{id}")]

        public ActionResult Put(int id, [FromBody] Gestores_bd gestor)
        {
            try
            {
                if (gestor.id == id)
                {
                    context.Entry(gestor).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetGestor", new { id = gestor.id }, gestor);
                }//retorna al usuario lo que se inserto
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }//Put

        [HttpDelete]
        public ActionResult Delete(int id) { 
            
            try
            {
                var gestor = context.gestores_db.FirstOrDefault(g => g.id == id); //busca si el registro existe

                if(gestor != null) //si existe
                {
                    context.gestores_db.Remove(gestor); //remueve id
                    context.SaveChanges();
                    return Ok(id);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);  

            }
        
        }//Delete
    }
}
