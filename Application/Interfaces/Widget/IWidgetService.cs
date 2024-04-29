using FluentResults;
using HicomInterview.Application.DataModels;

namespace HicomInterview.Application.Interfaces
{
    public interface IWidgetService
    {
        Task<Result<int>> Delete(int widgetId);
        Task<WidgetDM?> Get(int widgetId);
        Task<List<WidgetDM>> ListGet();
        Task<Result<WidgetDM>> Post(WidgetDM customer);
        Task<Result<WidgetDM>> Put(WidgetDM customer);
    }
}
