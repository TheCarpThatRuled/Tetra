using Tetra.Testing;

namespace Check.Check_Button;

// ReSharper disable once InconsistentNaming
public static class The_button
{
   /* ------------------------------------------------------------ */
   // Assert Functions
   /* ------------------------------------------------------------ */

   public static IAssert<TheButtonHasBeenCreated.Asserts, TheButtonHasBeenCreated.Asserts> Matches(Expected_button expected)
      => A_button
        .Matches<TheButtonHasBeenCreated.Asserts>(expected,
                                                  $"{nameof(The_button)}.")
        .Route(environment => environment.The_button)
        .Recharacterise($"{nameof(The_button)}.{nameof(Matches)}: {expected.BriefCharacterisation()}");

   /* ------------------------------------------------------------ */
}