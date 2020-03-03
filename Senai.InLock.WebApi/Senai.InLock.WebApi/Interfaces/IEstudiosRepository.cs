using Senai.InLock.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Interfaces
{
    interface IEstudiosRepository
    {
        /// <summary>
        /// Lista todos os estúdios
        /// </summary>
        /// <returns>Retorna uma lista de estúdios</returns>
        List<EstudiosDomain> Listar();

        /// <summary>
        /// Busca um estúdio através do ID
        /// </summary>
        /// <param name="id">ID do estúdio que será buscado</param>
        /// <returns>Retorna um estúdio buscado</returns>
        EstudiosDomain BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo estúdio
        /// </summary>
        /// <param name="novoEstudio">Objeto novoEstudio que será cadastrado</param>
        void Cadastrar(EstudiosDomain novoEstudio);

        /// <summary>
        /// Atualiza um estúdio existente
        /// </summary>
        /// <param name="id">ID do estúdio que será alterado</param>
        /// <param name="EstudioAtualizado">Objeto EstudioAtualizado que será alterado</param>
        void Atualizar(int id, EstudiosDomain EstudioAtualizado);

        /// <summary>
        /// Deleta um estúdio existente
        /// </summary>
        /// <param name="id">ID do estúdio que será deletado</param>
        void Deletar(int id);
    }
}
