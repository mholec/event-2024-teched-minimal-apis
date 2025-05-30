using System.Globalization;
using System.Text;
using CsvHelper;

namespace BigMinimal.Basic.Results;

public class CsvResult : IResult
{
    private readonly List<object> _data;
    public CsvResult(List<object> data)
    {
        _data = data;
    }
    public async Task ExecuteAsync(HttpContext httpContext)
    {
        await using var writer = new StringWriter();
        await using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
        await csv.WriteRecordsAsync(_data);

        httpContext.Response.StatusCode = 200;
        httpContext.Response.ContentType = "text/csv";
        await httpContext.Response.WriteAsync(writer.ToString(), Encoding.UTF8);
    }
}