namespace ExampleCSharpLibrary
{
    public class NonObsoleteClass
    {
        public string NonObsoleteProperty => "";
        public void NonObsoleteMethod() { }
        public static void NonObsoleteStaticMethod() { }
        
        [Obsolete]
        public string ObsoleteProperty => "";
        [Obsolete]
        public void ObsoleteMethod() { }
        [Obsolete]
        public static void ObsoleteStaticMethod() { }
    }

    [Obsolete]
    public class ObsoleteClass { }
}
