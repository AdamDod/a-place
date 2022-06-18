using API.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace API;

[ApiController]
[Route("[controller]")]
public class CellsController : ControllerBase
{
    private CellsHandler _teamDBHandler = new CellsHandler();
        /// <summary>
        /// Get all cells
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [EnableCors("MyPolicy")]
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
        [EnableCors("MyPolicy")]
        [Route("/cells")]
        public String ChangeCell(Cell cell)
        {
            return _teamDBHandler.ChangeCell(cell);
        }

        /// <summary>
        /// test
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [EnableCors("MyPolicy")]
        [Route("/test")]
        public string test()
        {
            return "test";
        }
}

