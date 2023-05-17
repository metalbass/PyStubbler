using System.Collections;

namespace ExampleCSharpLibrary
{
    public class Enumerables
    {
        public void Enumerable(IEnumerable enumerable) { }
        public void EnumerableString(IEnumerable<string> stringEnumerable) { }
        public void EnumerableGeneric<T>(IEnumerable<T> genericEnumerable) { }
        
        public IEnumerable ReturnEnumerable() { return null; }
        public IEnumerable<string> ReturnEnumerableString() { return null; }
        public IEnumerable<T> ReturnEnumerableGeneric<T>() { return null; }

    }
}
