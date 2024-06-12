using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net;
using TicketAppObilet.Models;

namespace TicketAppObilet.Controllers
{
    public class HomeController : Controller
    {

        private readonly TicketService _ticketService;
        private readonly IMemoryCache _memoryCache;
        public HomeController(TicketService ticketService, IMemoryCache memoryCache)
        {
            _ticketService = ticketService;
            _memoryCache = memoryCache;
        }

        public async Task<IActionResult> Index()
        {

            IndexVM vm = _ticketService.GetBusLocations();

            if (string.IsNullOrEmpty(vm.UserMessage) && string.IsNullOrEmpty(vm.ErrorMessage)) return View(vm);


            TempData["Message"] = vm.UserMessage;
            TempData["Message"] += vm.ErrorMessage;
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Journey(IndexVM model)
        {

            JourneyDTO journeyDTO = new JourneyDTO()
            {
                Data = new JourneyRequestData()
                {
                    DepartureDate = model.DepartureDate.ToString("yyyy-MM-dd"),
                    DestinationID = model.DestinationID,
                    OriginID = model.OriginID
                },
                Date = DateTime.Now,
            };

            JourneyVM vm = _ticketService.GetBusJourneys(journeyDTO);
            TempData["JourneyData"] = JsonConvert.SerializeObject(journeyDTO);



            if (string.IsNullOrEmpty(vm.UserMessage) && string.IsNullOrEmpty(vm.ErrorMessage)) return View(vm);


            TempData["Message"] = vm.UserMessage;
            TempData["Message"] += vm.ErrorMessage;
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Journey()
        {
            if (TempData["JourneyData"] != null)
            {
                var dto = JsonConvert.DeserializeObject<JourneyDTO>(TempData["JourneyData"].ToString());
                JourneyVM vm = _ticketService.GetBusJourneys(dto);
                return View(vm);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult JourneyDetails(string journeyJson)
        {
            var journey = JsonConvert.DeserializeObject<JourneyResponseData>(journeyJson);
            var model = new JourneyDetailsVM { Journey = journey };
            return View(model);
        }

    }
}
