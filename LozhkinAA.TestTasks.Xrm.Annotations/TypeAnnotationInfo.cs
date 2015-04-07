using System;
using System.Collections.Generic;

namespace LozhkinAA.TestTasks.Xrm.Annotations
{
    /// <summary>
    ///     Represents type-level annotations.
    /// </summary>
    public class TypeAnnotationInfo : AnnotationItemInfo<Type>
    {
        public TypeAnnotationInfo(Type reflectedItem, IEnumerable<AnnotationAttribute> annotations)
            : base(reflectedItem, annotations)
        {
        }
    }
}