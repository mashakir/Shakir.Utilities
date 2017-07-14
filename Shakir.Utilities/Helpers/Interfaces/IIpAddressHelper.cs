using System.Web;

namespace Shakir.Utilities.Helpers.Interfaces
{
    public interface IIpAddressHelper
    {
        string GetClientIpAddress(HttpRequestBase request);
    }
}
