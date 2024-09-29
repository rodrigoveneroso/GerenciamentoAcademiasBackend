using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace Academia.Enums
{
    // Define o enum para os cargos de funcionarios
    public enum ECargos_funcionario    
    {
        [Description("Gerente")]
        Gerente = 1,

        [Description("Recepcionista")]
        Recepcionista = 2,

        [Description("Professor")]
        Professor = 3,

        [Description("Limpeza")]
        Limpeza = 2
    }
}


