using System;

namespace XMLSerializerCommon.Models
{
    public class RequestApiModel
    {
        /// <summary>
        /// Person index.
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// Person name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Count of visits. Nullable.
        /// </summary>
        public int? Visits { get; set; }

        /// <summary>
        /// Date Last of visit.
        /// </summary>
        public DateTime Date { get; set; }
    }
}