using System;
using System.IO;

namespace RazorEngine.Templating
{
    /// <summary>
    /// Defines the required contract for implementing a template.
    /// </summary>
    public interface ITemplate
    {
        #region Properties

        /// <summary>
        /// Current output stream
        /// </summary>
        Action<string> Output { get; set; }

        /// <summary>
        /// Gets or sets the template service.
        /// </summary>
        TemplateService Service { get; set; }
        #endregion

        #region Methods

        void Clear();

        /// <summary>
        /// Executes the compiled template.
        /// </summary>
        void Execute();

        /// <summary>
        /// Writes the specified object to the template result.
        /// </summary>
        /// <param name="object">The object to write.</param>
        void Write(object @object);

        /// <summary>
        /// Writes the specified string to the template result.
        /// </summary>
        /// <param name="string">The string to write.</param>
        void WriteLiteral(string @string);
        #endregion
    }
}