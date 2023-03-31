using FsCheck;

namespace Tetra.Testing;

public static partial class Libraries
{
   /* ------------------------------------------------------------ */

   // ReSharper disable once ClassNeverInstantiated.Local
   // ReSharper disable once InconsistentNaming
   public sealed class LeftEitherOfTestClassAndTestClass
   {
      /* ------------------------------------------------------------ */
      // Functions
      /* ------------------------------------------------------------ */

      public static Arbitrary<IEither<Testing.TestClass, Testing.TestClass>> Type()
         => Generators
           .LeftEither<Testing.TestClass, Testing.TestClass>(Generators.TestClass())
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */

   // ReSharper disable once ClassNeverInstantiated.Local
   // ReSharper disable once InconsistentNaming
   public sealed class EitherOfTestClassAndTestClass
   {
      /* ------------------------------------------------------------ */
      // Functions
      /* ------------------------------------------------------------ */

      public static Arbitrary<IEither<Testing.TestClass, Testing.TestClass>> Type()
         => Generators
           .Either(Generators.TestClass(),
                   Generators.TestClass())
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */

   // ReSharper disable once ClassNeverInstantiated.Local
   // ReSharper disable once InconsistentNaming
   public sealed class RightEitherOfTestClassAndTestClass
   {
      /* ------------------------------------------------------------ */
      // Functions
      /* ------------------------------------------------------------ */

      public static Arbitrary<IEither<Testing.TestClass, Testing.TestClass>> Type()
         => Generators
           .RightEither<Testing.TestClass, Testing.TestClass>(Generators.TestClass())
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */

   // ReSharper disable once ClassNeverInstantiated.Local
   // ReSharper disable once InconsistentNaming
   public sealed class TransitiveEithersOfTestClassAndTestClass
   {
      /* ------------------------------------------------------------ */
      // Functions
      /* ------------------------------------------------------------ */

      public static Arbitrary<(IEither<Testing.TestClass, Testing.TestClass>, IEither<Testing.TestClass, Testing.TestClass>, IEither<Testing.TestClass, Testing.TestClass>)> Type()
         => Generators
           .Transitive(Generators.TwoUniqueEithers(Generators.TestClass(),
                                                   Generators.TestClass()))
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */
}