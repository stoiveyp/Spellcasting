using Newtonsoft.Json;

namespace SpellCastingLogic
{
    public class DiceRollerRequest
    {
        public DiceRollerRequest(int number, int sides, int? modifier = null)
        {
            Number = number;
            Sides = sides;
            Modifier = modifier;
        }

        [JsonProperty("modifier")]
        public int? Modifier { get; }

        [JsonProperty("sides")]
        public int Sides { get; }

        [JsonProperty("number")]
        public int Number { get; }
    }
}