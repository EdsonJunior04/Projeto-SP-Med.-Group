using senai.SpMedGroup.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.SpMedGroup.WebApi.Interfaces
{
    interface ITipoUsuarioRepository
    {
        /// <summary>
        /// Lista todos os Tipos de usuarios
        /// </summary>
        /// <returns>Uma lista de Tipos de usuarios</returns>
        List<Tipousuario> Listar();

        /// <summary>
        /// Busca um Tipo de usuario através do id
        /// </summary>
        /// <param name="idTipoUsuario">ID do Tipo de usuario a ser buscado</param>
        /// <returns>Um Tipo de usuario buscado</returns>
        Tipousuario BuscarPorId(int idTipoUsuario);

        /// <summary>
        /// Cadastrar um novo TipoUsuario
        /// </summary>
        /// <param name="novoTipoUsuario">Objeto novaTipoUsuario com os dados que serão cadastrados</param>
        void Cadastrar(Tipousuario novoTipoUsuario);

        /// <summary>
        /// Atualiza um TipoUsuario existente
        /// </summary>
        /// <param name="idTipoUsuario">ID do TipoUsuario que será atualizado</param>
        /// <param name="tipoUsuarioAtualizado">Objeto TipoUsuarioAtualizada com as novas informações</param>
        void Atualizar(int idTipoUsuario, Tipousuario tipoUsuarioAtualizado);

        /// <summary>
        /// Deleta um Tipo de usuario existente
        /// </summary>
        /// <param name="idTipoUsuario">ID do TipoUsuario que será deletado</param>
        void Deletar(int idTipoUsuario);
    }
}
