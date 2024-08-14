using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business
{
    public class CartaoCreditoBusiness(ICredCardRepository credCardRepository, IUserRepository userRepository) : ICredCardService
    {
        public CartaoCredito AddNewCredCard(CartaoCredito cartaoCredito)
        {
            if (!this.ValidateCreditCard(cartaoCredito.Numero))
            {
                throw new ArgumentException("Cartão de credito invalido");
            }

            if (userRepository.GetUserById(cartaoCredito.PessoaId) == null)
            {
                throw new ArgumentException("Usuario não encontrado");
            }

            if (cartaoCredito.CVV.Length != 3)
            {
                throw new ArgumentException("CVV invalido");
            }

            if (cartaoCredito.Vencimento.Length < 5 || (int.Parse(cartaoCredito.Vencimento.Split("/")[0]) <= 0 || int.Parse(cartaoCredito.Vencimento.Split("/")[0]) > 12) || int.Parse(cartaoCredito.Vencimento.Split("/")[1]) < int.Parse(DateTime.Now.ToString("yy")))
            {
                throw new ArgumentException("Vencimento invalido!");
            }

            if (int.Parse(cartaoCredito.Vencimento.Split("/")[1]) == int.Parse(DateTime.Now.ToString("yy")) && int.Parse(cartaoCredito.Vencimento.Split("/")[0]) <= DateTime.Now.Month)
            {
                throw new ArgumentException("O cartão se encontra vencido");
            }

            CartaoCredito cartaoExiste = credCardRepository.GetCredCardByUserAndNumber(cartaoCredito.PessoaId, cartaoCredito.Numero);

            if (cartaoExiste != null)
            {
                throw new ArgumentException("Cartão de credito já cadastrado");
            }

            cartaoCredito = credCardRepository.InsertUpdateCredCard(cartaoCredito);

            return cartaoCredito;
        }

        public void DeleteCredCard(int cartaoCreditoId)
        {
            CartaoCredito cartaoCredito = credCardRepository.GetCredCardById(cartaoCreditoId);
            if (cartaoCredito == null)
            {
                throw new ArgumentException("Cartão de credito não encontrado");
            }

            credCardRepository.DeleteCredCard(cartaoCredito);
        }

        public CartaoCredito GetCredCardById(int id)
        {
            return credCardRepository.GetCredCardById(id);
        }

        public List<CartaoCredito> GetCredCardByUser(int userId)
        {
            if (userId <= 0 || userRepository.GetUserById(userId) == null)
            {
                throw new ArgumentException("Usuario não encontrado");
            }

            return credCardRepository.GetCredCardByUser(userId);
        }

        public CartaoCredito UpdateCredCard(CartaoCredito cartaoCredito)
        {
            throw new NotImplementedException();
        }

        private bool ValidateCreditCard(string cardNumber)
        {
            // Remove espaços em branco e verifica se todos os caracteres são dígitos
            cardNumber = cardNumber.Replace(" ", "");
            if (!cardNumber.All(char.IsDigit))
                return false;

            int sum = 0;
            bool alternate = false;

            // Itera sobre o número do cartão de trás para frente
            for (int i = cardNumber.Length - 1; i >= 0; i--)
            {
                int n = int.Parse(cardNumber[i].ToString());

                if (alternate)
                {
                    n *= 2;
                    if (n > 9)
                    {
                        n -= 9;
                    }
                }

                sum += n;
                alternate = !alternate;
            }

            // O número de cartão é válido se a soma for múltipla de 10
            return (sum % 10 == 0);
        }
    }
}
