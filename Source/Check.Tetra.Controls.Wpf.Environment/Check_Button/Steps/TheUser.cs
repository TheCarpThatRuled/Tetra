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
         => AtomicArrangeAct
           .Create($"{nameof(The_user)}.{nameof(clicks_the_button)}{(numberOfClicks != 1 ? $": {numberOfClicks} times" : string.Empty)}",
                   environment => environment
                                 .Button
                                 .Click(numberOfClicks)
                                 .Next());

      /* ------------------------------------------------------------ */
   }
}