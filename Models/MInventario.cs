using Academia.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Academia.Models
{
    public class MInventario
    {
        [DisplayName("ID do item do inventário")]
        [Key]
        public int Id_item_inventario { get; set; }

        [DisplayName("Quantidade do item")]
        [Required(ErrorMessage = "A quantidade do item é obrigatória")]
        public int Quantidade_item_inventario { get; set; }

        [DisplayName("Descrição do item")]
        [Required(ErrorMessage = "A descrição do item é obrigatória")]
        [StringLength(150, ErrorMessage = "A descrição do item deve conter até 150 caracteres")]
        public string Descricao_item_inventario { get; set;}
    }
}
