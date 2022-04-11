using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models;
using API.Data;
using API.ViewModels;
using System;


namespace API.Controllers
{
    [ApiController]
    [Route("v1")]
    public class BoardController : ControllerBase
    {
        [HttpGet]
        [Route("Board/Get")]
        public async Task<IActionResult> Get([FromServices] AppDBC context)
        {
            var boards = await context
              .Boards
              .AsNoTracking()
              .ToListAsync();

              // declarar uma nova lista (boardResult);
            // var boardResult = new List<object>();

            // foreach na vaariável boards;
            // novo objeto, atribuir os valores do quadro atual 
            // + select todas atividades que tenham o BoardId == Id do quadro atual;
            // Salvar select em uma lista/array;
            // pegar quantidade de elementos na lista/arrat;

            // add na lista boardResult
            // trocar no return, boards por boardResult;
            var boardResult = new List<object>();
            foreach(var item in board){
              var activity = new List<object>();
              activity = context.Activities.Where(x => x.BoardId == item.Id).Count();
              var currentBoard = new {
                name = item.Name,
                subject = item.Subject,
                status = item.Status,
                activityCount = activity + " Atividade(s) "
              };
              boardResult.Add(currentBoard);

            }
            return Ok(currentBoard);
        }

        [HttpGet]
        [Route("Board/GetById/{id}")]
        public async Task<IActionResult> GetById(
          [FromServices] AppDBC context,
          [FromRoute] int id
        )
        {
            var board = await context
              .Boards
              .AsNoTracking()
              .FirstOrDefaultAsync(x => x.Id == id);

            return board == null
              ? NotFound()
              : Ok(board);
        }

        [HttpPost]
        [Route("Board/Save")]
        public async Task<IActionResult> Save(
          [FromServices] AppDBC context,
          [FromBody] BoardSaveVM board
        )
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var newBoard = new Board
            {
                Name = board.Name,
                Subject = board.Subject,
                Status = board.Status,
            };

            try
            {
                await context.Boards.AddAsync(newBoard);
                await context.SaveChangesAsync();
                return Created($"v1/GetById/{newBoard.Id}", newBoard);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest();
            }
        }

        [HttpPut("Board/Edit/{1}")]
        public async Task<IActionResult> Edit(
          [FromServices] AppDBC context,
          [FromBody] BoardSaveVM board,
          [FromRoute] int id)
        {
          try
          {
            if (!ModelState.IsValid)
              return BadRequest();

            var currentBoard =
              await context.Boards
              .FirstOrDefaultAsync(x => x.Id == id);

            if (currentBoard == null)
              return NotFound();

            currentBoard.Name = board.Name;
            currentBoard.Subject = board.Subject;
            currentBoard.Status = board.Status;

            context.Boards.Update(currentBoard);
            await context.SaveChangesAsync();
            return Ok();
          }
          catch (Exception ex)
          {
            Console.WriteLine(ex);
            return BadRequest();
          }
        }
    }
}