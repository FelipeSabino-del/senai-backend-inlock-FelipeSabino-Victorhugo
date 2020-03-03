using Senai.InLock.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Interfaces
{
    interface IJogosRepository
    {
        /// <summary>
        /// Lista todos os jogos
        /// </summary>
        /// <returns>Retorna uma lista de jogos</returns>
        List<JogosDomain> Listar();

        /// <summary>
        /// Busca um jogo através do ID
        /// </summary>
        /// <param name="id">ID do jogo que será buscado</param>
        /// <returns>Retorna um jogo buscado</returns>
        JogosDomain BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo jogo
        /// </summary>
        /// <param name="novoJogo">Objeto novoJogo que será cadastrado</param>
        void Cadastrar(JogosDomain novoJogo);

        /// <summary>
        /// Atualiza um jogo existente
        /// </summary>
        /// <param name="id">ID do jogo que será alterado</param>
        /// <param name="JogoAtualizado">Objeto JogoAtualizado que será alterado</param>
        void Atualizar(int id, JogosDomain JogoAtualizado);

        /// <summary>
        /// Deleta um jogo existente
        /// </summary>
        /// <param name="id">ID do jogo que será deletado</param>
        void Deletar(int id);
    }
}
