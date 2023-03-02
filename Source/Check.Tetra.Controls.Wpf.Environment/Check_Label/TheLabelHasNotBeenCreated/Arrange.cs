using Tetra.Testing;
using static Tetra.Testing.AAATest;
// ReSharper disable InconsistentNaming

namespace Check.Check_Label;

public sealed partial class TheLabelHasNotBeenCreated
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

      public TheLabelHasBeenCreated.Arrange The_UI_creates_the_label(The_UI_creates_a_label args)
         => Add(TheLabelHasBeenCreated.Arrange.Create,
                characteriser => characteriser.AddClauseToFullCharacterisation($"{nameof(The_UI_creates_the_label)}:{Environment.NewLine}{args.FullCharacterisation()}"),
                given => given.The_UI_creates_the_label(args));

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
