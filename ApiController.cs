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

    /* http://localhost:5238/odata/categories?$expand=products($count=true) works
     {
    "@odata.context": "http://localhost:5238/odata/$metadata#categories(Products())",
    "value": [
        {
            "CategoryId": 1,
            "CategoryName": "CategoryOne",
            "Products@odata.count": 3, <-- visible
            "Products": [
                {
                    "ProductId": 1,
                    "ProductName": "ProductOne"
                },
                {
                    "ProductId": 2,
                    "ProductName": "ProductTwo"
                },
                {
                    "ProductId": 3,
                    "ProductName": "ProductThree"
                }
            ]
        },
        {
            "CategoryId": 2,
            "CategoryName": "CategoryTwo",
            "Products@odata.count": 2, <-- visible
            "Products": [
                {
                    "ProductId": 4,
                    "ProductName": "ProductFour"
                },
                {
                    "ProductId": 5,
                    "ProductName": "ProductFive"
                }
            ]
        }
    ]
}
    */
    // [EnableQuery]
    // [HttpGet("categories")]
    // public async Task<IQueryable<CategoryModel>> GetODataCategories()
    // {
    //     return this.mapper.ProjectTo<CategoryModel>(Data.Categories);
    // }

    /* http://localhost:5238/odata/categories?$expand=products($count=true) does not works, missing Products@odata.count
     {
    "@odata.context": "http://localhost:5238/odata/$metadata#categories(Products())",
    "value": [
        {
            "CategoryId": 1,
            "CategoryName": "CategoryOne",
            "Products": [
                {
                    "ProductId": 1,
                    "ProductName": "ProductOne"
                },
                {
                    "ProductId": 2,
                    "ProductName": "ProductTwo"
                },
                {
                    "ProductId": 3,
                    "ProductName": "ProductThree"
                }
            ]
        },
        {
            "CategoryId": 2,
            "CategoryName": "CategoryTwo",
            "Products": [
                {
                    "ProductId": 4,
                    "ProductName": "ProductFour"
                },
                {
                    "ProductId": 5,
                    "ProductName": "ProductFive"
                }
            ]
        }
    ]
}
     */
    [HttpGet("categories")]
    public async Task<IQueryable<CategoryModel>> GetODataCategories(ODataQueryOptions<CategoryModel> options)
    {
        return await Data.Categories.GetQueryAsync(mapper, options);
    }
}