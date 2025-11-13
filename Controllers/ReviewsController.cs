using Microsoft.AspNetCore.Mvc;
using Ezel_Market.Data;
using Ezel_Market.Models;
using System.Linq;

namespace Ezel_Market.Controllers
{
    public class ReviewsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReviewsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Reviews
        public IActionResult Index(string sort)
        {
            var reviewsQuery = _context.Reviews.AsQueryable();

            if (sort == "best")
                reviewsQuery = reviewsQuery.OrderByDescending(r => r.Rating);
            else // recent o por defecto
                reviewsQuery = reviewsQuery.OrderByDescending(r => r.CreatedAt);

            var reviewsList = reviewsQuery.ToList();

            // Obtener la lista de productos desde Inventarios
            var products = _context.Inventarios.OrderBy(p => p.NombreProducto).ToList();
            ViewBag.Products = products;

            return View(reviewsList);
        }

        // POST: Reviews/Create
        [HttpPost]
        public IActionResult Create(string productName, string content, string userEmail, int rating)
        {
            if (string.IsNullOrEmpty(content) || string.IsNullOrEmpty(userEmail) || rating < 1 || rating > 5)
                return BadRequest();

            var review = new Review
            {
                ProductName = productName,
                Content = content,
                UserEmail = userEmail,
                Rating = rating
            };

            _context.Reviews.Add(review);
            _context.SaveChanges();

            // Retorna la reseña recién creada para actualizar la lista vía AJAX
            return PartialView("_SingleReview", review);
        }
    }
}
