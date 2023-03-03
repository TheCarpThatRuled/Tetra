using Tetra.Testing;

// ReSharper disable InconsistentNaming

namespace Check.Check_TextBox;

public static class GIVEN
{
   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public static TheTextBoxHasNotBeenCreated.Arrange The_UI_has_not_created_the_text_box()
      => The_UI_has_not_created_the_text_box(nameof(The_UI_has_not_created_the_text_box));

   /* ------------------------------------------------------------ */

   public static TheTextBoxHasBeenCreated.Arrange The_UI_has_created_the_text_box(The_UI_creates_a_text_box args)
      => The_UI_has_not_created_the_text_box($"{nameof(The_UI_has_created_the_text_box)}: {args.BriefCharacterisation()}")
        .The_UI_creates_the_text_box(args);

   /* ------------------------------------------------------------ */
   // Private Functions
   /* ------------------------------------------------------------ */

   public static TheTextBoxHasNotBeenCreated.Arrange The_UI_has_not_created_the_text_box(string fullCharacterisation)
      => new(AAATest.Factory(),
             characteriser => characteriser
                             .AddClauseToBriefCharacterisation(fullCharacterisation)
                             .AddClauseToFullCharacterisation(nameof(The_UI_has_not_created_the_text_box)),
             _ => new());

   /* ------------------------------------------------------------ */
}