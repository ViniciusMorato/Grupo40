using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositories
{
    public interface ICredCardRepository
    {
        public CartaoCredito InsertUpdateCredCard(CartaoCredito credCard);
        public CartaoCredito GetCredCardById(int id);
        public List<CartaoCredito> GetCredCardByUser(int usuarioId);
        public CartaoCredito GetCredCardByUserAndNumber(int usuarioId, string numero);
        public void DeleteCredCard(CartaoCredito credCard);
    }
}
