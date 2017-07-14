using System;

namespace Shakir.Utilities.Attributes
{
    /// <summary>
    /// Attribute for specifying a database code value for an attribute
    /// </summary>
    public class DatabaseCodeAttribute : Attribute
    {
        public DatabaseCodeAttribute(string code)
        {
            if (string.IsNullOrEmpty(code))
                throw new InvalidOperationException();

            Code = code;
        }

        /// <summary>
        /// Gets or sets the database code.
        /// </summary>
        /// <value>The code.</value>
        public string Code { get; }
    }
}
