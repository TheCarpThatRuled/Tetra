using Tetra.Testing;

namespace Check.Check_Label;

using static AAA_test<Actions, Asserts>;

public static partial class Steps
{
   public sealed class TheLabel
   {
      /* ------------------------------------------------------------ */
      // Assert Functions
      /* ------------------------------------------------------------ */

      public IAssert Matches
      (
         Expected_label expected
      )
         => AtomicAssert
           .Create($"{nameof(The_label)}.{nameof(Matches)}: {expected.BriefCharacterisation()}",
                   environment => environment
                                 .Label
                                 .Matches(expected));

      /* ------------------------------------------------------------ */
   }
}