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

        //TODO Get, GetId, Put Post
    }
}
