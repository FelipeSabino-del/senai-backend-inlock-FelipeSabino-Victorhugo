using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Domains
{
    public class JogosDomain
    {
        public int IdJogo { get; set; }

        [Required(ErrorMessage = "Nome do jogo obrigatório!")]
        public string NomeJogo { get; set; }

        [Required(ErrorMessage = "Descrição do jogo obrigatória!")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Data de lançamento obrigatória!")]
        public DateTime DataLancamento { get; set; }

        [Required(ErrorMessage = "Valor do jogo obrigatório!")]
        public float Valor { get; set; }

        public int IdEstudio { get; set; }

        public EstudiosDomain Estudio { get; set; }
    }
}
