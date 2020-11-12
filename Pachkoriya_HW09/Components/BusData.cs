using Microsoft.AspNetCore.Mvc;
using Pachkoriya_HW09.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pachkoriya_HW09.Components
{
    public class BusData : ViewComponent
    {
        private readonly BusRepository _busRepository;

        public BusData(BusRepository busRepository)
        {
            this._busRepository = busRepository;
        } // BusData

        public IViewComponentResult Invoke(bool sortPassengersBySeatNum, bool sortPassengersBySurnameNP)
        {
            BusViewModel busViewModel = new BusViewModel
            {
                Bus = _busRepository.Bus,
                SortPassengersBySeatNum = sortPassengersBySeatNum,
                SortPassengersBySurnameNP = sortPassengersBySurnameNP
            };

            return View(busViewModel);
        } // Invoke
    }
}
