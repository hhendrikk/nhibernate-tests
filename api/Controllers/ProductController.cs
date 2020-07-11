using System.Collections.Generic;
using System.Linq;
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

            var customer = new Customer(
                name: "Max weinberg",
                billingAddress: new Address("line", "city", "state", "zipCode"),
                shippingAddress: new Address("line1", "city2", "state3", "zipCode4")
            );

            using (var session = sessionFactory.OpenSession())
            {
                await session.SaveAsync(book);
                await session.SaveAsync(movie);
                await session.SaveAsync(customer);
            }

            IList<Book> products;
            Customer customerQuery;

            using (var session = sessionFactory.OpenSession())
            {
                products = session.Query<Book>()
                    .ToList();

                customerQuery = session.QueryOver<Customer>().SingleOrDefault();
            }

            return Ok(customerQuery);
        }
    }
}