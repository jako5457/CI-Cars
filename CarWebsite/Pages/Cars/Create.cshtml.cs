using CarLibrary;
using CarLibrary.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace CarWebsite.Pages.Cars
{
    public class CreateModel : PageModel
    {

        private readonly ICarService _carService;

        public CreateModel(ICarService carService)
        {
            _carService = carService;
        }

        [BindProperty]
        public CarForm Form { get; set; } = default!;

        public void OnGet()
        {}

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _carService.AddCar(Form.Name,Form.Type);

            return Redirect("/");
        }

        public class CarForm
        {
            [Required]
            public string Name { get; set; } = "";

            [Required]
            public string Type { get; set; } = "";
        }
    }
}
