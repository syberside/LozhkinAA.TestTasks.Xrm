using System;
using NUnit.Framework;

namespace LozhkinAA.TestTasks.Xrm.Annotations.UnitTests
{
    [TestFixture]
    public class AnnotationAttributeTests
    {
        [TestCase(null, "some comment", ExpectedException = typeof (ArgumentNullException))]
        [TestCase("", "some comment", ExpectedException = typeof (ArgumentNullException))]
        [TestCase("some id", "", ExpectedException = typeof (ArgumentNullException))]
        [TestCase("some id", null, ExpectedException = typeof (ArgumentNullException))]
        public void ctor_OnInvalidArguments_Throws(string testId, string testComment)
        {
            new AnnotationAttribute(testId, testComment);
        }
    }
}