using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TODOS.API.Models;

namespace TODOS.API.Models
{
    public class HistoricoTarefas
    {
        public int Tarefa_id { get; set; }

        public tb_tarefas tb_tarefas { get; set; }

        public int Historico_id { get; set; }

        public tb_historico tb_historico { get; set; }
        
        
    }
}