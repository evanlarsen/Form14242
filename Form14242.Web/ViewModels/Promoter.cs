using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Form14242.Web.ViewModels
{
    public class Promoter
    {
        public int ID { get; set; }

        [DisplayName("Name of promoter")]
        public string Name { get; set; }

        [DisplayName("Social Security Number (SSN) of promoter")]
        public string SSN { get; set; }

        [DisplayName("Mailing address of promoter")]
        public string MailingAddress { get; set; }

        [DisplayName("Email address of promoter")]
        public string EmailAddress { get; set; }

        [DisplayName("Telephone number of promoter")]
        public string TelephoneNumber { get; set; }

        [DisplayName("Headquarter location of promoter")]
        public string HeadquarterLocation { get; set; }
    }
}