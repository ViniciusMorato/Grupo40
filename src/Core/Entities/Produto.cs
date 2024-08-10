using System.ComponentModel.DataAnnotations;
using Core.Enums;

namespace Core.Entities
{
    public sealed class Produto
    {
        [Key] public int Id { get; private set; }
        [Required] [MaxLength(100)] public string Descricao { get; private set; }
        [Required] public decimal Preco { get; private set; }
        [Required] public int Estoque { get; private set; }
        [Required] public Category Categoria { get; private set; }


        public void Validade()
        {
            ValidadeDescricao();
            ValidadePreco();
            ValidadeEstoque();
            ValidadeCategoria();
        }

        private void ValidadeCategoria()
        {
            if (!Enum.IsDefined(typeof(Category), Categoria))
            {
                throw new ArgumentException("Categoria de produto inválida");
            }
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