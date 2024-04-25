using FluentResults;
using HicomInterview.Application.DataModels;

namespace HicomInterview.Application.Interfaces
{
    /// <summary>
    /// Widget interface service. All work to be performed on a widget should be included here and used in controllers (MVC/Blazor/Api etc)
    /// </summary>
    public interface IWidgetService
    {
        Task<Result<int>> Delete(int widgetId);
        Task<WidgetDM?> Get(int widgetId);
        Task<List<WidgetDM>> ListGet();
        Task<Result<WidgetDM>> Post(WidgetDM customer);
        Task<Result<WidgetDM>> Put(WidgetDM customer);
        Task ForceConcurrencyError(int widgetId);
    }
}
