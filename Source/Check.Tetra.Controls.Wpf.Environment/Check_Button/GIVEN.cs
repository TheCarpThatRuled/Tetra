using Tetra.Testing;

// ReSharper disable InconsistentNaming

namespace Check.Check_Button;

public static class GIVEN
{
   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public static TheButtonHasNotBeenCreated.Arrange The_UI_has_not_created_the_button()
      => The_UI_has_not_created_the_button(nameof(The_UI_has_not_created_the_button));

   /* ------------------------------------------------------------ */

   public static TheButtonHasBeenCreated.Arrange The_UI_has_created_the_button(The_UI_creates_a_button args)
      => The_UI_has_not_created_the_button($"{nameof(The_UI_has_created_the_button)}: {args.BriefCharacterisation()}")
        .The_UI_creates_the_button(args);

   /* ------------------------------------------------------------ */
   // Private Functions
   /* ------------------------------------------------------------ */

   public static TheButtonHasNotBeenCreated.Arrange The_UI_has_not_created_the_button(string fullCharacterisation)
      => new(AAATest.Factory(),
             characteriser => characteriser
                             .AddClauseToBriefCharacterisation(fullCharacterisation)
                             .AddClauseToFullCharacterisation(nameof(The_UI_has_not_created_the_button)),
             _ => new());

   /* ------------------------------------------------------------ */
}