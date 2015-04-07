using System.Collections.Generic;
using LozhkinAA.TestTasks.Xrm.Annotations.DataAccess.Models;

namespace LozhkinAA.TestTasks.Xrm.Annotations.DataAccess.Services.Abstract
{
    /// <summary>
    ///     Provides functionality for annotations viewing
    /// </summary>
    public interface IAnnotationDetailsViewService
    {
        /// <summary>
        ///     Get all annotations details
        /// </summary>
        /// <returns>All anotations details</returns>
        /// TODO: There shold be methods for receiving items with paging support
        IEnumerable<AnnotationDescription> All();
    }
}