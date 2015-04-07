using System.Collections.Generic;
using System.Reflection;

namespace LozhkinAA.TestTasks.Xrm.Annotations
{
    /// <summary>
    /// Represents method-level annotations
    /// </summary>
    public class MethodAnnotationInfo : AnnotationItemInfo<MethodInfo>
    {
        public MethodAnnotationInfo(MethodInfo reflectedItem, IEnumerable<AnnotationAttribute> annotations)
            : base(reflectedItem, annotations)
        {
        }
    }
}