using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pachkoriya_HW09.Models;

namespace Pachkoriya_HW09.Controllers
{
    public class BusController : Controller
    {
        private BusRepository _busRepository;

        public BusController(BusRepository busRepository)
        {
            _busRepository = busRepository;
        } // BusController

        // GET: BusController
        public ActionResult Index()
        {
            return View();
        }

        // Вывести данные автобуса и список пассажиров по номеру места
        public IActionResult SortPassengersBySeatNumber()
            => View();

        // Вывести данные автобуса и список пассажиров в алфавитном порядке
        public IActionResult SortPassengersBySurnameNP()
            => View();

        public IActionResult AddPassenger()
        {
            return View();
        } // AddPassenger

        [HttpPost]
        [ValidateAntiForgeryToken]
        // Добавить пассажира
        public IActionResult AddPassenger(Passenger passenger)
        {
            if (ModelState.IsValid)
            {
                _busRepository.Bus.AddPassenger(passenger);
                _busRepository.SerializeBus();
                return RedirectToAction("Index");
            }
            
            return View(passenger);
        } // AddPassenger

        // GET: BusController/Edit/5
        public ActionResult EditBus()
        {
            if (_busRepository.Bus == null)
            {
                return View("Error");
            }
            return View(_busRepository.Bus);
        }

        // POST: BusController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditBus(Bus bus)
        {
            try
            {
                _busRepository.EditBus(bus);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(bus);
            }
        }

        // GET: BusController/Delete/5
        public ActionResult DeleteQuestion(Passenger passenger) => View(passenger);

        // POST: BusController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePassenger(int seatNumber)
        {
            Passenger passenger = _busRepository.Bus.Passengers.First(x => x.SeatNumber == seatNumber);
            _busRepository.Bus.DelPassenger(passenger);
            _busRepository.SerializeBus();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult TestError()
        {
            throw null;
            return View();
        }
    }
}
