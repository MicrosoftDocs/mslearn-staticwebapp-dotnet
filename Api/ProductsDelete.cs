using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Api
{
    public class ProductsDelete
    {
        private readonly IProductData productData;

        public ProductsDelete(IProductData productData)
        {
            this.productData = productData;
        }

        [FunctionName("ProductsDelete")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "products/{productId:int}")] HttpRequest req,
            int productId,
            ILogger log)
        {
            var result = await productData.DeleteProduct(productId);

            if (result)
            {
                return new OkResult();
            }
            else
            {
                return new BadRequestResult();
            }
        }
    }
}
