using Shakir.Utilities.Anonimisers.Interfaces;

namespace Shakir.Utilities.Anonimisers
{
    public class Anonimiser : IAnonimiser
    {
        public string Anonimise(string stringToAnonimise)
        {
            if (string.IsNullOrEmpty(stringToAnonimise))
                return stringToAnonimise;

            var length = stringToAnonimise.Length;
            return length > 2
                ? stringToAnonimise.Substring(0, 1) + new string('*', length - 2) +
                  stringToAnonimise.Substring(length - 1)
                : stringToAnonimise;
        }
    }
}
