namespace Core.Negocio.Model
{
    public class ItemPedidoModel
    {
        public PedidoModel PedidoModel { get; set; }
        public ProdutoModel ProdutoModel { get; set; }
        public int quantidade { get; set; }
    }
}
