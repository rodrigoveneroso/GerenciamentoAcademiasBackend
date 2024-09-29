using Academia.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Academia.Models
{
    public class MAlunos
    {
        [DisplayName("ID do aluno")]
        [Key]
        public int Id_aluno { get; set; }

        [DisplayName("CPF do aluno")]
        [Required(ErrorMessage = "O CPF do aluno é obrigatorio")]
        [StringLength(14, MinimumLength = 11, ErrorMessage = "O CPF do aluno deve conter entre 11 e 14 caracteres")]
        public string CPF_aluno { get; set; }

        [DisplayName("Data de nascimento do aluno")]
        [Required(ErrorMessage = "A data de nascimento do aluno é obrigatória")]
        public DateOnly Data_nascimento_aluno { get; set; }

        [DisplayName("Status do aluno")]
        [Required(ErrorMessage = "O status do aluno é obrigatório")]
        public EStatus Status { get; set; }

        [DisplayName("Telefone do aluno")]
        [Required(ErrorMessage = "O telefone do aluno é obrigatório")]
        [StringLength(20, ErrorMessage = "O telefone do aluno deve conter até 20 caracteres")]
        public string Telefone_aluno { get; set; }

        [DisplayName("E-Mail do aluno")]
        [Required(ErrorMessage = "O e-mail do aluno é obrigatório")]
        [StringLength(150, MinimumLength = 12, ErrorMessage = "O e-mail do aluno deve conter entre 12 e 150 caracteres")]
        public string Email_aluno { get; set;}

        [DisplayName("Nome do aluno")]
        [Required(ErrorMessage = "O nome do aluno é obrigatório")]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "O nome do aluno deve conter entre 3 e 150 caracteres")]
        public string Nome_aluno { get; set;}



        [DisplayName("Endereço do aluno")]
        [ForeignKey("Id_endereco")]
        public int? Id_endereco { get; set; }

        [DisplayName("Aula marcada")]
        [ForeignKey("Id_aula")]
        public int? Id_aula {  get; set; }

        [DisplayName("Contrato do aluno")]
        [ForeignKey("Id_contrato")]
        public int? Id_contrato { get; set; }
    }
}

