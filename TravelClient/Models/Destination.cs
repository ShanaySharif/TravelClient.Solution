using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TravelClient.Models
{
  public class Destination
  {
    public int DestinationId { get; set; }

    public string CityName { get; set; }
    public string CountryName { get; set; }
    public string Review { get; set; }
    public int Rating { get; set; }
    
    public static List<Destination> GetDestinations()
    {
        var apiCallTask = ApiHelper.GetAll();
        var result = apiCallTask.Result;

        JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
        List<Destination> destinationList = JsonConvert.DeserializeObject<List<Destination>>(jsonResponse.ToString());

        return destinationList;
    }

    public static Destination GetDetails(int id)
    {
        var apiCallTask = ApiHelper.Get(id);
        var result = apiCallTask.Result;

        JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
        Destination destination = JsonConvert.DeserializeObject<Destination>(jsonResponse.ToString());

        return destination;
    }
    public static void Post(Destination destination)
    {
      string jsonDestination = JsonConvert.SerializeObject(destination);
      ApiHelper.Post(jsonDestination);
    }
    public static void Put(Destination destination)
    {
      string jsonDestination = JsonConvert.SerializeObject(destination);
      ApiHelper.Put(destination.DestinationId, jsonDestination);
    }
    public static void Delete(int id)
    {
      ApiHelper.Delete(id);
    }
  }
}