namespace ExampleCSharpLibrary
{
    public class OutParams
    {
        public void GetSomething(out int value) { value = 0; }
        public void GetSomething(out string value) { value = ""; }
        
        public bool TryGetSomething(out object value) 
        {
            value = null;

            return false;
        }
    }
}
