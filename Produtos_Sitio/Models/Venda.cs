using Produtos_Sitio.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Produtos_Sitio.Models
{
    [Table("Vendas")]
    public class Venda
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Cod. Venda")]
        public int id { get; set; }

        [Display(Name = "Cliente")]
        public Cliente cliente { get; set; }
        [Display(Name = "Cliente")]
        public int clienteid { get; set; }

        [Display(Name = "Produto")]
        public Produto produto { get; set; }
        [Display(Name = "Produto")]
        public int produtoid { get; set; }

        /*[StringLength(40)]
        [Required(ErrorMessage = "Campo 'Cod. Entrega' é obrigatório.")]
        [Display(Name = "Cod. Entrega")]
        public Entrega entrega { get; set; }*/

        [Required(ErrorMessage = "Campo 'Data' é obrigatório.")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Data")]
        public DateTime data { get; set; }

        [Required(ErrorMessage = "Campo 'Quantidade' é obrigatório.")]
        [Display(Name = "Quantidade")]
        public float quantidade { get; set; }

        [Required(ErrorMessage = "Campo 'Total' é obrigatório.")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [Display(Name = "Total")]
        public float Total { get; set; }
    }
}
