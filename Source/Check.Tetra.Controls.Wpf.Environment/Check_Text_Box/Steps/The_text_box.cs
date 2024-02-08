using Tetra.Testing;

namespace Check.Check_Text_Box;

using static AAA_test<Actions, Asserts>;

public static partial class Steps
{
   public sealed class TheTextBox
   {
      /* ------------------------------------------------------------ */
      // Asserts
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