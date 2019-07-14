using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace SpellCastingLogic
{
    public class DiceRoller
    {
        static readonly RandomNumberGenerator _generator = RandomNumberGenerator.Create();
        public static DiceRollerResult Roll(int number, int sides, int? modifier = null)
        {
            return Roll(new DiceRollerRequest(number, sides, modifier));
        }

        public static DiceRollerResult Roll(DiceRollerRequest request)
        {
            return new DiceRollerResult(
                Enumerable.Range(1, request.Number).Select(_ => CryptoRandom.Next(1, request.Sides)).ToArray(),
                request.Modifier);
        }
    }

    public class DiceRollerResult
    {
        public DiceRollerResult(int[] dice, int? modifier)
        {
            Dice = dice;
            Modifier = modifier;
        }
        public int[] Dice { get; }
        public int? Modifier { get; }

        public int Total => Dice.Sum() + Modifier.Value;

    }

    public class DiceRollerRequest
    {
        public DiceRollerRequest(int number, int sides, int? modifier)
        {
            Number = number;
            Sides = sides;
            Modifier = modifier;
        }

        public int? Modifier { get; }

        public int Sides { get; }

        public int Number { get; }
    }
}
