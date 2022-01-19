using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ApiTestEngie.Models
{
    public class AllRequestData : RequestData
    {
        /// <summary>
        /// Pattern substitution for replacement
        /// </summary>
        [Required]
        public string PatternSubstitution { get; set; }
    }
}