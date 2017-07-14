using System;

namespace Shakir.Utilities.Attributes
{
    public class DisplayNameAttribute : Attribute
    {
        #region Constructor

        public DisplayNameAttribute(string displayName)
        {
            DisplayName = displayName;
        }

        #endregion
        
        #region Properties

        public virtual string DisplayName { get; }

        #endregion
    }
}
