using Tetra.Testing;

namespace Check.Check_Button;

// ReSharper disable once InconsistentNaming
public static class The_Click_callback
{
   /* ------------------------------------------------------------ */
   // Assert Functions
   /* ------------------------------------------------------------ */

   public static AAA_test.IAssert<TheButtonHasBeenCreated.Asserts, TheButtonHasBeenCreated.Asserts> Was_invoked(uint numberOfClicks)
      => AAA_test
        .AtomicAssert<TheButtonHasBeenCreated.Asserts, TheButtonHasBeenCreated.Asserts>
        .Create(environment => environment.The_Click_callback_was_invoked(numberOfClicks),
                $"{nameof(The_Click_callback)}.{nameof(Was_invoked)}{(numberOfClicks != 1 ? $": {numberOfClicks} times" : string.Empty)}");

   /* ------------------------------------------------------------ */
}