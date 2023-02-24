using Tetra.Testing;

namespace Check;

public sealed class Given
{
   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public TheButtonHasNotBeenCreated.Arrange The_UI_has_not_created_the_button()
      => The_UI_has_not_created_the_button(nameof(The_UI_has_not_created_the_button));

   /* ------------------------------------------------------------ */

   public TheButtonHasBeenCreated.Arrange The_UI_has_created_the_button(The_UI_creates_a_button args)
      => The_UI_has_not_created_the_button($"{nameof(The_UI_has_created_the_button)}: {args.BriefCharacterisation()}")
        .The_UI_creates_the_button(args);

   /* ------------------------------------------------------------ */
   // Internal Constructors
   /* ------------------------------------------------------------ */

   internal Given() { }

   /* ------------------------------------------------------------ */
   // Private Functions
   /* ------------------------------------------------------------ */

   public TheButtonHasNotBeenCreated.Arrange The_UI_has_not_created_the_button(string fullCharacterisation)
      => new(AAATest.Factory(),
             characteriser => characteriser
                             .AddClauseToBriefCharacterisation(fullCharacterisation)
                             .AddClauseToFullCharacterisation(nameof(The_UI_has_not_created_the_button)),
             _ => new());

   /* ------------------------------------------------------------ */

   /* ------------------------------------------------------------ */
}