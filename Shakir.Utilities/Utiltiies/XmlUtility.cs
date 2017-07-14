using System.IO;
using System.Xml.Linq;
using System.Xml.Schema;
using Shakir.Utilities.Utiltiies.Interfaces;

namespace Shakir.Utilities.Utiltiies
{
    public class XmlUtility: IXmlUtility
    {
        /// <summary>
        /// Validates the XML.
        /// </summary>
        /// <param name="xml">The XML document.</param>
        /// <param name="xsdFile">The XML schema file.</param>
        /// <param name="error">The validation error.</param>
        /// <returns>Returns a boolean whether it is validated or not.</returns>
        public bool IsValidXml(string xml, string xsdFile, out string error)
        {
            error = string.Empty;
            var myXDocument = XDocument.Parse(xml);
            var mySchemas = new XmlSchemaSet();
            mySchemas.Add(null, xsdFile);

            try
            {
                myXDocument.Validate(mySchemas, null);
            }
            catch (XmlSchemaValidationException xmlEx)
            {
                error = xmlEx.Message;
                return false;
            }
            catch (IOException ioEx)
            {
                error = ioEx.Message;
                return false;
            }

            return true;
        }
    }
}
