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
         => AtomicAssert
           .Create($"{nameof(The_text_box)}.{nameof(Matches)}: {expected.BriefCharacterisation()}",
                   environment => environment
                                 .TextBox
                                 .Matches(expected));

      /* ------------------------------------------------------------ */
   }
}