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
    public class UsuarioEnderecoDal : IUserAddressRepository
    {
        private readonly PostgreSqlContext _context;

        public UsuarioEnderecoDal(PostgreSqlContext context)
        {
            _context = context;
        }

        public UsuarioEndereco InsertUpdateUserAddress(UsuarioEndereco usuarioEndereco)
        {
            if(usuarioEndereco.Id == 0)
            {
                _context.UsuarioEndereco.Add(usuarioEndereco);
            }
            _context.SaveChanges();

            return usuarioEndereco;
        }

        public bool CheckAddressExists(UsuarioEndereco usuarioEndereco)
        {
            return _context.UsuarioEndereco.Where(ue => ue.Rua == usuarioEndereco.Rua && ue.Bairro == usuarioEndereco.Bairro && ue.Numero == usuarioEndereco.Numero && ue.Complemento == usuarioEndereco.Complemento).Count() > 0;
        }

        public void DeleteUserAddressById(UsuarioEndereco usuarioEndereco)
        {
            _context.UsuarioEndereco.Remove(usuarioEndereco);
            _context.SaveChanges();
        }

        public UsuarioEndereco? GetUserAddressById(int id)
        {
            return _context.UsuarioEndereco.FirstOrDefault(ue => ue.Id == id);
        }

        public List<UsuarioEndereco>? GetUserAddressByUser(int idUsuario)
        {
            return _context.UsuarioEndereco.Where(ue => ue.UsuarioId == idUsuario).ToList();
        }
    }
}
