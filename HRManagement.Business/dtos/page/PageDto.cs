using System.Text.Json.Serialization;

namespace HRManagement.Business.dtos.page;

public class PageDto<T>
{
    [JsonPropertyName("data")]
    public IEnumerable<T> Datas { get; set; } = [];
    public int TotalCount { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);
}