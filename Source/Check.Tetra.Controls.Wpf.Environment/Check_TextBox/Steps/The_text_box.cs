using Tetra.Testing;

namespace Check.Check_TextBox;

using static AAA_test<Actions, Asserts>;

public static partial class Steps
{
   public sealed class TheTextBox
   {
      /* ------------------------------------------------------------ */
      // Assert Functions
      /* ------------------------------------------------------------ */

      public IAssert Matches
      (
         Expected_text_box expected
      )
         => A_text_box
           .Matches<Actions, Asserts>(expected,
                                      $"{nameof(The_text_box)}",
                                      asserts => asserts.TextBox)
           .Recharacterise($"{nameof(The_text_box)}.{nameof(Matches)}: {expected.BriefCharacterisation()}");

      /* ------------------------------------------------------------ */
   }
}