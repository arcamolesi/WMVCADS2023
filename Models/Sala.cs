using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMVCADS2023.Models
{
    [Table("Salas")]
    public class Sala
    {
        [Key]
        public int id { get; set; }

        [Required]
        [StringLength(25)]
        public string descricao { get; set; }

        [StringLength(30)]
        public string monitor { get; set; }


        public int equipamentos { get; set; }
        public char situacao { get; set; }





    }
}
