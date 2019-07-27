using System.Linq;
using Newtonsoft.Json;

namespace SpellCastingLogic
{
    public class DiceRollerResult
    {
        public DiceRollerResult() { }
        public DiceRollerResult(DiceRollerRequest request, int[] dice, int? modifier = null)
        {
            Request = request;
            Dice = dice;
            Modifier = modifier;
        }

        [JsonProperty("request")]
        public DiceRollerRequest Request { get; set; }

        [JsonProperty("dice")]
        public int[] Dice { get; }
        [JsonProperty("modifier",NullValueHandling = NullValueHandling.Ignore)]
        public int? Modifier { get; }

        [JsonIgnore]
        public int Total => Dice.Sum() + (Modifier ?? 0);

    }
}