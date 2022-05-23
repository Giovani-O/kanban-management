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
    public class ActivityController : ControllerBase
    {

        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> Get(
          [FromServices] AppDBC context
        )
        {
            var activities = await context
              .Activities
              .AsNoTracking()
              .ToListAsync();

            return Ok(activities);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> GetById(
          [FromServices] AppDBC context,
          [FromRoute] int id
        )
        {
            var activity = await context
              .Activities
              .AsNoTracking()
              .FirstOrDefaultAsync(x => x.Id == id);

            return activity == null
              ? NotFound()
              : Ok(activity);
        }

        [HttpPost("Save")]
        public async Task<IActionResult> Save(
          [FromServices] AppDBC context,
          [FromBody] ActivitySaveVM activity)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var newActivity = new Activity
            {
                BoardId = Convert.ToInt32(activity.BoardId),
                Text = activity.Text,
                Column = activity.Column,
            };

            try
            {
                await context.Activities.AddAsync(newActivity);
                await context.SaveChangesAsync();
                return Created($"v1/GetById/{newActivity.Id}", newActivity);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest();
            }
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> Delete(
          [FromServices] AppDBC context,
          [FromBody] ActivityDeleteVM activity)
        {
            if (activity.ActivityId == 0)
                return BadRequest();

            try
            {
                Activity currentActivity = await context.Activities.FirstOrDefaultAsync(x => x.Id == activity.ActivityId);
                context.Activities.Remove(currentActivity);
                context.SaveChanges();

                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest();
            }
        }

        [HttpPut("Edit/{1}")]
        public async Task<IActionResult> Edit(
          [FromServices] AppDBC context,
          [FromBody] ActivitySaveVM activity,
          [FromRoute] int id)
        {
            // Erro 404 not found
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                var currentActivity =
                  await context.Activities
                  .FirstOrDefaultAsync(x => x.Id == id);

                if (currentActivity == null)
                    return NotFound();

                currentActivity.BoardId = activity.BoardId;
                currentActivity.Text = activity.Text;
                currentActivity.Column = activity.Column;

                context.Activities.Update(currentActivity);
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