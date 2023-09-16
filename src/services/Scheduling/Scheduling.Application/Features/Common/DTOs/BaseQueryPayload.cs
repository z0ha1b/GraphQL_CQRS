using MediatR;

namespace Scheduling.Application.Features.Common.DTOs
{
    public class BaseQueryPayload<T> : IRequest<T>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string? Search { get; set; }
        public string? SortField { get; set; }
        public string? SortDirection { get; set; }
    }
}