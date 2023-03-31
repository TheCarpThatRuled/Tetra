using FsCheck;

namespace Tetra.Testing;

public static partial class Libraries
{
   /* ------------------------------------------------------------ */

   // ReSharper disable once ClassNeverInstantiated.Local
   // ReSharper disable once InconsistentNaming
   public sealed class LeftEitherOfTestStructAndTestClass
   {
      /* ------------------------------------------------------------ */
      // Functions
      /* ------------------------------------------------------------ */

      public static Arbitrary<IEither<Testing.TestStruct, Testing.TestClass>> Type()
         => Generators
           .LeftEither<Testing.TestStruct, Testing.TestClass>(Generators.TestStruct())
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */

   // ReSharper disable once ClassNeverInstantiated.Local
   // ReSharper disable once InconsistentNaming
   public sealed class EitherOfTestStructAndTestClass
   {
      /* ------------------------------------------------------------ */
      // Functions
      /* ------------------------------------------------------------ */

      public static Arbitrary<IEither<Testing.TestStruct, Testing.TestClass>> Type()
         => Generators
           .Either(Generators.TestStruct(),
                   Generators.TestClass())
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */

   // ReSharper disable once ClassNeverInstantiated.Local
   // ReSharper disable once InconsistentNaming
   public sealed class RightEitherOfTestStructAndTestClass
   {
      /* ------------------------------------------------------------ */
      // Functions
      /* ------------------------------------------------------------ */

      public static Arbitrary<IEither<Testing.TestStruct, Testing.TestClass>> Type()
         => Generators
           .RightEither<Testing.TestStruct, Testing.TestClass>(Generators.TestClass())
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */

   // ReSharper disable once ClassNeverInstantiated.Local
   // ReSharper disable once InconsistentNaming
   public sealed class TransitiveEithersOfTestStructAndTestClass
   {
      /* ------------------------------------------------------------ */
      // Functions
      /* ------------------------------------------------------------ */

      public static Arbitrary<(IEither<Testing.TestStruct, Testing.TestClass>, IEither<Testing.TestStruct, Testing.TestClass>, IEither<Testing.TestStruct, Testing.TestClass>)> Type()
         => Generators
           .Transitive(Generators.TwoUniqueEithers(Generators.TestStruct(),
                                                   Generators.TestClass()))
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */
}