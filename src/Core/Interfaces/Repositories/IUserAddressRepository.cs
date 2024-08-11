using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositories
{
    public interface IUserAddressRepository
    {
        public UsuarioEndereco InsertUpdateUserAddress(UsuarioEndereco usuarioEndereco);
        public void DeleteUserAddressById(UsuarioEndereco usuarioEndereco);
        public UsuarioEndereco? GetUserAddressById(int id);
        public List<UsuarioEndereco>? GetUserAddressByUser(int idUsuario);
        public bool CheckAddressExists(UsuarioEndereco usuarioEndereco);

    }
}
