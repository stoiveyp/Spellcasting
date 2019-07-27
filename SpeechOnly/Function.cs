using System.Threading.Tasks;
using Alexa.NET.Request;
using Alexa.NET.Request.Type;
using Alexa.NET.RequestHandlers;
using Alexa.NET.Response;
using Amazon.Lambda.Core;
using SpellCastingHandlers;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace SpeechOnly
{
    public class Function
    {
        private const string appName = "spell caster";
        private readonly AlexaRequestPipeline<APLSkillRequest> _pipeline = new AlexaRequestPipeline<APLSkillRequest>
        (
            new IAlexaRequestHandler<APLSkillRequest>[]
            {
                new Launch(appName),
                new Roll(),
                new RollAgain(),
                new Breakdown(),
                new Help(appName),
                new Fallback(),
                new SessionEnded()
            },
            new[]
            {
                new NoRequestHandlerFound()
            },
            new[]
            {
                new SessionStateInterceptor()
            }, null
        );


        public Task<SkillResponse> FunctionHandler(APLSkillRequest input, ILambdaContext _)
        {
            return _pipeline.Process(input);
        }
    }
}
