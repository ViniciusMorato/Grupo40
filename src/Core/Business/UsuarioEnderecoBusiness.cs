using Core.Interfaces.Services;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Interfaces.Repositories;

namespace Core.Business
{
    public class UsuarioEnderecoBusiness(IUserAddressRepository userAddressRepository) : IUserAddressService
    {
        public UsuarioEnderecoBusiness AddNewUserAddress(UsuarioEnderecoBusiness usuarioEndereco)
        {
            throw new NotImplementedException();
        }

        public UsuarioEndereco AddNewUserAddress(UsuarioEndereco usuarioEndereco)
        {
            if (userAddressRepository.CheckAddressExists(usuarioEndereco))
                throw new ArgumentException("");

            userAddressRepository.InsertUpdateUserAddress(usuarioEndereco);

            return usuarioEndereco;
        }

        public bool CheckAddressExists(UsuarioEndereco usuarioEndereco)
        {
            return userAddressRepository.CheckAddressExists(usuarioEndereco);
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
            return userAddressRepository.GetUserAddressByUser(idUsuario).ToList();
        }

        public void UpdateUserAddress(UsuarioEndereco usuarioEndereco)
        {
            throw new NotImplementedException();
        }
    }
}
