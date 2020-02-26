using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;
using WebAPI.Handler;
using System.Linq;
using System;
using Microsoft.Extensions.Logging;


namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]

	public class EmployeeDetailController : ControllerBase
	{

		private readonly IEmployeeDetailsHandler _handler;
		private readonly ILogger<EmployeeDetailController> _logger;


		public EmployeeDetailController(IEmployeeDetailsHandler handler, ILogger<EmployeeDetailController> logger)
		{
			_handler = handler;
			_logger = logger;
		}


		// GET: api/EmployeeDetail
		[HttpGet]
		public async Task<ActionResult> GetEmployeeDetails()
		{
			try
			{
				var posts = await _handler.GetEmployeeDetails();
				_logger.LogInformation("Message displayed: {Message}", posts);
				if (posts == null)
				{
					return NotFound();
				}
				return Ok(posts);
			}
			catch (Exception)
			{
				return BadRequest();
			}
		}

		// GET: api/EmployeeDetail/5
		[HttpGet("{id}")]
		public async Task<IActionResult> GetEmployeeDetail([FromRoute] int id)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			EmployeeDetail employeeDetail = await _handler.GetEmployeeDetail(id);

			_logger.LogInformation("Message displayed: {Message}", employeeDetail);

			if (employeeDetail == null)
			{
				return NotFound();
			}

			return Ok(employeeDetail);
		}

		//// PUT: api/EmployeeDetail/5
		[HttpPut("{id}")]
		public async Task<IActionResult> PutEmployeeDetail([FromRoute] int id, [FromBody] EmployeeDetail employeeDetail)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			if (id != employeeDetail.EId)
			{
				return BadRequest();
			}

			try
			{
				await _handler.PutEmployeeDetailAsync(id, employeeDetail);


			}
			catch (DbUpdateConcurrencyException)
			{
				if (!(_handler.EmployeeDetailExists(id)))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}

			return Ok();
		}

		//// POST: api/EmployeeDetail
		[HttpPost]
		public async Task<IActionResult> PostEmployeeDetail([FromBody] EmployeeDetail employeeDetail)
		{
			if (ModelState.IsValid)
			{
				try
				{
					var eId = await _handler.PostEmployeeDetail(employeeDetail);
					if (eId >= 0)
					{
						return CreatedAtAction("GetEmployeeDetail", new { id = employeeDetail.EId }, employeeDetail);
					}
					else
					{
						return NotFound();
					}
				}
				catch (Exception)
				{

					return BadRequest();
				}

			}

			return BadRequest();
		}

		// DELETE: api/EmployeeDetail/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteEmployeeDetail([FromRoute] int id)
		{
			int result = 0;
			if (id == 0)
			{
				return BadRequest();
			}

			try
			{
				result = await _handler.DeleteEmployeeDetail(id);
				if (result == 0)
				{
					return NotFound();
				}
				return Ok();
			}
			catch (Exception)
			{
				return BadRequest();
			}
		}


	}
}