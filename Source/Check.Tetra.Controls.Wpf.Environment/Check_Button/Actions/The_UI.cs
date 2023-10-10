using Tetra.Testing;

namespace Check.Check_Button;

// ReSharper disable once InconsistentNaming
public static class The_UI
{
   /* ------------------------------------------------------------ */
   // Given Functions
   /* ------------------------------------------------------------ */

   public static AAA_test.IArrange<TheButtonHasNotBeenCreated.Arranges> Has_not_created_the_button()
      => AAA_test.AtomicArrange<TheButtonHasNotBeenCreated.Arranges>
                 .Create($"{nameof(The_UI)}.{nameof(Has_not_created_the_button)}",
                         TheButtonHasNotBeenCreated.Arranges.Create);

   /* ------------------------------------------------------------ */

   public static AAA_test.IArrange<TheButtonHasBeenCreated.Arranges> Has_created_the_button
   (
      The_UI_creates_a_button args
   )
      => Has_not_created_the_button()
        .And(Creates_the_button(args))
        .Recharacterise($"{nameof(The_UI)}.{nameof(Has_created_the_button)}: {args.BriefCharacterisation()}");

   /* ------------------------------------------------------------ */
   // ArrangeAct Functions
   /* ------------------------------------------------------------ */

   public static AAA_test.IArrangeAct<TheButtonHasNotBeenCreated.Arranges, TheButtonHasBeenCreated.Arranges, TheButtonHasBeenCreated.Asserts> Creates_the_button
   (
      The_UI_creates_a_button args
   )
      => AAA_test.AtomicArrangeAct<TheButtonHasNotBeenCreated.Arranges, TheButtonHasBeenCreated.Arranges, TheButtonHasBeenCreated.Asserts>
                 .Create($"{nameof(The_UI)}.{nameof(Creates_the_button)}: {args.BriefCharacterisation()}",
                         environment => environment.The_UI_creates_the_button(args),
                         environment => environment
                                       .WHEN()
                                       .The_UI_creates_the_button(args)
                                       .THEN());

   /* ------------------------------------------------------------ */
}