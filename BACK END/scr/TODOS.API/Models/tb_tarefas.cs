using System.ComponentModel.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TODOS.API.Models;

namespace TODOS.API.Models
{
    public class tb_tarefas
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Tipo { get; set; }
        public string Prioridade { get; set; }
        public string Situacao { get; set; }
        public string Solicitante { get; set; }
        public string Responsavel { get; set; }       
        public DateTime Data_ini { get; set; }
        public DateTime? Data_Fim { get; set; }
     //   public IEnumerable<HistoricoTarefas> HistoricoTarefas { get; set; }

    }
}