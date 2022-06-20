using System.Security.Cryptography.X509Certificates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TODOS.API.Models;

namespace TODOS.API.Models
{
    public class tb_historico
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Comentario { get; set; }
        public DateTime? Data_ini { get; set; }
        public DateTime? Data_fim { get; set; }
        
              
        
    }
}