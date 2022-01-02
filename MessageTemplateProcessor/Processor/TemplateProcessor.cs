using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MessageTemplateProcessor.Processor
{
    /// <summary>
    /// TemplateProcessor handles converting premade text templates using '{{}}' as the token identifier
    /// </summary>
    public static class TemplateProcessor
    {
        private const string Expression = "{{(.+?)}}";

        /// <summary>
        /// Process message template replacing occurrences of tokens using the provided Dictionary for token value lookup
        /// </summary>
        /// <remarks>Token Lookup is Case Insensitive</remarks>
        /// <param name="message">Message template to process</param>
        /// <param name="tokenValues">Dictionary containing key-value pairs for processing message tokens</param>
        /// <returns>Processed message with tokens replaced</returns>
        public static string ProcessTemplate(this string message, Dictionary<string, string> tokenValues)
        {
            var caseInsensitiveDict = new Dictionary<string, string>(tokenValues, StringComparer.InvariantCultureIgnoreCase);

            return Regex.Replace(message,
                Expression,
                match => caseInsensitiveDict.TryGetValue(match.Groups[1].Value.ToLowerInvariant(), out var res) ? res : string.Empty,
                RegexOptions.IgnoreCase,
                TimeSpan.FromSeconds(2));
        }

        /// <summary>
        /// Process message template calling provided delegate for each token found
        /// </summary>
        /// <param name="message">Message template</param>
        /// <param name="tokenProcessor">Delegate function that is called for each token match to be used for matching</param>
        /// <returns>Processed message with tokens replaced</returns>
        public static string ProcessTemplate(this string message, Func<string, string> tokenProcessor)
        {
            return Regex.Replace(message,
                Expression,
                match => tokenProcessor(match.Groups[1].Value),
                RegexOptions.IgnoreCase,
                TimeSpan.FromSeconds(2));
        }
    }
}
