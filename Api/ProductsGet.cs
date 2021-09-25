using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Api
{
    public class ProductsGet
    {
        private readonly IProductData _productData;

        public ProductsGet(IProductData productData)
        {
            this._productData = productData;
        }

        [FunctionName("ProductsGet")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "products")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("ProductsGet");
            var products = await _productData.GetProducts();
            return new OkObjectResult(products);
        }
    }
}
