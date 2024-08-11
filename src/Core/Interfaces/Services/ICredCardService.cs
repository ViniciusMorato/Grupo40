using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Services
{
    public interface ICredCardService
    {
        public CartaoCredito AddNewCredCard(CartaoCredito cartaoCredito);
        public CartaoCredito UpdateCredCard(CartaoCredito cartaoCredito);
        public void DeleteCredCard(CartaoCredito cartaoCredito);
        public CartaoCredito GetCredCardById(int id);
        public List<CartaoCredito> GetCredCardByUser(int  userId);
    }
}
