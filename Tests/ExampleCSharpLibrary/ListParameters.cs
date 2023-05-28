namespace ExampleCSharpLibrary
{
    public class ListParameters
    {
        public ListParameters(List<string> param) { }
        public ListParameters(IList<string> param) { }
        public void Method(List<string> param) { }
        public void Method(IList<string> param) { }
        public List<string> ReturnList() { return new(); }
        public IList<string> ReturnIList() { return null; }
    }
}
