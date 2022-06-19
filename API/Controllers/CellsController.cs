using API.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace API;

[ApiController]
[Route("[controller]")]
[EnableCors("MyPolicy")]
public class CellsController : ControllerBase
{
    private readonly IHubContext<CellHub> _hub;
    public CellsController(IHubContext<CellHub> hub)
    {
        _hub = hub;
    }
    private CellsHandler _teamDBHandler = new CellsHandler();


        /// <summary>
        /// Get all cells
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/cells")]
        public IEnumerable<Cell> GetCells()
        {
            return _teamDBHandler.GetCells();
        }
        /// <summary>
        /// Get all cells
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [Route("/cells")]
        public String ChangeCell(Cell cell)
        {
            return _teamDBHandler.ChangeCell(cell, _hub);
        }

        /// <summary>
        /// test
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/test")]
        public string test()
        {
            return "test";
        }
}

