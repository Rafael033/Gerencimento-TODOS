using System.Data;
using System.Reflection.Emit;
using System;
using Microsoft.EntityFrameworkCore;
using TODOS.API.Models;

namespace TODOS.API.Data
{
     
     public class  DataContext : DbContext
    {
        public  DataContext(DbContextOptions<DataContext> Options) : base (Options) 
        {

        }

        public DbSet<tb_tarefas> tb_tarefas { get;set; } //name table
        public DbSet<tb_historico> tb_historico { get;set; } //name table
     //   public DbSet<HistoricoTarefas> tb_historico_tarefas { get;set; } //name table call
      
      //metodo para controlar a junção das tarefas com seus historicos no banco
      protected override void OnModelCreating(ModelBuilder modelBuilder)  
      {
           modelBuilder.Entity<HistoricoTarefas>().HasKey(x => new {x.Historico_id, x.Tarefa_id});
         
         //se a tabela estiver vazia o entity inclui dados iniciais
           modelBuilder.Entity<tb_tarefas>().HasData(
               new tb_tarefas {
                               Id = 1,
                               Tipo = "Tarefa",
                               Titulo = "Desenvolver Function",
                               Descricao = "Function para calcular frete",
                               Prioridade = "Baixa",
                               Situacao = "To do",
                               Solicitante = "claudia.silva",
                               Responsavel= "rafael.nogueira",
                               Data_ini = DateTime.Now,
                               Data_Fim = null},
              new tb_tarefas {
                               Id = 2,
                               Tipo = "Projeto",
                               Titulo = "Desenvolver Sistema",
                               Descricao = null,
                               Prioridade = "Alta",
                               Situacao = "Done",
                               Solicitante = "raquel.souza",
                               Responsavel= "rafael.nogueira",
                               Data_ini = DateTime.Now,
                               Data_Fim = null}


           );


      }
    }
}