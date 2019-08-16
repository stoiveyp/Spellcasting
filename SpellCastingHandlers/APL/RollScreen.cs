using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Alexa.NET.APL;
using Alexa.NET.APL.Commands;
using Alexa.NET.APL.Components;
using Alexa.NET.Response.APL;
using SpellCastingLogic;

namespace SpellCastingHandlers.APL
{
    public static class RollScreen
    {
        public static APLDocument Generate(DiceRollerResult result)
        {
            //TODO: Get it to play <audio src="soundbank://soundlibrary/toys_games/board_games/board_games_08"/>
            var doc = new APLDocument(APLDocumentVersion.V1_1);
            Import.AlexaLayouts.Into(doc);

            doc.Commands = new Dictionary<string, CommandDefinition>{{"rollIn", RollInCommand}};

            doc.MainTemplate = new Layout(new AlexaHeadline
            {
                BackgroundImageSource = "https://rollcasterassets.s3-eu-west-1.amazonaws.com/backg_shrunk.jpg",
                BackgroundBlur = true,
                HeaderBackButton = false,
                PrimaryText = $"You rolled {result.Total}",
                SecondaryText = string.Join(" + ", result.Dice.Select(d => d.ToString())),
                OnMount = new APLValue<IList<APLCommand>>(new APLCommand[] { new Transition("rollIn", 2000) })
            }).AsMain();
            return doc;
        }

        public static CommandDefinition RollInCommand => new CommandDefinition
        {
            Parameters = new List<Parameter>
            {
                new Parameter("delay"),
                new Parameter("duration")
            },
            Commands = new List<APLCommand>
            {
                new AnimateItem
                {
                    Duration = APLValue.To<int?>("${duration}"),
                    DelayMilliseconds = APLValue.To<int?>("${delay || 0}"),
                    Value = new List<AnimatedProperty>
                    {
                        new AnimatedOpacity{From=0,To=1},
                        new AnimatedTransform{
                            From = new List<APLTransform>
                            {
                                new APLTransform
                                {
                                    TranslateX = APLValue.To<double?>("-100%"),
                                    Rotate = -120
                                }
                            },
                            To = new List<APLTransform>
                            {
                                new APLTransform
                                {
                                    TranslateX = 0,
                                    Rotate = 0
                                }
                            },
                        }
                    }
                }
            }
        };
    }
}
