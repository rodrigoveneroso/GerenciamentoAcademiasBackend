using Academia.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Academia.Models
{
    public class MEnderecos
    {
        [DisplayName("ID do endereço")]
        [Key]
        public int Id_endereco { get; set; }

        [DisplayName("Rua")]
        [Required(ErrorMessage = "A rua é obrigatória")]
        [StringLength(150, MinimumLength = 5, ErrorMessage = "A rua deve conter entre 5 e 150 caracteres")]
        public string Rua_endereco { get; set; }

        [DisplayName("CEP")]
        [Required(ErrorMessage = "O CEP é obrigatório")]
        [StringLength(9, MinimumLength = 8, ErrorMessage = "O CEP deve conter entre 8 e 9 caracteres")]
        public string CEP_endereco { get; set; }

        [DisplayName("Número")]
        [Required(ErrorMessage = "O número é obrigatório")]
        [StringLength(5, MinimumLength = 1, ErrorMessage = "O número deve conter entre 1 e 5 caracteres")]
        public string Numero_endereco { get; set; }

        [DisplayName("Bairro")]
        [Required(ErrorMessage = "O bairro é obrigatório")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "O bairro deve conter entre 3 e 50 caracteres")]
        public string Bairro_endereco { get; set; }

        [DisplayName("Conmplemento")]
        public string Complemento_endereco { get; set; }

        [DisplayName("Bairro")]
        [Required(ErrorMessage = "O bairro é obrigatório")]
        [StringLength(50, ErrorMessage = "A cidade deve conter até 50 caracteres")]
        public string Cidade_endereco { get; set; }



        [DisplayName("ID do funcionário")]
        [ForeignKey("Id_funcionario")]
        public int? Id_funcionario { get; set; }

        [DisplayName("ID do aluno")]
        [ForeignKey("id_aluno")]
        public int? Id_aluno { get; set; }
    }
}
