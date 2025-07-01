using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using Windows.Foundation.Metadata;

namespace LLMMarshellingTest
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    [WebHostHidden]
    public sealed class MyType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Default constructor required for WinRT components
        public MyType() { }

        public MyType(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public override string ToString() => $"MyType(Id={Id}, Name={Name})";
    }

    // Keep marshaller as a non-WinRT class (internal/private)
    internal static unsafe class MyTypeMarshaller
    {
        // Convert from unmanaged (IntPtr) to managed (MyType)
        public static MyType ConvertToManaged(IntPtr pointer)
        {
            if (pointer == IntPtr.Zero)
                return null;

            // Cast the pointer to our expected unmanaged structure
            var unmanagedPtr = (UnmanagedMyType*)pointer;

            // Create a new managed instance
            var result = new MyType
            {
                Id = unmanagedPtr->Id
            };

            // Handle the string conversion
            if (unmanagedPtr->NamePointer != IntPtr.Zero)
            {
                result.Name = Marshal.PtrToStringUTF8(unmanagedPtr->NamePointer);
            }

            return result;
        }

        // Convert from managed (MyType) to unmanaged (IntPtr)
        public static IntPtr ConvertToNativePointer(MyType instance)
        {
            if (instance == null)
                return IntPtr.Zero;

            // Allocate unmanaged memory for the structure
            var size = Marshal.SizeOf<UnmanagedMyType>();
            var ptr = Marshal.AllocHGlobal(size);

            // Create the unmanaged structure
            var unmanagedStruct = new UnmanagedMyType
            {
                Id = instance.Id,
                NamePointer = instance.Name != null ? Marshal.StringToHGlobalAnsi(instance.Name) : IntPtr.Zero
            };

            // Copy the struct to the allocated memory
            Marshal.StructureToPtr(unmanagedStruct, ptr, false);

            return ptr;
        }

        // Helper method for the void* version 
        public static unsafe MyType ConvertToManaged(void* pointer)
        {
            return ConvertToManaged((IntPtr)pointer);
        }

        // Helper method for the void* version with unique name
        public static unsafe void* ConvertToUnmanagedPtr(MyType instance)
        {
            return (void*)ConvertToNativePointer(instance);
        }

        // Define the corresponding unmanaged structure - NOT exposed to WinRT
        [StructLayout(LayoutKind.Sequential)]
        internal struct UnmanagedMyType
        {
            public int Id;
            public IntPtr NamePointer; // Pointer to UTF-8 string
        }
    }

    // This is the WinRT-compatible structure that can be exposed
    [StructLayout(LayoutKind.Sequential)]
    public struct MyTypeData
    {
        public int Id;
        public string Name;
    }
}