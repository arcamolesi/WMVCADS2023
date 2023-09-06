using Microsoft.Extensions.WebEncoders.Testing;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMVCADS2023.Models
{
    enum Periodo { Diurno, Vespertino, Noturno }
    


    [Table("Alunos")]
    public class Aluno
    {
        [Key]
        [Display(Name = "ID")]
        public int id { get; set; }

        [Required(ErrorMessage = "Campo nome é obrigatório.")]
        [StringLength(35)]
        [Display(Name = "Nome")]
        public string nome { get; set; }

        [Required(ErrorMessage = "Campo aniversário é obrigatório.")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Aniversário")]
        public DateTime aniversario { get; set; }

        [Required(ErrorMessage = "Campo email é obrigatório.")]
        [DataType(DataType.EmailAddress,ErrorMessage = "email invalido")]
        [Display(Name = "Email")]
        public string email { get; set; }

        [Display(Name = "Curso")]
        public int cursoID { get; set; }
        [ForeignKey("cursoID")]
        public Curso curso { get; set; }

        [Required(ErrorMessage = "Campo periodo é obrigatório.")]
        [Display(Name = "Período")]
        public int periodo { get; set; }


        

       

    }

}
