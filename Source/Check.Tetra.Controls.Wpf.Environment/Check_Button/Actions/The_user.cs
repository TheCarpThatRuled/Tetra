using Tetra.Testing;

namespace Check.Check_Button;

// ReSharper disable once InconsistentNaming
public static class The_user
{
   /* ------------------------------------------------------------ */
   // ArrangeAct Functions
   /* ------------------------------------------------------------ */

   public static IArrangeAct<TheButtonHasBeenCreated.Arranges, TheButtonHasBeenCreated.Arranges, TheButtonHasBeenCreated.Asserts> Clicks_the_button(uint numberOfClicks)
      => AtomicArrangeAct<TheButtonHasBeenCreated.Arranges, TheButtonHasBeenCreated.Arranges, TheButtonHasBeenCreated.Asserts>
        .Create(environment => environment.The_user_clicks_the_button(numberOfClicks),
                environment => environment
                              .WHEN()
                              .The_user_clicks_the_button(numberOfClicks)
                              .THEN(),
                $"{nameof(The_user)}.{nameof(Clicks_the_button)}{(numberOfClicks != 1 ? $": {numberOfClicks} times" : string.Empty)}");

   /* ------------------------------------------------------------ */
}