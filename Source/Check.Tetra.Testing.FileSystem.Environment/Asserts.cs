using FsCheck;
using Tetra;
using Tetra.Testing;

namespace Check;

public sealed class Asserts : IPropertyAsserts
{
   /* ------------------------------------------------------------ */
   // Fields
   /* ------------------------------------------------------------ */

   public readonly FileSystemPropertyAsserts<Asserts> FileSystem;

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly object? _returnValue;

   //Mutable
   private Property _property = Properties.True();

   /* ------------------------------------------------------------ */
   // Private Constructor
   /* ------------------------------------------------------------ */

   private Asserts
   (
      FileSystem fileSystem,
      object?    returnValue
   )
   {
      _returnValue = returnValue;

      FileSystem = FileSystemPropertyAsserts<Asserts>.Create(UpdateProperty,
                                                                 "File system",
                                                                 fileSystem,
                                                                 () => this);
   }

   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   internal static Asserts Create
   (
      FileSystem fileSystem,
      object?    returnValue
   )
      => new(fileSystem,
             returnValue);

   /* ------------------------------------------------------------ */
   // IPropertyAsserts Methods
   /* ------------------------------------------------------------ */

   public Property ToProperty()
      => _property;

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public ObjectAsserts<T, Asserts> Returns<T>()
      => ObjectAsserts<T, Asserts>
        .Create("return value",
                (T)_returnValue!,
                () => this);

   /* ------------------------------------------------------------ */

   public BooleanPropertyAsserts<Asserts> ReturnsABoolean()
      => BooleanPropertyAsserts<Asserts>
        .Create(UpdateProperty,
                "return value",
                _returnValue as bool? ?? throw Failed.Assert("The return value was not a bool"),
                () => this);

   /* ------------------------------------------------------------ */

   public OptionPropertyAsserts<T, Asserts> ReturnsAnOption<T>()
      => OptionPropertyAsserts<T, Asserts>
        .Create(UpdateProperty,
                "return value",
                _returnValue as IOption<T> ?? throw Failed.Assert($"The return value was not an option of {typeof(T).Name}"),
                () => this);

   /* ------------------------------------------------------------ */
   // Private Methods
   /* ------------------------------------------------------------ */

   private void UpdateProperty
   (
      Property next
   )
      => _property = _property.And(next);

   /* ------------------------------------------------------------ */
}