using System;
using System.ComponentModel;
using System.Resources;

namespace Shakir.Utilities.Attributes
{
    public class LocalisedDescriptionAttribute : DescriptionAttribute
    {
        private readonly string _resourceKey;
        private readonly ResourceManager _resource;
        public LocalisedDescriptionAttribute(string resourceKey, Type resourceType)
        {
            _resource = new ResourceManager(resourceType);
            _resourceKey = resourceKey;
        }

        public override string Description
        {
            get
            {
                var displayName = _resource.GetString(_resourceKey);

                return string.IsNullOrEmpty(displayName)
                    ? $"[[{_resourceKey}]]"
                    : displayName;
            }
        }
    }
}
