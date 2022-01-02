
namespace MessageTemplateProcessor.Tests
{
    public class TextTemplates
    {
        public const string ShortText = "The quick lazy fox {{token1}} through the gate {{token2}} reached the house";

        public const string SmsTemplate = 
            "Hello, {{client name}}, this is {{assigned accountant}}. " +
            "Before our next meeting on {{meeting date}}, please fill out those forms we talked about. " +
            "You’ll find them on our secure online portal at {{link}}. Reply with STOP to stop receiving texts.";

        public const string RecruiterEmail = @"Happy {{day name}}, {{applicant name}} -

My name is {{recruiter name}}, and I’m part of the Hiring Team here at Scorpion, a 1,200-person, pre-IPO marketing software company.

{{personal message}}

I see that you're open to work, and I'm wondering if you'd be interested in the following role with us: {{req link}}

This is a fully-remote, full-time role with us. We're offering a salary range of {{salary range}}. DOE, unlimited PTO, 100% paid medical benefits for you, stock options, and more that I can go over.

If this role interests you, would you be open to a phone interview with me?

Cheers,

{{signature}}";
    }
}
