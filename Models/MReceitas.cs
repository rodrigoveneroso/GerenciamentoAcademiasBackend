using Academia.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Academia.Models
{
    public class MReceitas
    {
        [DisplayName("ID da receita")]
        [Key]
        public int Id_receita { get; set; }

        [DisplayName("Data da receita")]
        [Required(ErrorMessage = "A data da receita é obrigatória")]
        public DateOnly Data_receita { get; set; }

        [DisplayName("Descrição da receita")]
        [Required(ErrorMessage = "A descrição da receita é obrigatória")]
        [StringLength(150, ErrorMessage = "A descrição da receita deve conter até 150 caracteres")]
        public string Descricao_receita { get; set; }

        [DisplayName("Valor da receita")]
        [Required(ErrorMessage = "O valor da receita é obrigatório")]        
        public decimal Valor_receita { get; set; }



        [DisplayName("ID do aluno")]
        [Required(ErrorMessage = "O ID do aluno é obrigatório")]
        [ForeignKey("Id_aluno")]
        public int Id_aluno { get; set; }
    }
}
