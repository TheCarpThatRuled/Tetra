using Tetra;
using Tetra.Testing;

namespace Check.Check_Button;

public sealed partial class TheButtonHasNotBeenCreated
{
   public sealed class Act : IAct
   {
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public Act<TheButtonHasBeenCreated.Asserts<TheButtonHasBeenCreated.AssertsInstance>> The_UI_creates_the_button(The_UI_creates_a_button args)
         => new(TheButtonHasBeenCreated.Asserts<TheButtonHasBeenCreated.AssertsInstance>.Create(_factory.When<TheButtonHasBeenCreated.AssertsInstance>(characteriser =>
                                                                                                {
                                                                                                   characteriser.AddClauseToBriefCharacterisation($"{nameof(The_UI_creates_the_button)}: {args.BriefCharacterisation()}");
                                                                                                   characteriser.AddClauseToFullCharacterisation($"{nameof(The_UI_creates_the_button)}:{Environment.NewLine}{args.FullCharacterisation()}");

                                                                                                   return instance => instance
                                                                                                                     .The_UI_creates_the_button(args)
                                                                                                                     .THEN();
                                                                                                }),
                                                                                                Function.PassThrough,
                                                                                                Function.PassThrough));

      /* ------------------------------------------------------------ */
      // Internal Constructors
      /* ------------------------------------------------------------ */

      internal Act(AAATest.DefineWhen<ActInstance> factory)
         => _factory = factory;

      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly AAATest.DefineWhen<ActInstance> _factory;

      /* ------------------------------------------------------------ */
   }
}