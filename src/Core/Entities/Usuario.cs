using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using Core.Enums;

namespace Core.Entities
{
    public sealed class Usuario
    {
        private const string CpfPattern = @"^\d{3}\.\d{3}\.\d{3}-\d{2}$";
        private const string EmailPattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";

        [Key] public int Id { get; private set; }

        [Required] [MaxLength(100)] public string Nome { get; private set; }

        [Required] [MaxLength(100)] public string SobreNome { get; private set; }

        [Required] [MaxLength(14)] public string Cpf { get; private set; }

        [Required] public string Senha { get; private set; }

        [Required] public string Email { get; private set; }

        [Required] public AccessControl Papel { get; private set; }

        public void Validade()
        {
            ValidadeNome();
            ValidadeSobreNome();
            ValidadeCpf();
            ValidadeSenha();
            ValidadeEmail();
        }

        private void ValidadeEmail()
        {
            if (string.IsNullOrEmpty(Email))
            {
                throw new ArgumentException("Email não pode ser vazio");
            }

            var regexMatch = Regex.Match(Email, EmailPattern);
            if (!regexMatch.Success)
            {
                throw new ArgumentException("Email inválido");
            }
        }

        private void ValidadeSenha()
        {
            if (string.IsNullOrEmpty(Senha) || Senha.Length < 8)
            {
                throw new ArgumentException("Senha não ser vazio ou menor que 8 caracteres");
            }
        }

        private void ValidadeCpf()
        {
            var regexMatch = Regex.Match(Cpf, CpfPattern);
            if (!regexMatch.Success)
            {
                throw new ArgumentException("CPF inválido");
            }
        }

        private void ValidadeSobreNome()
        {
            if (string.IsNullOrEmpty(SobreNome))
            {
                throw new ArgumentException("Sobrenome não pode vazio");
            }
        }

        private void ValidadeNome()
        {
            if (string.IsNullOrEmpty(Nome))
            {
                throw new ArgumentException("Nome não pode ser vazio");
            }
        }
    }
}