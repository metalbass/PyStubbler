namespace ExampleCSharpLibrary
{
    public class StaticMethods
    {
        public static void StaticMethod() { }
        public static void StaticOverloadedMethod() { }
        public static void StaticOverloadedMethod(int param) { }

    }

    public class Properties
    {
        public static int StaticGetProperty { get; }
        public static int StaticGetSetProperty { get; set; }
        public int GetProperty { get; }
        public int GetSetProperty { get; set; }
    }
    
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

    public class ListParameters
    {
        public ListParameters(List<string> param) { }
        public void Method(List<string> param) { }
        public List<string> ReturnList() { return new(); }
    }

    public class DictionaryParameters
    {
        public DictionaryParameters(Dictionary<string, string> param) { }
        public void Method(Dictionary<string, string> param) { }
        public Dictionary<string, string> ReturnDictionary() { return new(); }
    }
    
    public class SingleVsFloatParameters
    {
        public SingleVsFloatParameters(float param) { }
        public void Method(float param) { }
        public float ReturnFloat() { return 0; }
    }    
}
