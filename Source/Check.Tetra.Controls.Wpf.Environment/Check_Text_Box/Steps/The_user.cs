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
         => A_text_box
           .receives_text<Actions, Asserts>(text,
                                            nameof(The_user),
                                            "the_text_box",
                                            actions => actions.TextBox);

      /* ------------------------------------------------------------ */
   }
}