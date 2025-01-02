using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASPMVC_Demo01.Models
{
    public class Demo07Form
    {
        [DisplayName("Prénom : ")]
        [Required(ErrorMessage = "Le Prénom est obligatoire.")]
        [MinLength(2, ErrorMessage = "Le Prénom doit avoir au minimum 2 caractères.")]
        [MaxLength(64, ErrorMessage = "Le Prénom doit avoir au maximum 64 caractères.")]
        public string FirstName { get; set; }
        [DisplayName("Nom de famille : ")]
        [Required(ErrorMessage = "Le Nom de famille est obligatoire.")]
        [MinLength(2, ErrorMessage = "Le Nom de famille doit avoir au minimum 2 caractères.")]
        [MaxLength(64, ErrorMessage = "Le Nom de famille doit avoir au maximum 64 caractères.")]
        public string LastName { get; set; }
        [DisplayName("Date de naissance : ")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "La Date de naissance est obligatoire.")]
        public DateOnly BirthDate { get; set; }
        [DisplayName("A-t-il le permis ?")]
        public bool HaveLicence { get; set; }
        [DisplayName("Veuillez choisir votre modèle attendu : ")]
        [Required(ErrorMessage = "Le Modèle de voiture est obligatoire.")]
        public CarModel CarModel { get; set; }
    }
}