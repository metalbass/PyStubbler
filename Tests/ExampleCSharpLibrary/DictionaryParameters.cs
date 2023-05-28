namespace ExampleCSharpLibrary
{
    public class DictionaryParameters
    {
        public DictionaryParameters(Dictionary<string, string> param) { }
        public void Method(Dictionary<string, string> param) { }
        public Dictionary<string, string> ReturnDictionary() { return new(); }
    }
}
