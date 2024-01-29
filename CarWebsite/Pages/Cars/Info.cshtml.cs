using CarLibrary;
using CarLibrary.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarWebsite.Pages.Cars
{
    public class InfoModel : PageModel
    {

        private readonly ICarService _carService;

        public InfoModel(ICarService carService)
        {
            _carService = carService;
        }

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        public Car Car { get; set; } = default!;

        public IActionResult OnGet()
        {
            Car? car = _carService.GetCarById(Id);

            if (car == null)
            {
                return NotFound();
            }

            Car = car;

            return Page();
        }
    }
}
