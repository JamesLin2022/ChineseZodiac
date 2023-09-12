using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ChineseZodiac.Models;

namespace ChineseZodiac.Pages;

public class IndexModel : PageModel
{
    [BindProperty]
    public int Year { get; set; }

    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        ViewData["Message"] = "Enter a year";
        ViewData["Zodiac"] = "";
        ViewData["Alert"] = "primary";
        ViewData["Image"] = "";
    }

    public void OnPost()
    {
        if (Year < 1900 || Year > DateTime.Now.Year + 1) {
            ViewData["Message"] = "Year must be between 1900 and next year";
            ViewData["Zodiac"] = "";
            ViewData["Alert"] = "danger";
            ViewData["Image"] = "";
        } else {
            string zodiac = Utils.GetZodiac(Year);;
            ViewData["Message"] = "Your zodiac is ";
            ViewData["Zodiac"] = zodiac;
            ViewData["Alert"] = "success";
            ViewData["Image"] = "images\\" + zodiac.ToLower() + ".png";
        }
        
    }
}
