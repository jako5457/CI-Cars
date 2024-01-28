using CarLibrary;
using CarLibrary.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarWebsite.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ICarService _CarService;
        public IndexModel(ICarService carService,ILogger<IndexModel> logger)
        {
            _logger = logger;
            _CarService = carService;
        }

        public List<Car> Cars = new List<Car>();

        public void OnGet()
        {
            Cars = _CarService.GetCars();
        }
    }
}
