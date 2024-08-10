using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public sealed class Produto
    {
        [Key] public int Id { get; private set; }
        [Required] [MaxLength(100)] public string Descricao { get; private set; }
        [Required] public decimal Preco { get; private set; }
        [Required] public int Estoque { get; private set; }

        public void Validade()
        {
            ValidadeDescricao();
            ValidadePreco();
            ValidadeEstoque();
        }

        private void ValidadeDescricao()
        {
            Descricao = Descricao.Trim();
            if (string.IsNullOrEmpty(Descricao))
            {
                throw new ArgumentException("Descrição não pode ser vazio");
            }
        }

        private void ValidadePreco()
        {
            if (Preco <= 0)
            {
                throw new ArgumentException("Preço não pode ser negativo ou igual a zero");
            }
        }

        private void ValidadeEstoque()
        {
            if (Estoque < 0)
            {
                throw new ArgumentException("Estoque não pode ser negativo");
            }
        }
    }
}