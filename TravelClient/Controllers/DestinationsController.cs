using Microsoft.AspNetCore.Mvc;
using TravelClient.Models;


namespace TravelClient.Controllers;

public class DestinationsController : Controller
{
  public IActionResult Index()
  {
    List<Destination> destinations = Destination.GetDestinations();
    return View(destinations);
  }


public IActionResult Get(string cityName, string countryName, int rating)
    {
        List<Destination> filteredDestinations = Destination.GetDestinations()
            .Where(d =>
                (d.CityName.Contains(cityName)) 
                // && (string.IsNullOrEmpty(countryName) || d.CountryName.Contains(countryName)) &&
                // (rating <= 0 || d.Rating == rating)
                )
            .ToList();

        ViewBag.cityName = cityName;
        return View(filteredDestinations);
    }

  public IActionResult Details(int id)
  {
    Destination destination = Destination.GetDetails(id);
    return View(destination);
  }
   public ActionResult Create()
  {
    return View();
  }

  [HttpPost]
  public ActionResult Create(Destination destination)
  {
    Destination.Post(destination);
    return RedirectToAction("Index");
  }
  public ActionResult Edit(int id)
  {
    Destination destination = Destination.GetDetails(id);
    return View(destination);
  }

  [HttpPost]
  public ActionResult Edit(Destination destination)
  {
    Destination.Put(destination);
    return RedirectToAction("Details", new { id = destination.DestinationId});
  }
  public ActionResult Delete(int id)
  {
    Destination destination = Destination.GetDetails(id);
    return View(destination);
  }

  [HttpPost, ActionName("Delete")]
  public ActionResult DeleteConfirmed(int id)
  {
    Destination.Delete(id);
    return RedirectToAction("Index");
  }
}

