using Tetra.Testing;

namespace Check.Check_Button;

// ReSharper disable once InconsistentNaming
public static class The_UI
{
   /* ------------------------------------------------------------ */
   // Given Functions
   /* ------------------------------------------------------------ */

   public static IArrange<TheButtonHasNotBeenCreated.Arranges> Has_not_created_the_button()
      => AtomicArrange<TheButtonHasNotBeenCreated.Arranges>
        .Create(TheButtonHasNotBeenCreated.Arranges.Create,
                $"{nameof(The_UI)}.{nameof(Has_not_created_the_button)}");

   /* ------------------------------------------------------------ */

   public static IArrange<TheButtonHasBeenCreated.Arranges> Has_created_the_button(The_UI_creates_a_button args)
      => Has_not_created_the_button()
        .And(Creates_the_button(args))
        .Recharacterise($"{nameof(The_UI)}.{nameof(Has_created_the_button)}: {args.BriefCharacterisation()}");

   /* ------------------------------------------------------------ */
   // ArrangeAct Functions
   /* ------------------------------------------------------------ */

   public static IArrangeAct<TheButtonHasNotBeenCreated.Arranges, TheButtonHasBeenCreated.Arranges, TheButtonHasBeenCreated.Asserts> Creates_the_button(
      The_UI_creates_a_button args)
      => AtomicArrangeAct<TheButtonHasNotBeenCreated.Arranges, TheButtonHasBeenCreated.Arranges, TheButtonHasBeenCreated.Asserts>
        .Create(environment => environment.The_UI_creates_the_button(args),
                environment => environment
                              .WHEN()
                              .The_UI_creates_the_button(args)
                              .THEN(),
                $"{nameof(The_UI)}.{nameof(Creates_the_button)}: {args.BriefCharacterisation()}");

   /* ------------------------------------------------------------ */
}