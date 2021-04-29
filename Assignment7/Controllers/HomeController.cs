using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Assignment7.Models;

namespace Assignment7.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PetViewing()
        {
            return View();
        }
        
        public IActionResult Employment()
        {
            return View();
        }

        public IActionResult Support()
        {
            return View();
        }

        public IActionResult Events()
        {

            return View();
        }

        public IActionResult Benefits()
        {

            return View();
        }

        [HttpGet]
        public IActionResult CatAppointmentSetup()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CatAppointmentSetup(CatAppointmentSetup userCatAppointment)
        {
            if (ModelState.IsValid)
            {
                CatMeetingRepository.AddAppointment(userCatAppointment);

                return View("CatAppointmentThankYou", userCatAppointment);
            }
            else
            {
                return View();
            }
        }

        public IActionResult ListCatAppointment()
        {
            return View(CatMeetingRepository.UserCatAppointments);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
