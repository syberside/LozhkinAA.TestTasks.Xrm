using System.Collections.Generic;
using System.Reflection;

namespace LozhkinAA.TestTasks.Xrm.Annotations
{
    /// <summary>
    ///     Represents assembly-level annotations.
    /// </summary>
    public class AssemblyAnnotationInfo : AnnotationItemInfo<Assembly>
    {
        public AssemblyAnnotationInfo(Assembly reflectedItem, IEnumerable<AnnotationAttribute> annotations)
            : base(reflectedItem, annotations)
        {
        }
    }
}