using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Domains
{
    public class EstudiosDomain
    {
        public int IdEstudio { get; set; }

        [Required(ErrorMessage = "Nome do estúdio obrigatório!")]
        public string NomeEstudio { get; set; }

        public JogosDomain Jogo { get; set; }
    }
}
