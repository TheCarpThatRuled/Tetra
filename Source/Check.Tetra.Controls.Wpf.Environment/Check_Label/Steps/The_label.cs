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
         => A_label
           .Matches<Actions, Asserts>(expected,
                                      $"{nameof(The_label)}",
                                      asserts => asserts.Label)
           .Recharacterise($"{nameof(The_label)}.{nameof(Matches)}: {expected.BriefCharacterisation()}");

      /* ------------------------------------------------------------ */
   }
}