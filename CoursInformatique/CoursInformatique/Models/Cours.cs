using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoursInformatique.Models
{
    [Table("Cours")]
	public class Cours
	{
        public int Id { get; set; }

        [Required(ErrorMessage = "Le Titre du cours doit être Informé.")]
        [MaxLength(100, ErrorMessage = "Le titre du cours ne peut contenir que 100 caractères.")]
        public string Titre { get; set; }

        [Required(ErrorMessage = "L'Url du cours doit être complétée.")]
        [Url(ErrorMessage = "L'Url du cours doit contenir une adresse valide.")]
        public string Url { get; set; }

        [Required(ErrorMessage = "Le Canal du cours doit être Informé.")]
        //[JsonConverter(typeof(StringEnumConverter))]
        public Canal Canal { get; set; }

        [Required(ErrorMessage = "La date de publication du cours doit être complétée.")]
        public DateTime DatePublication { get; set; }

        [Required(ErrorMessage = "La charge de cours doit être complétée.")]
        [Range(1, Int32.MaxValue, ErrorMessage = "La charge doit durer au moins 1h")]
        public int ChargeCours { get; set; }
    }
}