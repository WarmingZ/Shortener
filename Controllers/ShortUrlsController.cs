using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Short.Helpers;
using Short.Models;
using Short.Services;

namespace Short.Controllers
{
	  [Authorize]
    public class ShortUrlsController: Controller
    {
        private readonly IShortUrlService _service;

        public ShortUrlsController(IShortUrlService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return RedirectToAction(actionName: nameof(Create));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(string originalUrl)
        {
            var shortUrl = new ShortUrl
            {
                OriginalUrl = originalUrl
            };

            TryValidateModel(shortUrl);
            if (ModelState.IsValid)
            {
                _service.Save(shortUrl);

                return RedirectToAction(actionName: nameof(Show), routeValues: new { id = shortUrl.Id });
            }

            return View(shortUrl);
        }

        public IActionResult Show(int? id)
        {
            if (!id.HasValue) 
            {
                return NotFound();
            }

            var shortUrl = _service.GetById(id.Value);
            if (shortUrl == null) 
            {
                return NotFound();
            }

            ViewData["Path"] = ShortUrlHelper.Encode(shortUrl.Id);

            return View(shortUrl);
        }

        [HttpGet("/ShortUrls/RedirectTo/{path:required}", Name = "ShortUrls_RedirectTo")]
        public IActionResult RedirectTo(string path)
        {
            if (path == null) 
            {
                return NotFound();
            }

            var shortUrl = _service.GetByPath(path);
            if (shortUrl == null) 
            {
                return NotFound();
            }

            return Redirect(shortUrl.OriginalUrl);
        }
    }
}