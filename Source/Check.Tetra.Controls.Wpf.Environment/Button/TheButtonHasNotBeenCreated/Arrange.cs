using Tetra.Testing;
using static Tetra.Testing.AAATest;
// ReSharper disable InconsistentNaming

namespace Check;

public sealed partial class TheButtonHasNotBeenCreated
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

      public TheButtonHasBeenCreated.Arrange The_UI_creates_the_button(The_UI_creates_a_button args)
         => Add(TheButtonHasBeenCreated.Arrange.Create,
                characteriser => characteriser.AddClauseToFullCharacterisation($"{nameof(The_UI_creates_the_button)}:{Environment.NewLine}{args.FullCharacterisation()}"),
                given => given.The_UI_developer_creates_the_button(args));

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
