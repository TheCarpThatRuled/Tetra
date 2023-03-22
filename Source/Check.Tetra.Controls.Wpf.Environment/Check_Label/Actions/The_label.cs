using Tetra.Testing;

namespace Check.Check_Label;

// ReSharper disable once InconsistentNaming
public static class The_label
{
   /* ------------------------------------------------------------ */
   // Assert Functions
   /* ------------------------------------------------------------ */

   public static IAssert<TheLabelHasBeenCreated.Asserts, TheLabelHasBeenCreated.Asserts> Matches(Expected_label expected)
      => ALabel
        .Matches<TheLabelHasBeenCreated.Asserts>(expected,
                                                  $"{nameof(The_label)}.")
        .Route(environment => environment.The_label)
        .Recharacterise($"{nameof(The_label)}.{nameof(Matches)}: {expected.BriefCharacterisation()}");

   /* ------------------------------------------------------------ */
}