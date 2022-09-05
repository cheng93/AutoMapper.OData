namespace OData.AutoMapper;

using global::AutoMapper;
using global::AutoMapper.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

[Route("odata")]
public class ApiController : ODataController
{
    private readonly IMapper mapper;

    public ApiController(IMapper mapper)
    {
        this.mapper = mapper;
    }

    [HttpGet("categories")]
    public async Task<IQueryable<CategoryModel>> GetODataCategories(ODataQueryOptions<CategoryModel> options)
    {
        return await Data.Categories.GetQueryAsync(mapper, options);
    }
}