using Microsoft.AspNetCore.Http;
using senai.SpMedGroup.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.SpMedGroup.WebApi.Interfaces
{
    interface IUsuarioRepository
    {
        /// <summary>
        /// Lista todos os Usuarios
        /// </summary>
        /// <returns>Uma lista de usuarios</returns>
        List<Usuario> Listar();

        /// <summary>
        /// Lista todos os Usuarios e seus respectivos tipos
        /// </summary>
        /// <returns>Uma lista de usuarios</returns>
        List<Usuario> ListarComTipo();

        /// <summary>
        /// Lista todos os Usuarios e suas respectivas informações
        /// </summary>
        /// <returns></returns>
        List<Usuario> ListarTudo();
        Usuario ValidarEmailSenha(object email, object senha);

        /// <summary>
        /// Busca um usuario através do id
        /// </summary>
        /// <param name="idUsuario">ID do usuario a ser buscado</param>
        /// <returns>Um usuario buscado</returns>
        Usuario BuscarPorId(int idUsuario);
        object ListarMinhasConsultas(int idUsuarioLogado);

        /// <summary>
        /// Cadastrar um novo Usuario
        /// </summary>
        /// <param name="novoUsuario">Objeto novaUsuario com os dados que serão cadastrados</param>
        void Cadastrar(Usuario novoUsuario);

        /// <summary>
        /// Atualiza um Usuario existente
        /// </summary>
        /// <param name="idUsuario">ID do Usuario que será atualizado</param>
        /// <param name="usuarioAtualizado">Objeto UsuarioAtualizada com as novas informações</param>
        void Atualizar(int idUsuario, Usuario usuarioAtualizado);

        /// <summary>
        /// Deleta um usuario existente
        /// </summary>
        /// <param name="idUsuario">ID do Usuario que será deletado</param>
        void Deletar(int idUsuario);

        /// <summary>
        /// Busca um usuario atraves do email e senha
        /// </summary>
        /// <param name="email">Email do usuario</param>
        /// <param name="senha">Senha do usuario</param>
        /// <returns></returns>
        Usuario BuscarPorEmailSenha(string email, string senha);
        void SalvarFotoBD(IFormFile arquivo, int idUsuario);
        string CarregarFotoBD(int idUsuario);
    }
}
