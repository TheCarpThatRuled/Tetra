﻿using Tetra;
using Tetra.Testing;

namespace Check.Check_TextBox;

// ReSharper disable once InconsistentNaming
public static class The_system
{
   /* ------------------------------------------------------------ */
   // ArrangeAct Functions
   /* ------------------------------------------------------------ */

   public static IArrangeAct<TheTextBoxHasBeenCreated.Arranges, TheTextBoxHasBeenCreated.Arranges, TheTextBoxHasBeenCreated.Asserts> Updates_IsEnabled(bool enabled)
      => AtomicArrangeAct<TheTextBoxHasBeenCreated.Arranges, TheTextBoxHasBeenCreated.Arranges, TheTextBoxHasBeenCreated.Asserts>
        .Create(environment => environment.The_system_updates_IsEnabled(enabled),
                environment => environment
                              .WHEN()
                              .The_system_updates_IsEnabled(enabled)
                              .THEN(),
                $"{nameof(The_system)}.{nameof(Updates_IsEnabled)}: {enabled}");

   /* ------------------------------------------------------------ */

   public static IArrangeAct<TheTextBoxHasBeenCreated.Arranges, TheTextBoxHasBeenCreated.Arranges, TheTextBoxHasBeenCreated.Asserts> Updates_Text(string text)
      => AtomicArrangeAct<TheTextBoxHasBeenCreated.Arranges, TheTextBoxHasBeenCreated.Arranges, TheTextBoxHasBeenCreated.Asserts>
        .Create(environment => environment.The_system_updates_Text(text),
                environment => environment
                              .WHEN()
                              .The_system_updates_Text(text)
                              .THEN(),
                $@"{nameof(The_system)}.{nameof(Updates_Text)}: ""{text}""");

   /* ------------------------------------------------------------ */

   public static IArrangeAct<TheTextBoxHasBeenCreated.Arranges, TheTextBoxHasBeenCreated.Arranges, TheTextBoxHasBeenCreated.Asserts> Updates_Visibility(Visibility visibility)
      => AtomicArrangeAct<TheTextBoxHasBeenCreated.Arranges, TheTextBoxHasBeenCreated.Arranges, TheTextBoxHasBeenCreated.Asserts>
        .Create(environment => environment.The_system_updates_Visibility(visibility),
                environment => environment
                              .WHEN()
                              .The_system_updates_Visibility(visibility)
                              .THEN(),
                $"{nameof(The_system)}.{nameof(Updates_Visibility)}: {visibility}");

   /* ------------------------------------------------------------ */
   // Assert Functions
   /* ------------------------------------------------------------ */

   public static IAssert<TheTextBoxHasBeenCreated.Asserts, TheTextBoxHasBeenCreated.Asserts> Text_is(string expected)
      => AtomicAssert<TheTextBoxHasBeenCreated.Asserts, TheTextBoxHasBeenCreated.Asserts>
        .Create(environment => environment.The_system_Text_is(expected),
                $@"{nameof(The_system)}.{nameof(Updates_Visibility)}: ""{expected}""");

   /* ------------------------------------------------------------ */
}