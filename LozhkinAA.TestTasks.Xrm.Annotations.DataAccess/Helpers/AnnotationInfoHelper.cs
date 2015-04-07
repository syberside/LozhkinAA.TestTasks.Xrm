using System;
using System.Collections.Generic;
using LozhkinAA.TestTasks.Xrm.Annotations.DataAccess.Models;

namespace LozhkinAA.TestTasks.Xrm.Annotations.DataAccess.Helpers
{
    /// <summary>
    ///     Helper class for AnnotationInfo
    /// </summary>
    public static class AnnotationInfoHelper
    {
        /// <summary>
        ///     Converts provided <paramref name="info" /> into set of Annotation Descriptions
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public static IEnumerable<AnnotationDescription> ToDescriptions(this AnnotationInfo info)
        {
            if (info == null)
            {
                throw new ArgumentNullException("info");
            }
            //lazy ArgumenNullException protection
            return EnumerateToDescriptions(info);
        }

        private static IEnumerable<AnnotationDescription> EnumerateToDescriptions(AnnotationInfo info)
        {
            //Assumes that application run's from commit author profile
            var username = Environment.UserName;
            //convert assembly-level annotations
            var assemblyInfo = info.AssemblyAnnotation;
            var assemblyFullName = assemblyInfo.ReflectedItem.FullName;
            foreach (var annotation in assemblyInfo.Annotations)
            {
                yield return new AnnotationDescription
                {
                    Assembly = assemblyFullName,
                    Author = username,
                    Comment = annotation.Comment,
                    Id = annotation.Id,
                    MemberName = "assembly",
                    //Assumes that "commit time" is same as "code change time"
                    Time = DateTime.Now
                };
            }
            //convert type-level annotations
            foreach (var typeAnnotation in info.TypeAnnotations)
            {
                var typeFullName = typeAnnotation.ReflectedItem.FullName;
                foreach (var annotation in typeAnnotation.Annotations)
                {
                    yield return new AnnotationDescription()
                    {
                        Assembly = assemblyFullName,
                        Author = username,
                        Comment = annotation.Comment,
                        Id = annotation.Id,
                        MemberName = typeFullName,
                        //Assumes that "commit time" is same as "code change time"
                        Time = DateTime.Now
                    };
                }
            }
            //convert method-level annotations
            foreach (var methodAnnotation in info.MethodAnnotations)
            {
                var methodName = methodAnnotation.ReflectedItem.DeclaringType.FullName+" -> "+methodAnnotation.ReflectedItem.ToString();
                foreach( var annotation in methodAnnotation.Annotations )
                {
                    yield return new AnnotationDescription()
                    {
                        Assembly = assemblyFullName,
                        Author = username,
                        Comment = annotation.Comment,
                        Id = annotation.Id,
                        MemberName = methodName,
                        //Assumes that "commit time" is same as "code change time"
                        Time = DateTime.Now
                    };
                }
            }
        }
    }
}