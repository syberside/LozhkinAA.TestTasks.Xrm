using System;
using System.Collections.Generic;
using System.Linq;

namespace LozhkinAA.TestTasks.Xrm.Annotations
{
    /// <summary>
    ///     Represents assembly annotations.
    /// </summary>
    public class AnnotationInfo
    {
        private readonly AssemblyAnnotationInfo _assemblyAnnotationInfo;
        private readonly TypeAnnotationInfo[] _typeAnnotationInfos;

        public AnnotationInfo(AssemblyAnnotationInfo assemblyAnnotation, IEnumerable<TypeAnnotationInfo> typeAnnotations)
        {
            if (assemblyAnnotation == null)
            {
                throw new ArgumentNullException("assemblyAnnotation");
            }
            if (typeAnnotations == null)
            {
                throw new ArgumentNullException("typeAnnotations");
            }
            _assemblyAnnotationInfo = assemblyAnnotation;
            _typeAnnotationInfos = typeAnnotations.ToArray();
        }

        /// <summary>
        ///     Assembly-level annotations
        /// </summary>
        public AssemblyAnnotationInfo AssemblyAnnotation
        {
            get { return _assemblyAnnotationInfo; }
        }

        /// <summary>
        ///     Type-level annotations
        /// </summary>
        public IEnumerable<TypeAnnotationInfo> TypeAnnotations
        {
            get { return _typeAnnotationInfos.AsEnumerable(); }
        }
    }
}