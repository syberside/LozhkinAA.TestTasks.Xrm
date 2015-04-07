using System;
using System.Linq;
using System.Reflection;
using LozhkinAA.TestTasks.Xrm.Annotations.Services;
using NUnit.Framework;

namespace LozhkinAA.TestTasks.Xrm.Annotations.UnitTests
{
    [TestFixture]
    public partial class DefaultAnnotationInfoProviderTests
    {
        [Test]
        public void BuildFor_OnNotNullAssembly_FillsAssemblyInfo()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var info = DefaultAnnotationInfoProvider.ExtractFrom(assembly);
            Assert.NotNull(info);
            var annotations = info.AssemblyAnnotation.Annotations.ToArray();
            Assert.AreEqual(assembly, info.AssemblyAnnotation.ReflectedItem);
            Assert.AreEqual(1, annotations.Length);
            Assert.AreEqual("assembly annotation", annotations.First().Id);
            Assert.AreEqual("comment", annotations.First().Comment);
        }

        [Test]
        public void BuildFor_OnNotNullAssembly_FillsTypeInfo()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var info = DefaultAnnotationInfoProvider.ExtractFrom(assembly);
            Assert.NotNull(info);
            var typeInfo = info.TypeAnnotations.FirstOrDefault(a => a.ReflectedItem == typeof (ClassWithAnnotation));
            Assert.NotNull(typeInfo);
            var annotations = typeInfo.Annotations.ToArray();
            Assert.AreEqual("annotation1", annotations.First().Id);
            Assert.AreEqual("comment1", annotations.First().Comment);
        }

        [Test]
        public void BuildFor_OnNotNullAssembly_ProcessInternalClasses()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var info = DefaultAnnotationInfoProvider.ExtractFrom(assembly);
            Assert.NotNull(info);
            var typeInfo =
                info.TypeAnnotations.FirstOrDefault(a => a.ReflectedItem == typeof (InternalClassWithAnnotation));
            Assert.NotNull(typeInfo);
        }

        [Test]
        public void BuildFor_OnNotNullAssembly_ProcessNestedPrivateClasses()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var info = DefaultAnnotationInfoProvider.ExtractFrom(assembly);
            Assert.NotNull(info);
            var typeInfo = info.TypeAnnotations.FirstOrDefault(a => a.ReflectedItem == typeof (NestedPrivateChild));
            Assert.NotNull(typeInfo);
        }

        [Test]
        public void BuildFor_OnNotNullAssembly_ProcessNestedPublicClasses()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var info = DefaultAnnotationInfoProvider.ExtractFrom(assembly);
            Assert.NotNull(info);
            var typeInfo = info.TypeAnnotations.FirstOrDefault(a => a.ReflectedItem == typeof (NestedPublicChild));
            Assert.NotNull(typeInfo);
        }

        [Test]
        public void BuildFor_OnNotNullAssembly_ProcessPublicClasses()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var info = DefaultAnnotationInfoProvider.ExtractFrom(assembly);
            Assert.NotNull(info);
            var typeInfo = info.TypeAnnotations.FirstOrDefault(a => a.ReflectedItem == typeof (ClassWithAnnotation));
            Assert.NotNull(typeInfo);
        }

        [Test]
        public void BuildFor_OnNullAssembly_Throws()
        {
            Assert.Catch<ArgumentNullException>(() => DefaultAnnotationInfoProvider.ExtractFrom((Assembly) null));
        }
    }
}