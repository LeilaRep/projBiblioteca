using System;
namespace Biblioteca.Models
{
    public class Usuario
    {
        public int Id {get; set;}
        public string nomeUsuario {get;set;}
        public string login {get;set;}
        public string senha {get;set;}
        public DateTime dataNascimento {get;set;}
    }
}