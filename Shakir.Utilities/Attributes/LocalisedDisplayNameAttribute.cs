using System; 
using System.Resources;

namespace Shakir.Utilities.Attributes
{
    public class LocalisedDisplayNameAttribute : DisplayNameAttribute
    {
        #region Members
         
        private readonly ResourceManager _resource;

        #endregion


        #region Constructor

        public LocalisedDisplayNameAttribute(string displayNameKey, Type resourceType)
            : base(displayNameKey)
        {
            _resource = new ResourceManager(resourceType);
        }

        #endregion


        #region Properties
         
        public override string DisplayName {
            get
            {
                var displayName = _resource.GetString(base.DisplayName, null);
                return string.IsNullOrEmpty(displayName)
                    ? $"[[{base.DisplayName}]]"
                    : displayName;
            }
        }

    #endregion
    }
}
