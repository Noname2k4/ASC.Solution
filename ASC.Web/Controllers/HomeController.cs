using System.Diagnostics;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc;
using ASC.Web.Models;
using ASC.Web.Configuration;
using ASC.Web.Services;
namespace ASC.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private IOptions<ApplicationSettings> _settings;

    public HomeController(ILogger<HomeController> logger, IOptions<ApplicationSettings> settings)
    {
        _logger = logger;
        _settings = settings;
    }

    //public IActionResult Index()
    //{
    //    ViewBag.Title = _settings.Value.ApplicationTitle;
    //    return View();
    //}

    public IActionResult Index([FromServices] IEmailSender emailSender)
    {
        var emailService = this.HttpContext.RequestServices
    .GetService(typeof(IEmailSender)) as IEmailSender;

        ViewBag.Title = _settings.Value.ApplicationTitle;
        return View();
    }


    public IActionResult Privacy()
    {
        return View();
    }
    public IActionResult Dashboard()
    {
        return View();
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}