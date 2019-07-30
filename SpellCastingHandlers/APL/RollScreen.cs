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
            new Import
                {
                    Name = "transitions",
                    Version = "1.0.0",
                    Source = "https://rollcasterassets.s3-eu-west-1.amazonaws.com/apl_transitions.json"
                }
                .Into(doc);

            doc.MainTemplate = new Layout(new AlexaHeadline
            {
                BackgroundImageSource = "https://rollcasterassets.s3-eu-west-1.amazonaws.com/backg_shrunk.jpg",
                BackgroundBlur = true,
                HeaderBackButton = false,
                PrimaryText = $"You rolled {result.Total}",
                SecondaryText = string.Join(" + ", result.Dice.Select(d => d.ToString())),
                OnMount = new APLValue<IList<APLCommand>>(new APLCommand[] {new Transition("rollIn",2000)})
            }).AsMain();
            return doc;
        }
    }
}
