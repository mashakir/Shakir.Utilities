using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using NUnit.Framework;
using Rhino.Mocks;
using Shakir.Utilities.Helpers;

namespace Shakir.Utilities.Tests.Helpers
{
    [TestFixture]
    public class IpAddressHelperTests
    {
        #region Private variables

        private IpAddressHelper _ipAddressHelper;
        private HttpRequestBase _httpRequest;

        private const string Ip = "1.2.3.4";
        private const string ForwardedIp = "5.6.7.8";
        private const string LastForwardedIp = "2.4.6.8";
        private const string XForwardedFor = "X_FORWARDED_FOR";

        #endregion

        #region SetUp

        [SetUp]
        public void SetUp()
        {
            _ipAddressHelper = new IpAddressHelper();
            _httpRequest = MockRepository.GenerateMock<HttpRequestBase>();
        }

        #endregion

        #region Tests

        [Test]
        public void GetClientIpAddressShouldReturnIpAddress()
        {
            _httpRequest.Expect(x => x.UserHostAddress)
                .Return(Ip);

            _httpRequest.Expect(x => x.ServerVariables[XForwardedFor])
                .Return(null);

            var result = _ipAddressHelper.GetClientIpAddress(_httpRequest);

            Assert.That(result.Equals(Ip));
        }

        [Test]
        public void GetClientIpAddressShouldReturnForwardedIpAddressIfAny()
        {
            _httpRequest.Expect(x => x.UserHostAddress)
                .Return(Ip);

            _httpRequest.Expect(x => x.ServerVariables[XForwardedFor])
                .Return(ForwardedIp);

            var result = _ipAddressHelper.GetClientIpAddress(_httpRequest);

            Assert.That(result.Equals(ForwardedIp));
        }

        [Test]
        public void GetClientIpAddressShouldReturnLastForwardedIpAddress()
        {
            _httpRequest.Expect(x => x.UserHostAddress)
                .Return(Ip);

            _httpRequest.Expect(x => x.ServerVariables[XForwardedFor])
                .Return(ForwardedIp + "," + LastForwardedIp);

            var result = _ipAddressHelper.GetClientIpAddress(_httpRequest);

            Assert.That(result.Equals(LastForwardedIp));
        }

        #endregion
    }
}
