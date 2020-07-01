using System.Collections.Generic;
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

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var book = new Book(
                name: "NHibernate Cookbook",
                description: "Book about nhibernate ORM",
                isbn: "12334",
                unitPrice: 59.50m,
                author: "Gunnar Lijas"
            );

            var movie = new Movie(
                name: "Intouchables",
                description: "Film",
                unitPrice: 59.50m,
                director: "Oliver Nakache"
            );

            using (var session = sessionFactory.OpenSession())
            {
                await session.SaveAsync(book);
                await session.SaveAsync(movie);
            }

            IList<Product> products;

            using (var session = sessionFactory.OpenSession())
            {
                products = await session.CreateQuery("from Product").ListAsync<Product>();
            }

            return Ok(products);
        }
    }
}