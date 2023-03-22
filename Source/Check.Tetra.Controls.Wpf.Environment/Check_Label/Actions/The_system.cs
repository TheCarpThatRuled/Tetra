using Tetra;
using Tetra.Testing;

namespace Check.Check_Label;

// ReSharper disable once InconsistentNaming
public static class The_system
{
   /* ------------------------------------------------------------ */
   // ArrangeAct Functions
   /* ------------------------------------------------------------ */

   public static IArrangeAct<TheLabelHasBeenCreated.Arranges, TheLabelHasBeenCreated.Arranges, TheLabelHasBeenCreated.Asserts> Updates_Content(object content)
      => AtomicArrangeAct<TheLabelHasBeenCreated.Arranges, TheLabelHasBeenCreated.Arranges, TheLabelHasBeenCreated.Asserts>
        .Create(environment => environment.The_system_updates_Content(content),
                environment => environment
                              .WHEN()
                              .The_system_updates_Content(content)
                              .THEN(),
                $"{nameof(The_system)}.{nameof(Updates_Content)}: {content}");

   /* ------------------------------------------------------------ */

   public static IArrangeAct<TheLabelHasBeenCreated.Arranges, TheLabelHasBeenCreated.Arranges, TheLabelHasBeenCreated.Asserts> Updates_Visibility(Visibility visibility)
      => AtomicArrangeAct<TheLabelHasBeenCreated.Arranges, TheLabelHasBeenCreated.Arranges, TheLabelHasBeenCreated.Asserts>
        .Create(environment => environment.The_system_updates_Visibility(visibility),
                environment => environment
                              .WHEN()
                              .The_system_updates_Visibility(visibility)
                              .THEN(),
                $"{nameof(The_system)}.{nameof(Updates_Visibility)}: {visibility}");

   /* ------------------------------------------------------------ */
}