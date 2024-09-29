using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace Academia.Enums
{
    public enum EStatus
    {
        [Description("Ativo")]
        Ativo = 1,

        [Description("Inativo")]
        Inativo = 2,
    }
}


