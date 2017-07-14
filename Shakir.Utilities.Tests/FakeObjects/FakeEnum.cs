 
using System.ComponentModel;
using Shakir.Utilities.Attributes;

namespace Shakir.Utilities.Tests.FakeObjects
{
    public enum FakeEnum
    {
        [Description("Ok")]
        [DatabaseCode("113")]
        [Colour("Black")] 
        Ok = 200,
         
        NoDescription = 1
    }
}
