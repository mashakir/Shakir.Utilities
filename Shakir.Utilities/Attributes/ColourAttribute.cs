using System;
using System.Drawing;

namespace Shakir.Utilities.Attributes
{
    /// <summary>
    /// Attribute for adding localisable information to an enumeration
    /// </summary>
    public class ColourAttribute : Attribute
    {
        public ColourAttribute(string color)
        {
            Colour = Color.FromName(color);
        }

        /// <summary>
        /// Gets or sets the type in which to locate the resource
        /// </summary>
        /// <value>The type of the resource.</value>
        public Color Colour { get; set; }

    }
}
