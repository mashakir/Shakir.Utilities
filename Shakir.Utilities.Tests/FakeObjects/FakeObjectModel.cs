using System; 
using Shakir.Utilities.Attributes;

namespace Shakir.Utilities.Tests.FakeObjects
{
    [Serializable]
    public class FakeObjectModel
    { 
        [LocalisedDisplayName("DisplayName", typeof(FakeResource))]
        public string Name { get; set; }
        public int Id { get; set; }

        public int UkCountryId { get; set; }

        public int SelectedCountryId { get; set; }
        [PhoneFormat(SelectedCountryPropertyName = "SelectedCountryId", DefaultCountryPropertyName = "UkCountryId", ErrorMessage = "Please provide a valid phone number.")]
        public string PhoneNumber { get; set; }

        public int? DependentProperty { get; set; }
        public object SecondOperand { get; set; }
    }
}
