using Tetra.Testing;

namespace Check.Check_Button;

// ReSharper disable once InconsistentNaming
public static class The_user
{
   /* ------------------------------------------------------------ */
   // ArrangeAct Functions
   /* ------------------------------------------------------------ */

   public static AAA_test.IArrangeAct<TheButtonHasBeenCreated.Arranges, TheButtonHasBeenCreated.Arranges, TheButtonHasBeenCreated.Asserts> Clicks_the_button(uint numberOfClicks)
      => AAA_test
        .AtomicArrangeAct<TheButtonHasBeenCreated.Arranges, TheButtonHasBeenCreated.Arranges, TheButtonHasBeenCreated.Asserts>
        .Create($"{nameof(The_user)}.{nameof(Clicks_the_button)}{(numberOfClicks != 1 ? $": {numberOfClicks} times" : string.Empty)}",
                environment => environment.The_user_clicks_the_button(numberOfClicks),
                environment => environment
                              .WHEN()
                              .The_user_clicks_the_button(numberOfClicks)
                              .THEN());

   /* ------------------------------------------------------------ */
}