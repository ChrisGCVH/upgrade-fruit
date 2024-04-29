using FluentResults;
using FluentValidation;
using HicomInterview.Application.DataModels;
using HicomInterview.Application.Interfaces;
using HicomInterview.Application.Interfaces.Persistence;
using HicomInterview.Application.Validators;
using HicomInterview.Domain.Entities;
using HicomInterview.Validation;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace HicomInterview.Application.Services
{
    public class WidgetService : IWidgetService
    {
        private readonly IApplicationDbContext _context;
        private readonly WidgetDMValidator _widgetDMValidator;

        public WidgetService(IApplicationDbContext context, WidgetDMValidator widgetDMValidator)
        {
            _context = context;
            _widgetDMValidator = widgetDMValidator;
        }

        public async Task<Result<int>> Delete(int widgetId)
        {
            var entity = await _context.Widget.FindAsync(widgetId);

            if (entity != null)
            {
                _context.Widget.Remove(entity);
            }

            Result<int> result = await _context.SaveChangesAsync();

            return result;
        }

        public async Task<WidgetDM?> Get(int widgetId)
        {
            return await _context.Widget.AsNoTracking()
                    .Where(x => x.WidgetId == widgetId)
                    .Include(a => a.OldAddress)
                    .Include(a => a.NewAddress)
                    .ProjectToType<WidgetDM>()
                    .SingleOrDefaultAsync();
        }

        public async Task<List<WidgetDM>> ListGet()
        {
            return await _context.Widget.OrderByDescending(x => x.WidgetId).Take(100).ProjectToType<WidgetDM>().ToListAsync();
        }

        public async Task<Result<WidgetDM>> Post(WidgetDM model)
        {
            var validationResult = await _widgetDMValidator.ValidateAsync(model);

            if (!validationResult.IsValid)
            {
                return Result.Fail("Post failed").WithValidationResults(validationResult.Errors);
            }

            var entity = model.Adapt<Widget>();

            _context.Widget.Add(entity);

            var result = await _context.SaveChangesAsync();

            if (result.IsFailed)
            {
                return result.ToResult<WidgetDM>();
            }

            return entity.Adapt<WidgetDM>();
        }

        public async Task<Result<WidgetDM>> Put(WidgetDM model)
        {
            var validationResult = await _widgetDMValidator.ValidateAsync(model);

            if (!validationResult.IsValid)
            {
                return Result.Fail("Put failed").WithValidationResults(validationResult.Errors);
            }

            var entity = await _context.Widget
                        .Where(t => t.WidgetId == model.WidgetId)
                        .Include(a => a.OldAddress)
                        .Include(a => a.NewAddress)
                        .SingleOrDefaultAsync();

            if (entity == null)
            {
                throw new DbUpdateException($"Record not found for id: {model.WidgetId}");
            }

            model.Adapt(entity);

            Result<int> result = await _context.SaveChangesAsync();

            if (result.IsFailed)
            {
                return result.ToResult<WidgetDM>();
            }

            return entity?.Adapt<WidgetDM>()!;
        }
    }
}
