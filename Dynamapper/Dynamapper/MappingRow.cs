namespace Dynamapper
{
    /// <summary>
    /// Mapping Row Class Definition for a dynamic data row
    /// </summary>
    public class MappingRow
    {
        /// <summary>
        /// Gets or sets Row Key Name
        /// </summary>
        public string KeyName { get; set; }

        /// <summary>
        /// Gets or sets Row Index
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// Gets or sets Row Object Value
        /// </summary>
        public object Value { get; set; }
    }
}
