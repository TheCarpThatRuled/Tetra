using Tetra.Testing;

namespace Check.Check_TextBox;

// ReSharper disable once InconsistentNaming
public static class The_text_box
{
   /* ------------------------------------------------------------ */
   // Assert Functions
   /* ------------------------------------------------------------ */

   public static AAA_test.IAssert<TheTextBoxHasBeenCreated.Asserts, TheTextBoxHasBeenCreated.Asserts> Matches
   (
      Expected_text_box expected
   )
      => A_text_box
        .Matches<TheTextBoxHasBeenCreated.Asserts>(expected,
                                                   $"{nameof(The_text_box)}")
        .Route(environment => environment.The_text_box)
        .Recharacterise($"{nameof(The_text_box)}.{nameof(Matches)}: {expected.BriefCharacterisation()}");

   /* ------------------------------------------------------------ */
}