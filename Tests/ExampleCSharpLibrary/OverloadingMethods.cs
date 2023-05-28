namespace ExampleCSharpLibrary
{
    public class OverloadingMethods
    {
        public OverloadingMethods() { }
        public OverloadingMethods(int param) { }
        public OverloadingMethods(float param) { }

        public void OverloadedMethod() { }
        public void OverloadedMethod(int param) { }
        public void OverloadedMethod(float param) { }

        public static void StaticOverloadedMethod() { }
        public static void StaticOverloadedMethod(int param) { }
        public static void StaticOverloadedMethod(float param) { }
    }
}
