
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Assignment7.Models
{
    public class CatAppointmentSetup
    {
        public int MeetingID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string PetName { get; set; }
        public string MeetingDay { get; set; }
        public string MeetingTime { get; set; }


    }
}
