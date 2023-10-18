using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WMVCADS2023.Migrations;
using System.Reflection.Metadata.Ecma335;

namespace WMVCADS2023.Models
{

    public enum Situacao { Livre, Ocupado, Reservado, Manutencao, Outras }

    [Table("Salas")]
    public class Sala
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID")]
        public int id { get; set; }

        [Required(ErrorMessage = "Campo descrição é obrigatório.")]
        [StringLength(35)]
        [Display(Name = "Descrição")]
        public string descricao { get; set; }

        [Required(ErrorMessage = "Campo monitor é obrigatório.")]
        [StringLength(30)]
        [Display(Name = "Instrutor")]
        public string monitor { get; set; }

        [Required(ErrorMessage = "Campo equipamentos é obrigatório.")]
        [Display(Name = "Equipamentos")]
        public int equipamentos { get; set; }

        [Required(ErrorMessage = "Campo situação é obrigatório.")]
        [Display(Name = "Situação")]
        public Situacao situacao { get; set; }


        [Display(Name = "Atualizado")]
        [NotMapped]
        virtual public int atualizado
        {
            get {
                int valor= equipamentos;
                if (situacao == Situacao.Ocupado)
                    valor = valor + 10;
                else if (situacao == Situacao.Reservado)
                    valor += 20;
                else if (situacao == Situacao.Outras)
                    valor += 30; 
                return valor;
            }
        }

        [Display(Name = "Media Equipamentos")]
        [DisplayFormat(DataFormatString = "{0:0,0.00}")]
        [NotMapped]
        virtual public float mediaEquip
        {
            get { return (float)(equipamentos + atualizado) / 2; }
        }

    }
}
