using Tetra.Testing;

namespace Check.Check_TextBox;

// ReSharper disable once InconsistentNaming
public static class The_UI
{
   /* ------------------------------------------------------------ */
   // Given Functions
   /* ------------------------------------------------------------ */

   public static IArrange<TheTextBoxHasNotBeenCreated.Arranges> Has_not_created_the_text_box()
      => AtomicArrange<TheTextBoxHasNotBeenCreated.Arranges>
        .Create(TheTextBoxHasNotBeenCreated.Arranges.Create,
                $"{nameof(The_UI)}.{nameof(Has_not_created_the_text_box)}");

   /* ------------------------------------------------------------ */

   public static IArrange<TheTextBoxHasBeenCreated.Arranges> Has_created_the_text_box(The_UI_creates_a_text_box args)
      => Has_not_created_the_text_box()
        .And(Creates_the_text_box(args))
        .Recharacterise($"{nameof(The_UI)}.{nameof(Has_created_the_text_box)}: {args.BriefCharacterisation()}");

   /* ------------------------------------------------------------ */
   // ArrangeAct Functions
   /* ------------------------------------------------------------ */

   public static IArrangeAct<TheTextBoxHasNotBeenCreated.Arranges, TheTextBoxHasBeenCreated.Arranges, TheTextBoxHasBeenCreated.Asserts> Creates_the_text_box(
      The_UI_creates_a_text_box args)
      => AtomicArrangeAct<TheTextBoxHasNotBeenCreated.Arranges, TheTextBoxHasBeenCreated.Arranges, TheTextBoxHasBeenCreated.Asserts>
        .Create(environment => environment.The_UI_creates_the_text_box(args),
                environment => environment
                              .WHEN()
                              .The_UI_creates_the_text_box(args)
                              .THEN(),
                $"{nameof(The_UI)}.{nameof(Creates_the_text_box)}: {args.BriefCharacterisation()}");

   /* ------------------------------------------------------------ */
}