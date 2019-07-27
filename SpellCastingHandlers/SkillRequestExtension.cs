using System;
using System.Collections.Generic;
using Alexa.NET.Request;
using Alexa.NET.Request.Type;

namespace SpellCastingHandlers
{
    public static class SkillRequestExtension
    {
        public static bool IsIntentName<T>(this T request, string intentName) where T:SkillRequest
        {
            return request.Request is IntentRequest intent &&
                   intent.Intent.Name.Equals(intentName, StringComparison.OrdinalIgnoreCase);
        }

        public static int GetInt(this Dictionary<string, Slot> slots, string key)
        {
            if (!slots.ContainsKey(key) || slots[key] == null || string.IsNullOrWhiteSpace(slots[key].Value))
            {
                return 0;
            }

            return int.TryParse(slots[key].Value, out int result) ? result : 0;
        }

        public static void AddIfNotExist(this Dictionary<string, Slot> slots, string slotName, string value)
        {
            if (!slots.ContainsKey(slotName))
            {
                slots.Add(slotName,new Slot{Name=slotName,Value=value});
                return;
            }

            if (slots[slotName] == null)
            {
                slots[slotName] = new Slot {Name = slotName, Value = value};
                return;
            }

            if (string.IsNullOrWhiteSpace(slots[slotName].Value))
            {
                slots[slotName].Value = value;
            }
        }
    }
}
