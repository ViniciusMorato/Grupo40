using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Services
{
    public interface IUserAddressService
    {
        UsuarioEndereco AddNewUserAddress(UsuarioEndereco usuarioEndereco);
        UsuarioEndereco? GetUserAddressById(int id);
        List<UsuarioEndereco> GetUserAddressByUserId(int idUsuario);
        void UpdateUserAddress(UsuarioEndereco usuarioEndereco);
        void DeleteUserAddress(int id);
        public bool CheckAddressExists(UsuarioEndereco usuarioEndereco);
    }
}
