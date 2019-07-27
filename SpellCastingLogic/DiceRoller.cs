using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace SpellCastingLogic
{
    public class DiceRoller
    {
        public static DiceRollerResult Roll(int number, int sides, int? modifier = null)
        {
            return Roll(new DiceRollerRequest(number, sides, modifier));
        }

        public static DiceRollerResult Roll(DiceRollerRequest request)
        {
            return new DiceRollerResult(request,
                Enumerable.Range(1, request.Number).Select(_ => CryptoRandom.Next(1, request.Sides)).ToArray(),
                request.Modifier);
        }
    }
}
