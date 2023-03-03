using Tetra;
using Tetra.Testing;

namespace Check.Check_TextBox;

public sealed partial class TheTextBoxHasNotBeenCreated
{
   public sealed class Act : IAct
   {
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public Act<TheTextBoxHasBeenCreated.Asserts<TheTextBoxHasBeenCreated.AssertsInstance>> The_UI_creates_the_text_box(The_UI_creates_a_text_box args)
         => new(new(_factory.When<TheTextBoxHasBeenCreated.AssertsInstance>(characteriser =>
                    {
                       characteriser.AddClauseToBriefCharacterisation($"{nameof(The_UI_creates_the_text_box)}: {args.BriefCharacterisation()}");
                       characteriser.AddClauseToFullCharacterisation($"{nameof(The_UI_creates_the_text_box)}:{Environment.NewLine}{args.FullCharacterisation()}");

                       return instance => instance
                                         .The_UI_creates_the_text_box(args)
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