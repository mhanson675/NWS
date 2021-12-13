using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NWS.Models.Serializing.STJ.Policies
{
    public class ObjectIdentifierNamingPolicy : JsonNamingPolicy
    {
        private readonly string[] specialPropertyNames = new []{"type", "id", "graph"};
        public override string ConvertName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return name;
            }

            if (!specialPropertyNames.Contains(name.ToLowerInvariant()))
            {
                return ToCamelCase(name);
            }

            return "@" + ToCamelCase(name);
        }

        private string ToCamelCase(string name)
        {
            if (!char.IsUpper(name[0]))
            {
                return name;
            }

            char[] chars = name.ToCharArray();
            FixCasing(chars);
            return new string(chars);
        }

        private static void FixCasing(Span<char> chars)
        {
            for (int i = 0; i < chars.Length; i++)
            {
                if (i == 1 && !char.IsUpper(chars[i]))
                {
                    break;
                }

                bool hasNext = (i + 1 < chars.Length);

                // Stop when next char is already lowercase.
                if (i > 0 && hasNext && !char.IsUpper(chars[i + 1]))
                {
                    // If the next char is a space, lowercase current char before exiting.
                    if (chars[i + 1] == ' ')
                    {
                        chars[i] = char.ToLowerInvariant(chars[i]);
                    }

                    break;
                }

                chars[i] = char.ToLowerInvariant(chars[i]);
            }
        }
    }
}
