using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Form14242.Web.ViewModels
{
    public class Artifact
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string ContentType { get; set; }

        public byte[] FileContents { get; set; }
    }
}