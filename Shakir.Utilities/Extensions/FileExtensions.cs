using System.IO;

namespace Shakir.Utilities.Extensions
{
    public static class FileExtensions
    {
        public static byte[] ToByteArray(this Stream input)
        {
            using (var memory = new MemoryStream())
            {
                input.CopyTo(memory);
                return memory.ToArray();
            }
        }
    }
}
