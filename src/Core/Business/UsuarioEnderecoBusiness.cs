using Core.Interfaces.Services;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business
{
    public class UsuarioEnderecoBusiness(IUserAddressService userAddressService) : IUserAddressService
    {
        public UsuarioEnderecoBusiness AddNewUserAddress(UsuarioEnderecoBusiness usuarioEndereco)
        {
            throw new NotImplementedException();
        }

        public UsuarioEndereco AddNewUserAddress(UsuarioEndereco usuarioEndereco)
        {
            throw new NotImplementedException();
        }

        public void DeleteUserAddress(int id)
        {
            throw new NotImplementedException();
        }

        public UsuarioEndereco? GetUserAddressById(int id)
        {
            throw new NotImplementedException();
        }

        public List<UsuarioEndereco> GetUserAddressByUserId(int idUsuario)
        {
            throw new NotImplementedException();
        }

        public void UpdateUserAddress(UsuarioEndereco usuarioEndereco)
        {
            throw new NotImplementedException();
        }
    }
}
