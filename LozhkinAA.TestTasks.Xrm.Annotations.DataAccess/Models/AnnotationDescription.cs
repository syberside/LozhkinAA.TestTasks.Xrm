using System;

namespace LozhkinAA.TestTasks.Xrm.Annotations.DataAccess.Models
{
    /// <summary>
    ///     Represents simple Annotation Description model,
    ///     which is used in both BLL (Buisnes Logic Layer) and DAL (Data Access Layer) realizations
    /// </summary>
    /// TODO: There should be separate models for BLL and DAL
    public class AnnotationDescription
    {
        public string Id { get; set; }
        public string Comment { get; set; }

        public string Author { get; set; }
        public DateTime Time { get; set; }

        /// <summary>
        ///     Annotation source assembly full name
        /// </summary>
        public string Assembly { get; set; }

        /// <summary>
        ///     Name of changed member
        /// </summary>
        public string MemberName { get; set; }
    }
}