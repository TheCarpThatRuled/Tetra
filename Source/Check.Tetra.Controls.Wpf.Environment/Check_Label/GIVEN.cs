using Tetra.Testing;

// ReSharper disable InconsistentNaming

namespace Check.Check_Label;

public static class GIVEN
{
   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public static TheLabelHasNotBeenCreated.Arrange The_UI_has_not_created_the_label()
      => The_UI_has_not_created_the_label(nameof(The_UI_has_not_created_the_label));

   /* ------------------------------------------------------------ */

   public static TheLabelHasBeenCreated.Arrange The_UI_has_created_the_label(The_UI_creates_a_label args)
      => The_UI_has_not_created_the_label($"{nameof(The_UI_has_created_the_label)}: {args.BriefCharacterisation()}")
        .The_UI_creates_the_label(args);

   /* ------------------------------------------------------------ */
   // Private Functions
   /* ------------------------------------------------------------ */

   public static TheLabelHasNotBeenCreated.Arrange The_UI_has_not_created_the_label(string fullCharacterisation)
      => new(AAATest.Factory(),
             characteriser => characteriser
                             .AddClauseToBriefCharacterisation(fullCharacterisation)
                             .AddClauseToFullCharacterisation(nameof(The_UI_has_not_created_the_label)),
             _ => new());

   /* ------------------------------------------------------------ */
}