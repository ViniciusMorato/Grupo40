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
    public class CartaoCreditoBusiness(ICredCardRepository credCardRepository) : ICredCardService
    {
        public CartaoCredito AddNewCredCard(CartaoCredito cartaoCredito)
        {
            throw new NotImplementedException();
        }

        public void DeleteCredCard(CartaoCredito cartaoCredito)
        {
            throw new NotImplementedException();
        }

        public CartaoCredito GetCredCardById(int id)
        {
            throw new NotImplementedException();
        }

        public List<CartaoCredito> GetCredCardByUser(int userId)
        {
            throw new NotImplementedException();
        }

        public CartaoCredito UpdateCredCard(CartaoCredito cartaoCredito)
        {
            throw new NotImplementedException();
        }
    }
}
