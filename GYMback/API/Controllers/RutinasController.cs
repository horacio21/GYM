using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Domain;

namespace API.Controllers
{
    [Authorize]
    public class RutinasController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Rutinas
        public IQueryable<Rutina> GetRutinas()
        {
            return db.Rutinas;
        }

        // GET: api/Rutinas/5
        [ResponseType(typeof(Rutina))]
        public async Task<IHttpActionResult> GetRutina(int id)
        {
            Rutina rutina = await db.Rutinas.FindAsync(id);
            if (rutina == null)
            {
                return NotFound();
            }

            return Ok(rutina);
        }

        // PUT: api/Rutinas/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRutina(int id, Rutina rutina)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rutina.RutinaId)
            {
                return BadRequest();
            }

            db.Entry(rutina).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RutinaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Rutinas
        [ResponseType(typeof(Rutina))]
        public async Task<IHttpActionResult> PostRutina(Rutina rutina)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Rutinas.Add(rutina);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = rutina.RutinaId }, rutina);
        }

        // DELETE: api/Rutinas/5
        [ResponseType(typeof(Rutina))]
        public async Task<IHttpActionResult> DeleteRutina(int id)
        {
            Rutina rutina = await db.Rutinas.FindAsync(id);
            if (rutina == null)
            {
                return NotFound();
            }

            db.Rutinas.Remove(rutina);
            await db.SaveChangesAsync();

            return Ok(rutina);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RutinaExists(int id)
        {
            return db.Rutinas.Count(e => e.RutinaId == id) > 0;
        }
    }
}