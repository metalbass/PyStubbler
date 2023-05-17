namespace ExampleCSharpLibrary
{
    public class RefParams
    {
        public void GetSomething(ref int value) { }
        public void GetSomething(ref string value) { }

        public bool TryGetSomething(ref object value)
        {
            value = null;

            return false;
        }
    }
}
