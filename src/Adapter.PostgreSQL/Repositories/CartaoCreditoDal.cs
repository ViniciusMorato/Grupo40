using Adapter.PostgreSQL.Context;
using Core.Entities;
using Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter.PostgreSQL.Repositories
{
    public class CartaoCreditoDal : ICredCardRepository
    {
        private readonly PostgreSqlContext _context;

        public CartaoCreditoDal(PostgreSqlContext context)
        {
            _context = context;
        }

        public void DeleteCredCard(CartaoCredito credCard)
        {
            _context.CartaoCredito.Remove(credCard);
            _context.SaveChanges();
        }

        public CartaoCredito GetCredCardById(int id)
        {
            return _context.CartaoCredito.FirstOrDefault(cc => cc.Id == id);
        }

        public List<CartaoCredito> GetCredCardByUser(int usuarioId)
        {
            return _context.CartaoCredito.Where(cc => cc.PessoaId == usuarioId).ToList();
        }

        public CartaoCredito InsertUpdateCredCard(CartaoCredito credCard)
        {
            if(credCard.Id == 0)
            {
                _context.CartaoCredito.Add(credCard);
            }
            _context.SaveChanges();
            return credCard;
        }
    }
}
