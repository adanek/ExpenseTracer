using System.Threading.Tasks;
using ExpenseTracer.Application.Expenses.Commands;
using ExpenseTracer.Application.Expenses.Queries;
using ExpenseTracer.Application.Expenses.Queries.GetExpenseDetails;
using ExpenseTracer.Web.Api.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracer.Web.Api.Controllers
{
    public class ExpensesController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ExpenseListViewModel>> GetAll()
        {
            return Ok(await Mediator.Send(new GetExpenseListQuery()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ExpenseDetailViewModel>> Get(int id)
        {
            return Ok(await Mediator.Send(new GetExpenseDetailQuery(id)));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateExpenseCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
