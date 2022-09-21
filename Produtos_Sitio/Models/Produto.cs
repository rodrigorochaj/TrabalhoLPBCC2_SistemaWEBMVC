using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Produtos_Sitio.Models
{
    [Table("Produtos")]
    public class Produto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID Produto")]
        public int id { get; set; }

        [StringLength(40)]
        [Required(ErrorMessage = "Campo 'Descrição' é obrigatório.")]
        [Display(Name = "Descrição")]
        public string descricao { get; set; }

        [Required(ErrorMessage = "Campo 'Peso' é obrigatório.")]
        [Display(Name = "Peso")]
        public float peso { get; set; }

        [Required(ErrorMessage = "Campo 'Valor' é obrigatório.")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [Display(Name = "Valor")]
        public float valor { get; set; }
    }
}
