using Academia.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Academia.Models
{
    public class MFuncionarios
    {
        [DisplayName("ID do funcionário")]
        [Key]
        public int Id_funcionario { get; set; }

        [DisplayName("CPF do funcionário")]
        [Required(ErrorMessage = "O CPF do funcionário é obrigatorio")]
        [StringLength(14, MinimumLength = 11, ErrorMessage = "O CPF do funcionário deve conter entre 11 e 14 caracteres")]
        public string CPF_funcionario { get; set; }

        [DisplayName("Data de nascimento do funcionário")]
        [Required(ErrorMessage = "A data de nascimento do funcionário é obrigatória")]
        public DateOnly Data_nascimento_funcionario { get; set; }

        [DisplayName("Status do funcionário")]
        [Required(ErrorMessage = "O status do funcionário é obrigatório")]
        public EStatus Status { get; set; }

        [DisplayName("Telefone do funcionário")]
        [Required(ErrorMessage = "O telefone do funcionário é obrigatório")]
        [StringLength(20, ErrorMessage = "O telefone do funcionário deve conter até 20 caracteres")]
        public string Telefone_funcionario { get; set; }

        [DisplayName("Salário do funcionário")]
        [Required(ErrorMessage = "O salário do funcionário é obrigatório")]
        public decimal Salario_funcionario { get; set; }

        [DisplayName("E-Mail do funcionário")]
        [Required(ErrorMessage = "O e-mail do funcionário é obrigatório")]
        [StringLength(150, MinimumLength = 12, ErrorMessage = "O e-mail do funcionário deve conter entre 12 e 150 caracteres")]
        public string Email_funcionario { get; set; }

        [DisplayName("Nome do funcionário")]
        [Required(ErrorMessage = "O nome do funcionário é obrigatório")]
        public string Nome_funcionario { get; set; }

        [DisplayName("Cargo do funcionário")]
        [Required(ErrorMessage = "O cargo do funcionário é obrigatório")]
        public ECargos_funcionario Cargo_Funcionario { get; set; }



        [DisplayName("Endereço do funcionário")]
        [ForeignKey("Id_endereco")]
        public int? Id_endereco { get; set; }

        [DisplayName("ID da despesa")]
        [ForeignKey("Id_despesas")]
        public int? Id_despesas { get; set; }

        [DisplayName("ID da aula")]
        [ForeignKey("Id_aula")]
        public int? Id_aula { get; set; }
    }
}
