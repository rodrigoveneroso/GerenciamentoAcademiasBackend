using Academia.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Academia.Models
{
    public class MContratos
    {
        [DisplayName("ID do contrato")]
        [Key]
        public int Id_contrato { get; set; }

        [DisplayName("Data de pagamento")]
        [Required(ErrorMessage = "A data de pagamento é obrigatória")]
        public DateOnly Data_pagamento { get; set; }

        [DisplayName("Data de início de contrato")]
        [Required(ErrorMessage = "A data de início de contrato é obrigatória")]
        public DateOnly Data_inicio_contrato { get; set; }



        [DisplayName("ID do aluno")]
        [Required(ErrorMessage = "O ID do aluno é obrigatório")]
        [ForeignKey("Id_aluno")]
        public int Id_aluno { get; set; }

        [DisplayName("ID do funcionário")]
        [Required(ErrorMessage = "O ID do aluno é funcionário")]
        [ForeignKey("Id_funcionario")]
        public int Id_funcionario { get; set; }

        [DisplayName("ID do plano")]
        [Required(ErrorMessage = "O ID do aluno é plano")]
        public int Id_plano { get; set; }

        [DisplayName("ID da receita")]
        [ForeignKey("Id_receita")]
        public int Id_receita { get; set; }

        public static implicit operator List<object>(MContratos v)
        {
            throw new NotImplementedException();
        }
    }
}
