using Academia.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Academia.Models
{
    public class MPlanos
    {
        [DisplayName("ID do plano")]
        [Key]
        public int Id_plano { get; set; }

        [DisplayName("Descrição do plano")]
        [Required(ErrorMessage = "A descrição do plano é obrigatória")]
        [StringLength(150, ErrorMessage = "A descrição do plano deve conter até 150 caracteres")]
        public string Descricao_plano { get; set; }

        [DisplayName("Valor do plano")]
        [Required(ErrorMessage = "O valor do plano é obrigatório")]
        public decimal Valor_plano { get; set; }

        [DisplayName("Duração do plano (em dias)")]
        [Required(ErrorMessage = "A duração do plano (em dias) é obrigatória")]
        public int Dias_plano { get; set; }
    }
}
