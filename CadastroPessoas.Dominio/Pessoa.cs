﻿namespace CadastroPessoas.Dominio
{
    public class Pessoa
    {
        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual int Idade { get; set; }
        public virtual string Endereco { get; set; }
    }
}