using System;
using System.Collections.Generic;
using System.Linq;

namespace LozhkinAA.TestTasks.Xrm.Annotations
{
    /// <summary>
    ///     Generic annotation holder.
    /// </summary>
    /// <typeparam name="T">Class of annotated item</typeparam>
    public class AnnotationItemInfo<T> where T : class
    {
        private readonly AnnotationAttribute[] _annotations;

        protected AnnotationItemInfo(T reflectedItem, IEnumerable<AnnotationAttribute> annotations)
        {
            if (reflectedItem == null)
            {
                throw new ArgumentNullException("reflectedItem");
            }
            if (annotations == null)
            {
                throw new ArgumentNullException("annotations");
            }
            _annotations = annotations.ToArray();
            ReflectedItem = reflectedItem;
        }

        /// <summary>
        ///     Annotated item.
        /// </summary>
        public T ReflectedItem { get; private set; }

        /// <summary>
        ///     Annotations of annotated item.
        /// </summary>
        public IEnumerable<AnnotationAttribute> Annotations
        {
            get { return _annotations.AsEnumerable(); }
        }
    }
}