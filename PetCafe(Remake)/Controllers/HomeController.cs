using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PetCafe_Remake_.Helper;
using PetCafe_Remake_.Interface;
using PetCafe_Remake_.Models;
using PetCafe_Remake_.ViewModels;
using System.Diagnostics;
using System.Globalization;
using System.Net;

namespace PetCafe_Remake_.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEventRepository _eventRepository;

        public HomeController(ILogger<HomeController> logger, IEventRepository eventRepository)
        {
            _logger = logger;
            _eventRepository = eventRepository;
        }

        public async Task<IActionResult> Index()
        {
            var homeViewModel = new HomeViewModel(); //to object to homeview

            var ipInfo = new IPInfo(); //receive api object
            try
            {
                string url = "https://ipinfo.io?token=ef39cfa51cac8d";   // api endpoint
                var info = new WebClient().DownloadString(url);          // downaload from link
                ipInfo = JsonConvert.DeserializeObject<IPInfo>(info);    // to change json to be a object
                //RegionInfo myRI1 = new RegionInfo(ipInfo.Country);       //using RegionInfo object (globalization)
                //ipInfo.Country = myRI1.EnglishName;
                homeViewModel.Region = ipInfo.Region;                        //passing value
                if (homeViewModel.Region != null)                          
                {
                    homeViewModel.Events = await _eventRepository.GetEventByCity(homeViewModel.Region);
                }
                else
                {
                    homeViewModel.Events = null;
                }
                return View(homeViewModel);
            }
            catch (Exception ex)
            {
                homeViewModel.Events = null;

            }


            return View(homeViewModel);
            }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}