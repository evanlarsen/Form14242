using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Form14242.Web.ViewModels
{
    public class Preparer
    {
        public int ID { get; set; }

        [DisplayName("Name of preparer")]
        public string Name { get; set; }

        [DisplayName("Social Security Number (SSN) of preparer")]
        public string SSN { get; set; }

        [DisplayName("Mailing address of preparer")]
        public string MailingAddress { get; set; }

        [DisplayName("Telephone number of preparer")]
        public string TelephoneNumber { get; set; }
    }
}