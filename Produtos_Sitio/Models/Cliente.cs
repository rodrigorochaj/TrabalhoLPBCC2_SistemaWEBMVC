using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Produtos_Sitio.Models
{
    [Table("Clientes")]
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Cod. Cliente")]
        public int id { get; set; }

        [StringLength(40)]
        [Required(ErrorMessage = "Campo 'Nome' é obrigatório.")]
        [Display(Name = "Nome")]
        public string nome { get; set; }

        [Required(ErrorMessage = "Campo 'Telefone' é obrigatório.")]
        [Display(Name = "Telefone")]
        public string telefone { get; set; }

        [StringLength(60)]
        [Required(ErrorMessage = "Campo 'Endereço' é obrigatório.")]
        [Display(Name = "Endereço")]
        public string endereco { get; set; }

        public ICollection<Venda> vendas { get; set; }
    }
}
