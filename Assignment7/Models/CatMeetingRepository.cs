using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment7.Models
{
    public class CatMeetingRepository
    {
        private static List<CatAppointmentSetup> userCatAppointments = new List<CatAppointmentSetup>();

        public static IEnumerable<CatAppointmentSetup> UserCatAppointments
        {
            get { return userCatAppointments; }
        }

        public static void AddAppointment(CatAppointmentSetup userCatAppointment)
        {
            userCatAppointments.Add(userCatAppointment);

        }

    }
}
