using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public sealed class ItemPedido
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int IdPedido { get; set; }
        [Required]
        public int IdProduto { get; set; }
        [Required]
        public int Quantidade { get; set; }
        [Required]
        public decimal ValorUnitario { get; set; }
        public string Observacao { get; set; }
    }
}
