using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alexa.NET.Request;
using Alexa.NET.RequestHandlers;
using Alexa.NET.Response;
using Amazon.Lambda.Core;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace SpeechOnly
{
    public class Function
    {
        private AlexaRequestPipeline _pipeline = new AlexaRequestPipeline();

        public Task<SkillResponse> FunctionHandler(APLSkillRequest input, ILambdaContext context)
        {
            return _pipeline.Process(input);
        }
    }
}
