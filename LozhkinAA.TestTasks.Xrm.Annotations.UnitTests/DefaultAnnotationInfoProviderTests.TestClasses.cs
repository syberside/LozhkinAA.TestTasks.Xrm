using LozhkinAA.TestTasks.Xrm.Annotations;

//test attribute for assembly
[assembly: Annotation("assembly annotation", "comment")]

namespace LozhkinAA.TestTasks.Xrm.Annotations.UnitTests
{
    #region Test classes
    [Annotation("annotation1", "comment1")]
    public class ClassWithAnnotation
    {

        [Annotation("PublicStaticMethod Annotation", "comment")]
        public static void PublicStaticMethod()
        {

        }

        [Annotation("NonSaticMethod Annotation", "comment")]
        public void NonStaticMethod()
        {
            
        }

        [Annotation("PrivateMethod Annotation", "comment")]
        public void PrivateMethod()
        {

        }
    }

    [Annotation("annotation2", "comment2")]
    [Annotation("annotation3", "comment3")]
    internal class InternalClassWithAnnotation
    {

    }
    #endregion

    public partial class DefaultAnnotationInfoProviderTests
    {
        #region Nested Test classes

        [Annotation("annotation4", "comment4")]
        public class NestedPublicChild
        {

        }

        [Annotation("annotation5", "comment5")]
        private class NestedPrivateChild
        {

        }
        #endregion
    }
}