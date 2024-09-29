using Academia.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Academia.Models
{
    public class MDespesas
    {
        [DisplayName("ID da despesa")]
        [Key]
        public int Id_despesa { get; set; }

        [DisplayName("Data da despesa")]
        [Required(ErrorMessage = "A data da despesa é obrigatória")]
        public DateOnly Data_despesa { get; set; }

        [DisplayName("Descrição da despesa")]
        [Required(ErrorMessage = "A descrição da despesa é obrigatória")]
        [StringLength(150, ErrorMessage = "A descrição da aula deve conter até 150 caracteres")]
        public string Descricao_despesa { get; set; }

        [DisplayName("Valor da despesa")]
        [Required(ErrorMessage = "O valor da despesa é obrigatório")]
        public decimal Valor_despesa { get; set; }



        [DisplayName("ID do funcionário")]
        [ForeignKey("Id_funcionario")]
        public int? Id_funcionario { get; set; }
    }
}
