using Tetra.Testing;
// ReSharper disable InconsistentNaming

namespace Check.Check_Button;

using static AAA_test<Actions, Asserts>;

partial class Steps
{
   public sealed class TheUser
   {
      /* ------------------------------------------------------------ */
      // ArrangeAct Functions
      /* ------------------------------------------------------------ */

      public IArrangeAct clicks_the_button
      (
         uint numberOfClicks
      )
         => A_button
           .is_Clicked<Actions, Asserts>(numberOfClicks,
                                         nameof(The_user),
                                         "the_button",
                                         actions => actions.Button);

      /* ------------------------------------------------------------ */
   }
}