using MessageTemplateProcessor.Processor;
using MessageTemplateProcessor.Tests.Templates;
using System;
using System.Collections.Generic;
using Xunit;

namespace MessageTemplateProcessor.Tests
{
    public class ProcessTemplateFuncTests
    {
        [Fact]
        public void SmallInputFuncTest()
        {
            var dict = new Dictionary<string, string>()
            {
                { "token1", "Cole" },
                { "token2", "Ditchman" }
            };

            var res = TextTemplates.ShortText.ProcessTemplate((x) => 
            {
                return dict.TryGetValue(x, out var value) ? value : string.Empty;
            });

            Assert.Equal("The quick lazy fox Cole through the gate Ditchman reached the house", res);
        }

        [Fact]
        public void SmallInputMultiCaseFuncTest()
        {
            var dict = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase)
            {
                { "ToKeN1", "Cole" },
                { "TOKEN2", "Ditchman" }
            };

            var res = TextTemplates.ShortText.ProcessTemplate((x) =>
            {
                return dict.TryGetValue(x, out var value) ? value : string.Empty;
            });

            Assert.Equal("The quick lazy fox Cole through the gate Ditchman reached the house", res);
        }

        [Fact]
        public void SmsMultiWordTokenFuncTest()
        {
            var dict = new Dictionary<string, string>()
            {
                { "client name", "Cole" },
                { "meeting date", "03/24/1988" },
                { "assigned accountant", "John Doe" },
                { "link", "https://www.scorpion.co/technology/#~8K1k4c4" }
            };

            var res = TextTemplates.SmsTemplate.ProcessTemplate((x) =>
            {
                return dict.TryGetValue(x, out var value) ? value : string.Empty;
            });

            Assert.Equal(TextTemplateResponses.SmsMultiWordTokenTestResult, res);
        }

        [Fact]
        public void MediumSizeRecruiterEmailFuncTest()
        {
            var dict = new Dictionary<string, string>()
            {
                { "day name", "Thursday" },
                { "applicant name", "Cole" },
                { "recruiter name", "John Doe" },
                { "personal message", "I'm impressed, Cole! 5 years at a place is not common amongst Engineers. Allscripts must treat you well :)" },
                { "req link", "https://www.getscorpion.com/careers/job/?jobid=630" },
                { "salary range", "$130K - $170K/yr" },
                { "signature", @"John Doe
Talent Acquisition Manager
Scorpion.co
Scorpion
27750 Entertainment Drive
Valencia, CA 91355" }
            };

            var res = TextTemplates.RecruiterEmail.ProcessTemplate((x) =>
            {
                return dict.TryGetValue(x, out var value) ? value : string.Empty;
            });

            Assert.Equal(TextTemplateResponses.MediumSizeRecruiterEmailTestResult, res);
        }
    }
}
