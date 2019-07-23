using System.Threading.Tasks;
using ExpenseTracer.Application.Expenses.Queries;
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
    }
}
