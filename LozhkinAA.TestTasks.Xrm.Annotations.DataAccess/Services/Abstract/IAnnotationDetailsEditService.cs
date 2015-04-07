using LozhkinAA.TestTasks.Xrm.Annotations.DataAccess.Models;

namespace LozhkinAA.TestTasks.Xrm.Annotations.DataAccess.Services.Abstract
{
    /// <summary>
    ///     Provides functionality for annotations editing
    /// </summary>
    public interface IAnnotationDetailsEditService
    {
        /// <summary>
        ///     Tryes save <paramref name="description" />.
        /// </summary>
        /// <param name="description"></param>
        /// <returns>true if annotation was saved and false if annotation with same id already exists</returns>
        bool TryAdd(AnnotationDescription description);
    }
}