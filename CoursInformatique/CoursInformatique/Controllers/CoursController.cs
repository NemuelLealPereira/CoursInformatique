using CoursInformatique.Models;
using System.Web.Http;

namespace CoursInformatique.Controllers
{
    public class CoursController : ApiController
    {
        private CoursInformatiqueContext db = new CoursInformatiqueContext();

        public IHttpActionResult GetCours(int Id)
        {
            if (Id < 0)
                return BadRequest("Le Id doit être supérieur à zero"); /*400*/

            var curso = db.Cours.Find(Id);

            if (curso == null)
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

        //TODO GetAll, Put
    }
}
