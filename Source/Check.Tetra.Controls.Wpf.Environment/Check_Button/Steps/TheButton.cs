using Tetra.Testing;

// ReSharper disable InconsistentNaming

namespace Check.Check_Button;

using static AAA_test<Actions, Asserts>;

partial class Steps
{
   public sealed class TheButton
   {
      /* ------------------------------------------------------------ */
      // Assert Functions
      /* ------------------------------------------------------------ */

      public IAssert matches
      (
         Expected_button expected
      )
         => A_button
           .Matches<Actions, Asserts>(expected,
                                      $"{nameof(The_button)}",
                                      asserts => asserts.Button)
           .Recharacterise($"{nameof(The_button)}.{nameof(matches)}: {expected.BriefCharacterisation()}");

      /* ------------------------------------------------------------ */
   }
}