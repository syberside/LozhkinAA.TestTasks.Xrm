using System;

namespace LozhkinAA.TestTasks.Xrm.Annotations
{
    /// <summary>
    ///     Use this attribute to mark assembly or class as changed.
    ///     Items marked with this attribute are used by Attributes Analyzer.
    ///     After annotations are stored by Analyzer they can be safely removed.
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Method, Inherited = false, AllowMultiple = true)]
    public sealed class AnnotationAttribute : Attribute
    {
        /// <summary>
        /// </summary>
        /// <param name="id">
        ///     Unique identifier of change.
        ///     Tip: you can use VS Tools->Create GUID Util to generate unique string identifier.
        /// </param>
        /// <param name="comment">Comment for change</param>
        public AnnotationAttribute(string id, string comment)
        {
            if (string.IsNullOrEmpty(comment))
            {
                throw new ArgumentNullException("comment");
            }
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException("id");
            }
            Comment = comment;
            Id = id;
        }

        public string Id { get; private set; }
        public string Comment { get; private set; }
    }
}