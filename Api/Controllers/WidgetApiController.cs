using FluentResults;
using HicomInterview.Application.DataModels;
using HicomInterview.Application.Interfaces;
using HicomInterview.Validation;
using Microsoft.AspNetCore.Mvc;

namespace HicomInterview.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class WidgetApiController : ControllerBase
    {
        private readonly IWidgetService _widgetService;

        public WidgetApiController(IWidgetService widgetService)
        {
            _widgetService = widgetService;
        }

        [HttpGet("{widgetId}")]
        public async Task<IActionResult> Get(int widgetId)
        {
            return Ok(await _widgetService.Get(widgetId));
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            return Ok(await _widgetService.ListGet());
        }


        [HttpPost]
        public async Task<IActionResult> Add(WidgetDM model)
        {
            Result<WidgetDM> result = await _widgetService.Post(model);

            if (result.IsFailed)
            {
                return new BadRequestObjectResult(result.MapToResponse());
            }

            return new OkObjectResult(result.Value);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(WidgetDM model)
        {
            Result<WidgetDM> result = await _widgetService.Put(model);

            if (result.IsFailed)
            {
                return new BadRequestObjectResult(result.MapToResponse());
            }

            return new OkObjectResult(result.Value);
        }
    }
}
