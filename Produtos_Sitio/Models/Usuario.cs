using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Produtos_Sitio.Models
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name ="ID Usuário")]
        public int id { get; set; }

        [StringLength(20)]
        [Required(ErrorMessage = "Campo 'Login' é obrigatório.")]
        [Display(Name = "Login")]
        public string login { get; set; }

        [StringLength(60)]
        [Required(ErrorMessage = "Campo 'Senha' é obrigatório.")]
        [Display(Name = "Senha")]
        public string password { get; set; }
    }
}
