using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XMLSerializerApi.Models
{
    /// <summary>
    /// Model with visitors data for specific person.
    /// </summary>
    [Table("Requests")]
    public class RequestModel
    {

        /// <summary>
        /// Unique identifier.
        /// </summary>
        [Key]
        public int Id { get; set; }

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
