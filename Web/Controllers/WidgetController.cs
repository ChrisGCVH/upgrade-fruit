using FluentResults;
using HicomInterview.Application.DataModels;
using HicomInterview.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HicomInterview.Web.Controllers
{
    [Authorize]
    public class WidgetController : BaseController
    {
        private readonly IWidgetService _widgetService;

        public WidgetController(IWidgetService widgetService)
        {
            _widgetService = widgetService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _widgetService.ListGet();
            return View(model);
        }

        #region Add
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(WidgetDM model)
        {
            Result<WidgetDM> result = await _widgetService.Post(model);

            if (result.IsFailed)
            {
                SetModelState(result);
                return View(model);
            }

            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Edit
        public async Task<IActionResult> Edit(int id)
        {
            var model = await _widgetService.Get(id);
            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, WidgetDM model)
        {
            if (id != model.WidgetId)
            {
                return NotFound();
            }

            Result<WidgetDM> result = await _widgetService.Put(model);

            if (result.IsFailed)
            {
                SetModelState(result);
                return View(model);
            }

            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Details/Delete
        public async Task<IActionResult> Details(int id)
        {
            var model = await _widgetService.Get(id);
            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            Result<int> result = await _widgetService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        #endregion
    }
}
