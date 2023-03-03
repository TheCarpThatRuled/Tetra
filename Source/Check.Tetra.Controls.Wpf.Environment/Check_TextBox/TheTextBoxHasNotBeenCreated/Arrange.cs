using Tetra.Testing;
using static Tetra.Testing.AAATest;
// ReSharper disable InconsistentNaming

namespace Check.Check_TextBox;

public sealed partial class TheTextBoxHasNotBeenCreated
{
   public sealed class Arrange : Arrange<Act, ArrangeInstance, ActInstance>
   {
      /* ------------------------------------------------------------ */
      // Arrange<Act, ArrangeInstance, ActInstance> Overridden Methods
      /* ------------------------------------------------------------ */

      protected override Act CreateAct(DefineWhen<ActInstance> factory)
         => new(factory);

      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public TheTextBoxHasBeenCreated.Arrange The_UI_creates_the_text_box(The_UI_creates_a_text_box args)
         => Add(TheTextBoxHasBeenCreated.Arrange.Create,
                characteriser => characteriser.AddClauseToFullCharacterisation($"{nameof(The_UI_creates_the_text_box)}:{Environment.NewLine}{args.FullCharacterisation()}"),
                given => given.The_UI_creates_the_text_box(args));

      /* ------------------------------------------------------------ */
      // Internal Constructors
      /* ------------------------------------------------------------ */

      internal Arrange(DefineGiven                                  factory,
                       Func<GivenCharacteriser, GivenCharacteriser> characterisation,
                       Func<Disposables, ArrangeInstance>           given) : base(factory,
                                                                                  characterisation,
                                                                                  given) { }

      /* ------------------------------------------------------------ */
   }
}