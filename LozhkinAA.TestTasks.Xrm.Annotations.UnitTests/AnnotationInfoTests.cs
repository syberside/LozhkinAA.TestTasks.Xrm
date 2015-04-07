using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using LozhkinAA.TestTasks.Xrm.Annotations;
using NUnit.Framework;

namespace LozhkinAA.TestTasks.Xrm.Annotations.UnitTests
{
    [TestFixture]
    public class AnnotationInfoTests
    {
        [Test]
        public void ctor_OnNullAssemblyInfo_Throws()
        {
            Assert.Catch<ArgumentNullException>(
                () =>
                    new AnnotationInfo(null, Enumerable.Empty<TypeAnnotationInfo>(),
                        Enumerable.Empty<MethodAnnotationInfo>()));
        }

        [Test]
        public void ctor_OnNullTypesInfos_Throws()
        {
            Assert.Catch<ArgumentNullException>(
                () =>
                    new AnnotationInfo(
                        new AssemblyAnnotationInfo(Assembly.GetExecutingAssembly(),Enumerable.Empty<AnnotationAttribute>()), 
                        null, Enumerable.Empty<MethodAnnotationInfo>()));
        }

        [Test]
        public void ctor_OnNullMethodsInfos_Throws()
        {
            Assert.Catch<ArgumentNullException>(
                () =>
                    new AnnotationInfo(
                        new AssemblyAnnotationInfo(Assembly.GetExecutingAssembly(),Enumerable.Empty<AnnotationAttribute>()), 
                        Enumerable.Empty<TypeAnnotationInfo>(), null));
        }
    }
}