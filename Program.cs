using Microsoft.AspNetCore.OData;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using OData.AutoMapper;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllers()
    .AddOData(options => options.AddRouteComponents("odata", new ODataConventionModelBuilder().GetCustomEdmModel())
        .Select()
        .Filter()
        .OrderBy()
        .Count()
        .SetMaxTop(50)
        .Expand());

var app = builder.Build();

app.MapControllers();

app.Run();

static class ODataConventionModelBuilderExtensions
{
    public static IEdmModel GetCustomEdmModel(this ODataConventionModelBuilder odataBuilder)
    {
        odataBuilder.EntitySet<CategoryModel>("categories");

        return odataBuilder.GetEdmModel();
    }
}