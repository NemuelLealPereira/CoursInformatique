using System.Data.Entity;

namespace CoursInformatique.Models
{
    public class CoursInformatiqueContext : DbContext
    {
        public CoursInformatiqueContext() : base("CoursInformatique")
        {
        }

        public DbSet<Cours> Cours { get; set; }
    }
}