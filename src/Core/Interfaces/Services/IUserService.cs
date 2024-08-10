﻿using Core.Entities;

namespace Core.Interfaces.Services;

public interface IUserService
{
    Usuario AddNewUser(Usuario usuario);
    Usuario? GetUserByCpf(string cpf);
    Usuario? GetUserById(int id);
    IEnumerable<Usuario> GetUsers();
}