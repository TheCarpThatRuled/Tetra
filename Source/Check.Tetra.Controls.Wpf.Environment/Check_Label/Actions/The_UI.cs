﻿using Tetra.Testing;

namespace Check.Check_Label;

// ReSharper disable once InconsistentNaming
public static class The_UI
{
   /* ------------------------------------------------------------ */
   // Given Functions
   /* ------------------------------------------------------------ */

   public static IArrange<TheLabelHasNotBeenCreated.Arranges> Has_not_created_the_label()
      => AtomicArrange<TheLabelHasNotBeenCreated.Arranges>
        .Create(TheLabelHasNotBeenCreated.Arranges.Create,
                $"{nameof(The_UI)}.{nameof(Has_not_created_the_label)}");

   /* ------------------------------------------------------------ */

   public static IArrange<TheLabelHasBeenCreated.Arranges> Has_created_the_label(The_UI_creates_a_label args)
      => Has_not_created_the_label()
        .And(Creates_the_label(args))
        .Recharacterise($"{nameof(The_UI)}.{nameof(Has_created_the_label)}: {args.BriefCharacterisation()}");

   /* ------------------------------------------------------------ */
   // ArrangeAct Functions
   /* ------------------------------------------------------------ */

   public static IArrangeAct<TheLabelHasNotBeenCreated.Arranges, TheLabelHasBeenCreated.Arranges, TheLabelHasBeenCreated.Asserts> Creates_the_label(
      The_UI_creates_a_label args)
      => AtomicArrangeAct<TheLabelHasNotBeenCreated.Arranges, TheLabelHasBeenCreated.Arranges, TheLabelHasBeenCreated.Asserts>
        .Create(environment => environment.The_UI_creates_the_label(args),
                environment => environment
                              .WHEN()
                              .The_UI_creates_the_label(args)
                              .THEN(),
                $"{nameof(The_UI)}.{nameof(Creates_the_label)}: {args.BriefCharacterisation()}");

   /* ------------------------------------------------------------ */
}