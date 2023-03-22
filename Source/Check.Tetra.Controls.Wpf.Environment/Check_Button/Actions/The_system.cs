﻿using Tetra;
using Tetra.Testing;

namespace Check.Check_Button;

// ReSharper disable once InconsistentNaming
public static class The_system
{
   /* ------------------------------------------------------------ */
   // ArrangeAct Functions
   /* ------------------------------------------------------------ */

   public static IArrangeAct<TheButtonHasBeenCreated.Arranges, TheButtonHasBeenCreated.Arranges, TheButtonHasBeenCreated.Asserts> Updates_IsEnabled(bool enabled)
      => AtomicArrangeAct<TheButtonHasBeenCreated.Arranges, TheButtonHasBeenCreated.Arranges, TheButtonHasBeenCreated.Asserts>
        .Create(environment => environment.The_system_updates_IsEnabled(enabled),
                environment => environment
                              .WHEN()
                              .The_system_updates_IsEnabled(enabled)
                              .THEN(),
                $"{nameof(The_system)}.{nameof(Updates_IsEnabled)}: {enabled}");

   /* ------------------------------------------------------------ */

   public static IArrangeAct<TheButtonHasBeenCreated.Arranges, TheButtonHasBeenCreated.Arranges, TheButtonHasBeenCreated.Asserts> Updates_Visibility(Visibility visibility)
      => AtomicArrangeAct<TheButtonHasBeenCreated.Arranges, TheButtonHasBeenCreated.Arranges, TheButtonHasBeenCreated.Asserts>
        .Create(environment => environment.The_system_updates_Visibility(visibility),
                environment => environment
                              .WHEN()
                              .The_system_updates_Visibility(visibility)
                              .THEN(),
                $"{nameof(The_system)}.{nameof(Updates_Visibility)}: {visibility}");

   /* ------------------------------------------------------------ */
}