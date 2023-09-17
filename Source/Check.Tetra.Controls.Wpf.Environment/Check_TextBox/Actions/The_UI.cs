using Tetra.Testing;

namespace Check.Check_TextBox;

// ReSharper disable once InconsistentNaming
public static class The_UI
{
   /* ------------------------------------------------------------ */
   // Given Functions
   /* ------------------------------------------------------------ */

   public static AAA_test.IArrange<TheTextBoxHasNotBeenCreated.Arranges> Has_not_created_the_text_box()
      => AAA_test
        .AtomicArrange<TheTextBoxHasNotBeenCreated.Arranges>
        .Create($"{nameof(The_UI)}.{nameof(Has_not_created_the_text_box)}",
                TheTextBoxHasNotBeenCreated.Arranges.Create);

   /* ------------------------------------------------------------ */

   public static AAA_test.IArrange<TheTextBoxHasBeenCreated.Arranges> Has_created_the_text_box(The_UI_creates_a_text_box args)
      => Has_not_created_the_text_box()
        .And(Creates_the_text_box(args))
        .Recharacterise($"{nameof(The_UI)}.{nameof(Has_created_the_text_box)}: {args.BriefCharacterisation()}");

   /* ------------------------------------------------------------ */
   // ArrangeAct Functions
   /* ------------------------------------------------------------ */

   public static AAA_test.IArrangeAct<TheTextBoxHasNotBeenCreated.Arranges, TheTextBoxHasBeenCreated.Arranges, TheTextBoxHasBeenCreated.Asserts> Creates_the_text_box(
      The_UI_creates_a_text_box args)
      => AAA_test
        .AtomicArrangeAct<TheTextBoxHasNotBeenCreated.Arranges, TheTextBoxHasBeenCreated.Arranges, TheTextBoxHasBeenCreated.Asserts>
        .Create($"{nameof(The_UI)}.{nameof(Creates_the_text_box)}: {args.BriefCharacterisation()}",
                environment => environment.The_UI_creates_the_text_box(args),
                environment => environment
                              .WHEN()
                              .The_UI_creates_the_text_box(args)
                              .THEN());

   /* ------------------------------------------------------------ */
}