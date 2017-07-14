using Shakir.Utilities.Helpers.Interfaces;

namespace Shakir.Utilities.Helpers
{
    public class EnumMapperHelper : IEnumMapperHelper
    {
        #region Constructor

        public EnumMapperHelper(object enumValue, string enumDescription, string enumDatabaseCode)
        {
            Enum = enumValue;
            Description = enumDescription;
            DatabaseCode = enumDatabaseCode;
        }

        #endregion


        #region Properties

        public object Enum { get; }

        public string Description { get; }

        public string DatabaseCode { get; }

        #endregion
    }
}
