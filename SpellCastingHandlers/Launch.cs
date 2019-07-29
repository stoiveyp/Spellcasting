using Alexa.NET;
using Alexa.NET.Request;
using Alexa.NET.RequestHandlers;
using Alexa.NET.RequestHandlers.Handlers;
using Alexa.NET.Response;

namespace SpellCastingHandlers
{
    public class Launch:LaunchSynchronousRequestHandler<APLSkillRequest>
    {
        private readonly string _launchText;
        private const string Reprompt = "How many dice would you like me to roll?";

        public Launch(string appName) : base()
        {
            _launchText = $"Welcome to {appName}, how many dice would you like me to roll?";
        }

        public override SkillResponse HandleSyncRequest(AlexaRequestInformation<APLSkillRequest> information)
        {
            return ResponseBuilder.Ask(
                _launchText,
                new Reprompt(Reprompt));
        }
    }
}
