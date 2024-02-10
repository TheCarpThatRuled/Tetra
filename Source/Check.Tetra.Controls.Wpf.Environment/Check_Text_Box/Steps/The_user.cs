using Tetra.Testing;

namespace Check.Check_Text_Box;

using static AAA_test<Actions, Asserts>;

public static partial class Steps
{
   public sealed class TheUser
   {
      /* ------------------------------------------------------------ */
      // AActions
      /* ------------------------------------------------------------ */

      public IAction Enters_text
      (
         string text
      )
         => AtomicAction
           .Create($@"{nameof(The_user)}_enters_text_in_the_text_box: ""{text}""",
                   environment => environment
                                 .TextBox
                                 .EnterText(text)
                                 .Next());

      /* ------------------------------------------------------------ */
   }
}