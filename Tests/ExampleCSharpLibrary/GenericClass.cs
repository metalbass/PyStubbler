namespace ExampleCSharpLibrary
{
    public class GenericClass<T>
    {
        public T Property { get; set; }
        public void Method(T something) { }
        public T ReturnGeneric() { return default; }
    }
}
