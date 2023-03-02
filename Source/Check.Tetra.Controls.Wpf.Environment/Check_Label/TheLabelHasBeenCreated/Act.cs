using Tetra;
using Tetra.Testing;

namespace Check.Check_Label;

public sealed partial class TheLabelHasBeenCreated
{
   public sealed class Act : IAct
   {
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public Act<Asserts<AssertsInstance>> The_system_updates_Content(object content)
         => new(new(_factory.When<AssertsInstance>(characteriser =>
                    {
                       characteriser.AddClauseToCharacterisation($"{nameof(The_system_updates_Content)}: {content}");

                       return instance => instance
                                         .The_system_updates_Content(content)
                                         .THEN();
                    }),
                    Function.PassThrough,
                    Function.PassThrough));

      /* ------------------------------------------------------------ */

      public Act<Asserts<AssertsInstance>> The_system_updates_Visibility(Visibility visibility)
         => new(new(_factory.When<AssertsInstance>(characteriser =>
                    {
                       characteriser.AddClauseToCharacterisation($"{nameof(The_system_updates_Visibility)}: {visibility}");

                       return instance => instance
                                         .The_system_updates_Visibility(visibility)
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