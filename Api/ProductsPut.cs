using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Data;

namespace Api;

public class ProductsPut
{
    private readonly IProductData productData;

    public ProductsPut(IProductData productData)
    {
        this.productData = productData;
    }

    [FunctionName("ProductsPut")]
    public async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "put", Route = "products")] HttpRequest req,
        ILogger log)
    {
        var body = await new StreamReader(req.Body).ReadToEndAsync();
        var product = JsonSerializer.Deserialize<Product>(body, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

        var updatedProduct = await productData.UpdateProduct(product);
        return new OkObjectResult(updatedProduct);
    }
}
