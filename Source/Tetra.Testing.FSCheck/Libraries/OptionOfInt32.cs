using System.Diagnostics;
using FsCheck;

namespace Tetra.Testing;

public static partial class Libraries
{
   /* ------------------------------------------------------------ */

   // ReSharper disable once ClassNeverInstantiated.Local
   // ReSharper disable once InconsistentNaming
   public sealed class OptionOfInt32
   {
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public static Arbitrary<Option<int>> Type()
         => Generators
           .Option(Generators.Int32())
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */

   // ReSharper disable once ClassNeverInstantiated.Local
   // ReSharper disable once InconsistentNaming
   public sealed class SomeOptionOfInt32
   {
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public static Arbitrary<Option<int>> Type()
         => Generators
           .SomeOption(Generators.Int32())
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */

   // ReSharper disable once ClassNeverInstantiated.Local
   // ReSharper disable once InconsistentNaming
   public sealed class TransitiveOptionOfInt32
   {
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public static Arbitrary<(Option<int>,Option<int>,Option<int>)> Type()
         => Generators
           .TwoUniqueOptions(Generators.Int32())
           .Apply(Gen.Elements<Func<(Option<int> a, Option<int> b), (Option<int>, Option<int>, Option<int>)>>
                  (
                     //If a == b && b == c
                     tuple=> (tuple.a, tuple.a, tuple.a),
                     //If a == b && b != c
                     tuple => (tuple.a, tuple.a, tuple.b),
                     //If a != b && b == c
                     tuple => (tuple.a, tuple.b, tuple.b)
                     //If a != b && b != c then the the equality of a to c cannot be predicted via the transitive property
                  ))
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */
}