For a C# dotnet app using the dotnet 9, write a method that users System.Reflection.MetaData APIs to:
1) Define a static class MyType.  It should have [EditorBrowsable(Never)] on it, and the [WindowsRuntimeClassName(“Foo”)]

2) define a MyTypeMarshaller static class too, with two methods: ConvertToManaged, taking a void* pointer and returning MyType, and a ConvertToUnmanaged that does the opposite

(Correction: Make MyType a non-static class so it can be instantiated)
