namespace Core.Entities
{
    public sealed class ItemPedido
    {
        public Pedido Pedido { get; set; }
        public Produto Produto { get; set; }
        public int quantidade { get; set; }
    }
}
