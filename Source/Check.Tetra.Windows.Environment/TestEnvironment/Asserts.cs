using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;

namespace Check;

public sealed class Asserts
{
   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly object? _returnValue;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private Asserts
   (
      object? returnValue
   )
      => _returnValue = returnValue;

   /* ------------------------------------------------------------ */
   // Internal Factory Functions
   /* ------------------------------------------------------------ */

   internal static Asserts Create
   (
      object? returnValue
   )
      => new(returnValue);

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public Asserts ADirectoryDoesNotExist
   (
      string expected
   )
   {
      Assert.That
            .IsFalse($"The file system should not contain <{expected}>",
                     Directory.Exists(expected));

      return this;
   }

   /* ------------------------------------------------------------ */

   public Asserts ADirectoryExists
   (
      string expected
   )
   {
      Assert.That
            .IsTrue($"The file system should contain <{expected}>",
                    Directory.Exists(expected));

      return this;
   }

   /* ------------------------------------------------------------ */

   public Asserts AFileDoesNotExist
   (
      string expected
   )
   {
      Assert.That
            .IsFalse($"The file system should not contain <{expected}>",
                     File.Exists(expected));

      return this;
   }

   /* ------------------------------------------------------------ */

   public Asserts AFileExists
   (
      string expected
   )
   {
      Assert.That
            .IsTrue($"The file system should contain <{expected}>",
                    File.Exists(expected));

      return this;
   }

   /* ------------------------------------------------------------ */

   public Asserts TheCurrentDirectoryIs
   (
      string expected
   )
   {
      Assert.That
            .AreEqualOrdinalIgnoreCase($"The file system should have a current directory of <{expected}>",
                                       expected,
                                       Directory.GetCurrentDirectory());

      return this;
   }

   /* ------------------------------------------------------------ */

   public ObjectAsserts<T, Asserts> Returns<T>()
      => ObjectAsserts<T, Asserts>
        .Create("return value",
                (T) _returnValue!,
                () => this);

   /* ------------------------------------------------------------ */

   public BooleanAsserts<Asserts> ReturnsABoolean()
      => BooleanAsserts<Asserts>
        .Create("return value",
                _returnValue as bool? ?? throw Failed.Assert("The return value was not a bool"),
                () => this);

   /* ------------------------------------------------------------ */

   public EitherAsserts<TLeft, TRight, Asserts> ReturnsAnEither<TLeft, TRight>()
      => EitherAsserts<TLeft, TRight, Asserts>
        .Create("return value",
                _returnValue as IEither<TLeft, TRight> ?? throw Failed.Assert($"The return value was not an either of {typeof(TLeft).Name}, {typeof(TRight).Name}"),
                () => this);

   /* ------------------------------------------------------------ */

   public OptionAsserts<T, Asserts> ReturnsAnOption<T>()
      => OptionAsserts<T, Asserts>
        .Create("return value",
                _returnValue as IOption<T> ?? throw Failed.Assert($"The return value was not an option of {typeof(T).Name}"),
                () => this);

   /* ------------------------------------------------------------ */
}