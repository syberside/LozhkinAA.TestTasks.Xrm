using System;
using System.Linq;
using System.Reflection;
using LozhkinAA.TestTasks.Xrm.Annotations.Services.Abstract;

namespace LozhkinAA.TestTasks.Xrm.Annotations.Services
{
    /// <summary>
    ///     Default annotation provider implementation.
    ///     Implementation is unsafe, because this loads specified assembly into current application domain.
    ///     Production implementation shold use sandbox (load assembly in separate domain with restricted permissions).
    /// </summary>
    public class DefaultAnnotationInfoProvider : IAnnotationInfoProvider
    {
        public virtual AnnotationInfo ExtractFrom(string assemblyFullPath)
        {
            if (string.IsNullOrEmpty(assemblyFullPath))
            {
                throw new ArgumentNullException("assemblyFullPath");
            }
            var assembly = Assembly.LoadFile(assemblyFullPath);
            var info = ExtractFrom(assembly);
            return info;
        }

        /// <summary>
        ///     Load annotations from <paramref name="assembly" />
        /// </summary>
        /// <param name="assembly">Assembly for processing</param>
        /// <returns>Annotations founded in assembly</returns>
        public static AnnotationInfo ExtractFrom(Assembly assembly)
        {
            if (assembly == null)
            {
                throw new ArgumentNullException("assembly");
            }
            //load assembly-level annotations
            var assemblyAnnotations = assembly.GetCustomAttributes<AnnotationAttribute>();
            var assemblyInfo = new AssemblyAnnotationInfo(assembly, assemblyAnnotations);
            //load type-level annotations
            var typeInfos = from type in assembly.GetTypes()
                let attrs = type.GetCustomAttributes<AnnotationAttribute>()
                where attrs.Any()
                select new TypeAnnotationInfo(type, attrs);
            return new AnnotationInfo(assemblyInfo, typeInfos);
        }
    }
}