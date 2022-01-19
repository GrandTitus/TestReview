using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ApiTestEngie.Models
{
    public class RequestData 
    {
        /// <summary>
        /// Regular expression to apply on the text
        /// </summary>
        [Required]
        public string RegularExpression { get; set; }
        /// <summary>
        /// Text string to which the regular expression applies
        /// </summary>
        [Required]
        public string StringText { get; set; }

    }
}