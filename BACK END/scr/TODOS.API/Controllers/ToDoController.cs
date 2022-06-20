using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore; 
using TODOS.API.Models;
using TODOS.API.Data;
using Microsoft.AspNetCore.Http;

namespace TODOS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToDoController : ControllerBase
    {

         public readonly DataContext _contexto;
        public ToDoController(DataContext contexto)
        {
           _contexto = contexto;
        }
        [HttpGet]
        //Realizando chamadas assincronas
        public async Task<IActionResult> Get()
        {
            try
            {           
                var resultado = await _contexto.tb_tarefas.ToListAsync();
                 return Ok(resultado);
            }
            catch (Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro Ao tentar Carregar Registro. Erro: { ex.Message}");
            }
        }

        // GET api/id
        [HttpGet("{id}")]
        public ActionResult<tb_tarefas> Get(int id)
        {
            try
            {

                return _contexto.tb_tarefas.First(x => x.Id == id);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro Ao tentar Carregar Registro. Erro: { ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTarefaId(int id, tb_tarefas tarefas)
        {
            if (id != tarefas.Id)
            {
                return BadRequest();
            }

            var tarefa = await _contexto.tb_tarefas.FindAsync(id);
            if (tarefa == null)
            {
                return NotFound();
            }

            tarefa.Tipo = tarefas.Tipo;
            tarefa.Titulo = tarefas.Titulo;
            tarefa.Descricao = tarefas.Descricao;
            tarefa.Prioridade = tarefas.Prioridade;
            tarefa.Situacao = tarefas.Situacao;
            tarefa.Solicitante = tarefas.Solicitante;
            tarefa.Responsavel = tarefas.Responsavel;
            tarefa.Data_ini = tarefas.Data_ini;
            tarefa.Data_Fim = tarefas.Data_Fim;
         //   tarefa.HistoricoTarefas = tarefa.HistoricoTarefas;

            try
            {
                await _contexto.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro Ao tentar Carregar Registros. Erro: { ex.Message}");
            }

            return Ok("Alterado Com Sucesso!");
        }
        [HttpPost]
        public async Task<ActionResult<tb_tarefas>> CreateTodoItem(tb_tarefas tarefaDTO)
        {

            try
            {



                var tarefaItem = new tb_tarefas
                {

                    Tipo = tarefaDTO.Tipo,
                    Titulo = tarefaDTO.Titulo,
                    Descricao = tarefaDTO.Descricao,
                    Prioridade = tarefaDTO.Prioridade,
                    Situacao = tarefaDTO.Situacao,
                    Solicitante = tarefaDTO.Solicitante,
                    Responsavel = tarefaDTO.Responsavel,
                    Data_ini = tarefaDTO.Data_ini,
                    Data_Fim = tarefaDTO.Data_Fim
                    //,HistoricoTarefas = tarefaDTO.HistoricoTarefas //muitos para muitos não é necessario nesse mommento
                };

                _contexto.tb_tarefas.Add(tarefaItem);
                await _contexto.SaveChangesAsync();

                //msg return 200-299
                return CreatedAtAction
                   (
                    nameof(Get),
                    new
                    {
                        id = tarefaItem.Id,
                        Response = "Incluido com Sucesso!"
                    }
                    );
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro Ao tentar Incluir Registro. Erro: { ex.Message}");
            }
        }

        // DELETE: por Id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTarefaId(int id)
        {

            try
            {
                var tarefaId = await _contexto.tb_tarefas.FindAsync(id);

                if (tarefaId == null)
                {
                    return NotFound();
                }

                _contexto.tb_tarefas.Remove(tarefaId);
                await _contexto.SaveChangesAsync();

                return Ok("Registro Deletado!");
            }

            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro Ao tentar Deletar Registro. Erro: { ex.Message}");
            }
        }


            };
    }



