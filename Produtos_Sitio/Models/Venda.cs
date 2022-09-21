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
        [Display(Name = "ID Venda")]
        public int id { get; set; }

        [StringLength(40)]
        [Required(ErrorMessage = "Campo 'Cliente' é obrigatório.")]
        [Display(Name = "Cliente")]
        public Cliente cliente { get; set; }

        [StringLength(40)]
        [Required(ErrorMessage = "Campo 'Produto' é obrigatório.")]
        [Display(Name = "Produto")]
        public Produto produto { get; set; }

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

        public ICollection<Entrega> entrega { get; set; }
    }
}
