//using AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskoCapstone.Data;
using TaskoCapstone.Interfaces;
using TaskoCapstone.Models;

namespace TaskoCapstone.Controllers
{
    [ApiController]
    [Route("api/tasks")]
    public class GameController : ControllerBase
    {
        ApplicationDbContext _context;
        IDataAccessLayer dal;

        public GameController(ApplicationDbContext context, IDataAccessLayer dal)
        {
            _context = context;
            this.dal = dal;
        }

        // Adding the actions for updating the CountdownTimer and CompletionOfTask in the database
        [HttpPost]
        public async Task<IActionResult> CompleteTask(int taskId)
        {
            try
            {
                await dal.CompleteTasks(taskId);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
