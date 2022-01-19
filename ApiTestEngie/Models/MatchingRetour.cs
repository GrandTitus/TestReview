using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiTestEngie.Models
{
    /// <summary>
    ///  Returns all the functions of the web api
    /// </summary>
    public class MatchingRetour
    {
        public MatchingRetour()
        {
            MatchingInformation = new List<string>();
        }
        /// <summary>
        /// Indicates whether the specified regular expression matches the specified input string.
        /// </summary>
        public bool IsMatch { get; set; }

        /// <summary>
        /// Searches the specified input string for all occurrences of an expression
        /// </summary>
        public IList<string> MatchingInformation { get; set; }

        /// <summary>
        /// replaces all strings that match a regular expression pattern with a specified replacement string.
        /// </summary>
        public string Substitution { get; set; }
    }
}