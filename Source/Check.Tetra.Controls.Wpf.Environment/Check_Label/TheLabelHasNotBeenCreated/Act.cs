using Tetra;
using Tetra.Testing;

namespace Check.Check_Label;

public sealed partial class TheLabelHasNotBeenCreated
{
   public sealed class Act : IAct
   {
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public Act<TheLabelHasBeenCreated.Asserts<TheLabelHasBeenCreated.AssertsInstance>> The_UI_creates_the_label(The_UI_creates_a_label args)
         => new(new(_factory.When<TheLabelHasBeenCreated.AssertsInstance>(characteriser =>
                    {
                       characteriser.AddClauseToBriefCharacterisation($"{nameof(The_UI_creates_the_label)}: {args.BriefCharacterisation()}");
                       characteriser.AddClauseToFullCharacterisation($"{nameof(The_UI_creates_the_label)}:{Environment.NewLine}{args.FullCharacterisation()}");

                       return instance => instance
                                         .The_UI_creates_the_label(args)
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