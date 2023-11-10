using Tetra.Testing;
// ReSharper disable InconsistentNaming

namespace Check.Check_Button;

using static AAA_test<Actions, Asserts>;

partial class Steps
{
   public sealed class TheClickCallback
   {
      /* ------------------------------------------------------------ */
      // Assert Functions
      /* ------------------------------------------------------------ */

      public IAssert was_invoked
      (
         uint numberOfClicks
      )
         => AtomicAssert
           .Create($"{nameof(The_Click_callback)}.{nameof(was_invoked)}{(numberOfClicks != 1 ? $": {numberOfClicks} times" : string.Empty)}",
                   asserts => asserts
                             .OnClick
                             .WasInvoked(numberOfClicks));

      /* ------------------------------------------------------------ */
   }
}