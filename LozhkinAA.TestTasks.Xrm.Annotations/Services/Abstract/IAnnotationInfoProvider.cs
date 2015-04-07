namespace LozhkinAA.TestTasks.Xrm.Annotations.Services.Abstract
{
    /// <summary>
    ///     Provides functionality for extracting annotations from assemblies
    /// </summary>
    public interface IAnnotationInfoProvider
    {
        /// <summary>
        ///     Extracts annotations from assembly specified by <paramref name="assemblyFullPath" />
        /// </summary>
        /// <param name="assemblyFullPath">Full path to assembly</param>
        /// <returns>Extracted annotations</returns>
        AnnotationInfo ExtractFrom(string assemblyFullPath);
    }
}