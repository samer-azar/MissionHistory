using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionHistory.Model
{
    public class Rescuer
    {

        public int Id { get; set; }
        public int IdStation { get; set; }
        public int TeamNumber { get; set; }
        public bool IsEdj { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Nickname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfEnrollement { get; set; }
        public string MembershipCardNumber { get; set; }
        public string BloodType { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string MobileNumber { get; set; }
        public string EmailAddress { get; set; }
        public bool IsDriver { get; set; }
        public int Status { get; set; }
        
    }
}
