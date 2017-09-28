namespace DbShell.Core.Utility
{
    /// <summary>
    /// Quoting mode for CSV files - determines, how strings are quoted
    /// </summary>
    public enum CsvQuotingMode
    {
        /// <summary>
        /// All fields are quoted
        /// </summary>
        Always,
        /// <summary>
        /// All fields except numbers are quoted
        /// </summary>
        AlwaysExceptNumbers,
        /// <summary>
        /// Quoting marks are used only of necessary
        /// </summary>
        OnlyIfNecessary,
        /// <summary>
        /// Never use quoting marks
        /// </summary>
        Never,
    }
}