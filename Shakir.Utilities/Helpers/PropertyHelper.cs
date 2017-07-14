namespace Shakir.Utilities.Helpers
{
    public class PropertyHelper
    {
        public static object GetPropertyValue(object value, string path)
        {

            var currentType = value.GetType();

            foreach (var propertyName in path.Split('.'))
            {
                var property = currentType.GetProperty(propertyName);
                if (property == null) continue;
                if (value != null) 
                    value = property.GetValue(value, null); 

                currentType = property.PropertyType;
            }
            return value; 
        }
    }
}
