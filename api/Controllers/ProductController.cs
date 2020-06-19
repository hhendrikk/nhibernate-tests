using System.Threading.Tasks;
using api.Entities;
using api.Model;
using Microsoft.AspNetCore.Mvc;
using NHibernate;

namespace api.Controllers
{
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly ISessionFactory sessionFactory;
        public ProductController(ISessionFactory sessionFactory)
        {
            this.sessionFactory = sessionFactory;
        }

        [HttpPost]
        public async Task<IActionResult> InsertProduct(
            [FromBody]ProductModel model)
        {
            using var session = sessionFactory.OpenSession();
            var product = new Product(
                model.Name,
                model.Description,
                model.UnitPrice);

            await session.SaveAsync(product);

            return Created("", product);
        }
    }
}