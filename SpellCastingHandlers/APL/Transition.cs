using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Alexa.NET.APL.Commands;

namespace SpellCastingHandlers.APL
{
    public class Transition:CustomCommand
    {
        public Transition(string name, int duration):base(name)
        {
            ParameterValues = new Dictionary<string, object>{
            {
                "duration",duration
            }};
        }

        public int Delay { get; }
    }
}
