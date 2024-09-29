using Academia.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Academia.Models
{
    public class MAulas
    {
        [DisplayName("ID da aula")]
        [Key]
        public int Id_aula { get; set; }

        [DisplayName("Descrição da aula")]
        [Required(ErrorMessage = "A descrição da aula é obrigatória")]
        [StringLength(150, ErrorMessage = "A descrição da aula deve conter até 150 caracteres")]
        public string Descricao_aula { get; set; }

        [DisplayName("Data da aula")]
        [Required(ErrorMessage = "A data da aula é obrigatória")]
        public DateOnly Data_aula { get; set; }


        [DisplayName("ID do funcionario")]
        [Required(ErrorMessage = "O ID do funcionario é obrigatório")]
        [ForeignKey("Id_funcionario")]
        public int Id_funcionario { get; set; }

        [DisplayName("ID do aluno")]
        [ForeignKey("Id_aluno")]
        public int? Id_aluno { get; set; }
    }
}
