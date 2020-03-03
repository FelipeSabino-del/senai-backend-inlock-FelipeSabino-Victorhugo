using Senai.InLock.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Interfaces
{
    interface ITiposUsuariosRepository
    {
        /// <summary>
        /// Lista todos os tipos de usuário
        /// </summary>
        /// <returns>Retorna uma lista de tipos de usuário</returns>
        List<TiposUsuariosDomain> Listar();

        /// <summary>
        /// Busca um tipo de usuário através do ID
        /// </summary>
        /// <param name="id">ID do tipo de usuário que será buscado</param>
        /// <returns>Retorna um tipo de usuário buscado</returns>
        TiposUsuariosDomain BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo tipo de usuário
        /// </summary>
        /// <param name="novoTipoUsuario">Objeto novoTipoUsuario que será cadastrado</param>
        void Cadastrar(TiposUsuariosDomain novoTipoUsuario);

        /// <summary>
        /// Atualiza um tipo de usuário existente
        /// </summary>
        /// <param name="id">ID do tipo de usuário que será alterado</param>
        /// <param name="TipoUsuarioAtualizado">Objeto TipoUsuarioAtualizado que será alterado</param>
        void Atualizar(int id, TiposUsuariosDomain TipoUsuarioAtualizado);

        /// <summary>
        /// Deleta um tipo de usuário existente
        /// </summary>
        /// <param name="id">ID do tipo de usuário que será deletado</param>
        void Deletar(int id);
    }
}
