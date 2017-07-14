namespace Shakir.Utilities.Utiltiies.Interfaces
{
    public interface IXmlUtility
    {
        /// <summary>
        /// Validates the XML.
        /// </summary>
        /// <param name="xml">The XML document.</param>
        /// <param name="xsdFile">The XML schema file.</param>
        /// <param name="error">The validation error.</param>
        /// <returns>Returns a boolean whether it is validated or not.</returns>
        bool IsValidXml(string xml, string xsdFile, out string error);
    }
}
