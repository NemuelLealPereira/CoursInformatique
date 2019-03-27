using CoursInformatique.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;

namespace CoursInformatique.Controllers
{
    public class CoursController : ApiController
    {
        private CoursInformatiqueContext db = new CoursInformatiqueContext();

        public IHttpActionResult GetCours(int id)
        {
            if (id <= 0)
                return BadRequest("Le Id doit être supérieur à zero"); /*400*/

            var curso = db.Cours.Find(id);

            if (curso is null)
                return NotFound(); /*404*/

            return Ok(curso); /*200*/
        }

        /// <summary>
        ///{
        ///   "Id": 1,
        ///   "Titre": "Primeiros Passos CSharp",
        ///   "Url": "https://fr.wikipedia.org/wiki/C_sharp",
        ///   "Canal": 5,
        ///   "DatePublication": "2019-03-25T00:00:00",
        ///   "ChargeCours": 1
        ///}
        /// </summary>
        /// <param name="cours"></param>
        /// <returns></returns>
        public IHttpActionResult PostCours(Cours cours)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState); /*400*/

            db.Cours.Add(cours);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cours.Id }, cours); /*201*/
        }

        public IHttpActionResult DeleteCours(int id)
        {
            if (id <= 0)
                return BadRequest("Le Id doit être supérieur à zero"); /*400*/

            var cours = db.Cours.Find(id);

            if (cours is null)
                return NotFound(); /*404*/

            db.Cours.Remove(cours);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent); /*204*/
        }

        public IHttpActionResult PutCours(int id, Cours cours)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState); /*400*/

            if (id <= 0)
                return BadRequest("Le Id doit être supérieur à zero"); /*400*/

            if (id != cours.Id)
                return BadRequest("L'id entré dans l'URL est différent de l'Id inscrit dans le corps de la requête."); /*400*/

            if (db.Cours.Count(c => c.Id.Equals(id)) == 0)
                return NotFound(); /*404*/

            db.Entry(cours).State = EntityState.Modified;
            db.SaveChanges();

            HttpContext.Current.Response.AddHeader("X-cours-Modifie", Url.Link("DefaultApi", new { id = cours.Id }));

            return StatusCode(HttpStatusCode.NoContent); /*204*/
        }

        //TODO GetAll, Put
    }
}
