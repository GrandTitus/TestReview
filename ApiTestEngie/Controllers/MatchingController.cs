using ApiTestEngie.Filters;
using ApiTestEngie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Http;


namespace ApiTestEngie.Controllers
{
    [Authorize]
    [ErrorExceptionFilter]
    public class MatchingController : ApiController
    {
        /// <summary>
        /// Returns all the functions of the web api: ISMatch, MatchingInformation, Substitution
        /// </summary>
        /// <param name="requestData">Text + Expression + Pattern Substitution</param>
        /// <returns>Object contains ISMatch, MatchingInformation, Substitution</returns>
        [System.Web.Http.HttpPost]
        public IHttpActionResult RegexAll(AllRequestData requestData)
        {
            if (requestData.PatternSubstitution == null || requestData.StringText == null || requestData.RegularExpression == null)
            {
                throw new ArgumentNullException();
            }
            try
            {
                MatchingRetour matchingRetour = new MatchingRetour();                
                matchingRetour.IsMatch = DataRegexIsMatching(requestData);
                matchingRetour.MatchingInformation = DataRegexMatchingInformation(requestData);
                matchingRetour.Substitution = DataRegexSubstitution(requestData);
                return Ok(matchingRetour);
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }

        #region Is Match

        /// <summary>
        /// return if the expression matches the text
        /// </summary>
        /// <param name="requestData">Text + Expression</param>
        /// <returns>boolean isMatch</returns>
        [System.Web.Http.HttpPost]
        public IHttpActionResult RegexIsMatching(RequestData requestData)
        {
            if (requestData.StringText == null || requestData.RegularExpression == null)
            {
                throw new ArgumentNullException();
            }
            try
            {
                Regex rgx = new Regex(requestData.RegularExpression, RegexOptions.Multiline);
                return Ok(DataRegexIsMatching(requestData));
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }

        }

        /// <summary>
        /// return if the expression matches the text
        /// </summary>
        /// <param name="requestData">Text + Expression</param>
        /// <returns>boolean isMatch</returns>
        private bool DataRegexIsMatching(RequestData requestData)
        {
            Regex rgx = new Regex(requestData.RegularExpression, RegexOptions.Multiline);
            return rgx.IsMatch(requestData.StringText);
        }
        #endregion

        #region Matching Information

        /// <summary>
        /// return a list of Matching Information of the expression against the text
        /// </summary>
        /// <param name="requestData">Text + Expression</param>
        /// <returns>list of Matching Information</returns>
        [System.Web.Http.HttpPost]
        public IHttpActionResult RegexMatchingInformation(RequestData requestData)
        {
            if (requestData.StringText == null || requestData.RegularExpression == null)
            {
                throw new ArgumentNullException();
            }
            try
            {
                return Ok(DataRegexMatchingInformation(requestData));
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// return a list of Matching Information of the expression against the text
        /// </summary>
        /// <param name="requestData">Text + Expression</param>
        /// <returns>list of Matching Information</returns>
        private IList<string> DataRegexMatchingInformation(RequestData requestData)
        {
            List<string> ListPhoneNbr = new List<string>();
            RegexOptions options = RegexOptions.Multiline;
            foreach (Match mtch in Regex.Matches(requestData.StringText, requestData.RegularExpression, options))
            {
                ListPhoneNbr.Add(mtch.Value);
            }
            return ListPhoneNbr;
        }
        #endregion


        #region Substitution

        /// <summary>
        /// replaces all strings that match a regular expression pattern with a specified replacement string.
        /// </summary>
        /// <param name="requestData">Text + Expression + Pattern Substitution</param>
        /// <returns>Text replace by pattern</returns>
        [System.Web.Http.HttpPost]
        public IHttpActionResult RegexSubstitution(AllRequestData requestData)
        {
            if (requestData.PatternSubstitution == null || requestData.StringText == null || requestData.RegularExpression == null)
            {
                throw new ArgumentNullException();
            }
            try
            {
                return Ok(DataRegexSubstitution(requestData));
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// replaces all strings that match a regular expression pattern with a specified replacement string.
        /// </summary>
        /// <param name="requestData">Text + Expression + Pattern Substitution</param>
        /// <returns>Text replace by pattern</returns>
        private string DataRegexSubstitution(AllRequestData requestData)
        {
            RegexOptions options = RegexOptions.Multiline;
            Regex regex = new Regex(requestData.RegularExpression, options);
            return regex.Replace(requestData.StringText, requestData.PatternSubstitution);
        }
        #endregion
    }
}