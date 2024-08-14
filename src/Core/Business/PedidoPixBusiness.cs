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
    public class PedidoPixBusiness(IOrderPixRepository orderPixRepository, IOrderRepository orderRepository) : IOrderPixService
    {
        public PedidoPix AddNewOrderPix(int pedidoId)
        {
            PedidoPix pedidoPix = new PedidoPix()
            {
                PedidoId = pedidoId,
                Pedido = orderRepository.GetOrderById(pedidoId)
            };

            if (pedidoPix.Pedido == null)
            {
                throw new ArgumentException("Pedido não encontrado");
            }

            if(pedidoPix.Pedido.FormaPagamento != Enums.EnumFormaPagamento.Pix)
            {
                throw new ArgumentException("A forma de pagamento do pedido não é pix");
            }

            PedidoPix pedidoPixExiste = orderPixRepository.GetOrderPixByOrder(pedidoPix.PedidoId);

            if(pedidoPixExiste != null)
            {
                return pedidoPixExiste;
            }
            else
            {
                pedidoPix.CodigoPix = this.GenPixCode(pedidoPix.Pedido.ValorTotal);

                pedidoPix = orderPixRepository.InsertUpdateOrderPix(pedidoPix);

                return pedidoPix;
            }
        }

        private string GenPixCode(decimal valorPedido)
        {
            string chavePix = "lanchonete@lanchonete.com";  // Insira sua chave Pix aqui (CPF, CNPJ, telefone, e-mail ou EVP)
            string nomeRecebedor = "LanchoneteLTD";  // Nome do recebedor
            string cidadeRecebedor = "SãoPaulo";  // Cidade do recebedor
            decimal valor = valorPedido;  // Valor da transação
            string identificadorTransacao = "12314113";  // Identificador da transação

            return GerarCodigoPix(chavePix, nomeRecebedor, cidadeRecebedor, valor, identificadorTransacao);
        }

        private string GerarCodigoPix(string chavePix, string nomeRecebedor, string cidadeRecebedor, decimal valor, string identificadorTransacao)
        {
            // Campos do QR Code Pix
            string payloadFormatIndicator = "000201";
            string merchantAccountInformation = "0014BR.GOV.BCB.PIX01" + chavePix.Length.ToString("D2") + chavePix;
            string merchantCategoryCode = "52040000";
            string transactionCurrency = "5303986";
            string transactionAmount = valor > 0 ? "54" + valor.ToString("0.00").Replace(".", "") : "";
            string countryCode = "5802BR";
            string merchantName = "59" + nomeRecebedor.Length.ToString("D2") + nomeRecebedor;
            string merchantCity = "60" + cidadeRecebedor.Length.ToString("D2") + cidadeRecebedor;
            string additionalDataFieldTemplate = "62160505" + identificadorTransacao.Length.ToString("D2") + identificadorTransacao;

            // Montagem do código Pix
            string pixCode = payloadFormatIndicator +
                             merchantAccountInformation +
                             merchantCategoryCode +
                             transactionCurrency +
                             transactionAmount +
                             countryCode +
                             merchantName +
                             merchantCity +
                             additionalDataFieldTemplate;

            // Cálculo do CRC16 (Checksum)
            string crc16 = CalcularCRC16(pixCode + "6304");
            pixCode += "6304" + crc16;

            return pixCode;
        }

        private string CalcularCRC16(string input)
        {
            ushort polynomial = 0x1021;
            ushort crc = 0xFFFF;
            byte[] bytes = Encoding.ASCII.GetBytes(input);

            foreach (byte b in bytes)
            {
                crc ^= (ushort)(b << 8);

                for (int i = 0; i < 8; i++)
                {
                    if ((crc & 0x8000) != 0)
                    {
                        crc = (ushort)((crc << 1) ^ polynomial);
                    }
                    else
                    {
                        crc <<= 1;
                    }
                }
            }

            return crc.ToString("X4");
        }

        public void DeleteOrderPix(PedidoPix pedidoPix)
        {
            orderPixRepository.DeleteOrderPix(pedidoPix);
        }

        public PedidoPix GetOrderPixById(int id)
        {
            PedidoPix pedidoPix = orderPixRepository.GetOrderPixById(id);

            if (pedidoPix == null)
            {
                throw new ArgumentException("Pix do pedido não encontrado");
            }

            return pedidoPix;
        }

        public PedidoPix GetOrderPixByOrder(int pedidoId)
        {
            PedidoPix pedidoPix = orderPixRepository.GetOrderPixByOrder(pedidoId);

            if (pedidoPix == null)
            {
                throw new ArgumentException("Pix do pedido não encontrado");
            }

            return pedidoPix;
        }

        public PedidoPix UpdateOrderPix(PedidoPix pedidoPix)
        {
            throw new NotImplementedException();
        }
    }
}
