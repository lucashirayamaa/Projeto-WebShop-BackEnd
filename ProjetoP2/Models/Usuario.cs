﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ProjetoP2.DTOs;

namespace ProjetoP2.Models {

// Enum Perfil do usuário
    public enum PerfilUsuarioEnum
    {
        Cliente,
        Administrador,
    }

    public class Usuario 
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Celular { get; set; }

        public string Cpf {  get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public PerfilUsuarioEnum Perfil {  get; set; }

        private Usuario() { }

        public Usuario(string nome, string celular, string cpf, string email, string senha, PerfilUsuarioEnum perfil)
        {
            this.Nome = nome;
            this.Celular = celular;
            this.Cpf = cpf;
            this.Email = email;
            this.Senha = senha;
            this.Perfil = perfil;
        }

        public UsuarioDtoOutput GetUsuarioDtoOutput()
        {
            return new UsuarioDtoOutput(Id, Email, Perfil);
        }


    }
}
