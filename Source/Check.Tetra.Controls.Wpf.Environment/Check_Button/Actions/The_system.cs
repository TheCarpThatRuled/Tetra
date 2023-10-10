using Tetra;
using Tetra.Testing;

namespace Check.Check_Button;

// ReSharper disable once InconsistentNaming
public static class The_system
{
   /* ------------------------------------------------------------ */
   // ArrangeAct Functions
   /* ------------------------------------------------------------ */

   public static AAA_test.IArrangeAct<TheButtonHasBeenCreated.Arranges, TheButtonHasBeenCreated.Arranges, TheButtonHasBeenCreated.Asserts> Updates_IsEnabled
   (
      bool enabled
   )
      => AAA_test.AtomicArrangeAct<TheButtonHasBeenCreated.Arranges, TheButtonHasBeenCreated.Arranges, TheButtonHasBeenCreated.Asserts>
                 .Create($"{nameof(The_system)}.{nameof(Updates_IsEnabled)}: {enabled}",
                         environment => environment.The_system_updates_IsEnabled(enabled),
                         environment => environment
                                       .WHEN()
                                       .The_system_updates_IsEnabled(enabled)
                                       .THEN());

   /* ------------------------------------------------------------ */

   public static AAA_test.IArrangeAct<TheButtonHasBeenCreated.Arranges, TheButtonHasBeenCreated.Arranges, TheButtonHasBeenCreated.Asserts> Updates_Visibility
   (
      Visibility visibility
   )
      => AAA_test.AtomicArrangeAct<TheButtonHasBeenCreated.Arranges, TheButtonHasBeenCreated.Arranges, TheButtonHasBeenCreated.Asserts>
                 .Create($"{nameof(The_system)}.{nameof(Updates_Visibility)}: {visibility}",
                         environment => environment.The_system_updates_Visibility(visibility),
                         environment => environment
                                       .WHEN()
                                       .The_system_updates_Visibility(visibility)
                                       .THEN());

   /* ------------------------------------------------------------ */
}