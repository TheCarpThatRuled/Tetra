using Tetra;
using Tetra.Testing;

namespace Check.Check_TextBox;

public sealed partial class TheTextBoxHasBeenCreated
{
   public sealed class Act : IAct
   {
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public Act<Asserts<AssertsInstance>> The_system_updates_IsEnabled(bool isEnabled)
         => new(Asserts<AssertsInstance>.Create(_factory.When<AssertsInstance>(characteriser =>
                                                {
                                                   characteriser.AddClauseToCharacterisation($"{nameof(The_system_updates_IsEnabled)}: {isEnabled}");

                                                   return instance => instance
                                                                     .The_system_updates_IsEnabled(isEnabled)
                                                                     .THEN();
                                                }),
                                                Function.PassThrough,
                                                Function.PassThrough));

      /* ------------------------------------------------------------ */

      public Act<Asserts<AssertsInstance>> The_system_updates_Text(string text)
         => new(Asserts<AssertsInstance>.Create(_factory.When<AssertsInstance>(characteriser =>
                                                {
                                                   characteriser.AddClauseToCharacterisation($@"{nameof(The_system_updates_Text)}: ""{text}""");

                                                   return instance => instance
                                                                     .The_system_updates_Text(text)
                                                                     .THEN();
                                                }),
                                                Function.PassThrough,
                                                Function.PassThrough));

      /* ------------------------------------------------------------ */

      public Act<Asserts<AssertsInstance>> The_system_updates_Visibility(Visibility visibility)
         => new(Asserts<AssertsInstance>.Create(_factory.When<AssertsInstance>(characteriser =>
                                                {
                                                   characteriser.AddClauseToCharacterisation($"{nameof(The_system_updates_Visibility)}: {visibility}");

                                                   return instance => instance
                                                                     .The_system_updates_Visibility(visibility)
                                                                     .THEN();
                                                }),
                                                Function.PassThrough,
                                                Function.PassThrough));

      /* ------------------------------------------------------------ */

      public Act<Asserts<AssertsInstance>> The_user_enters_text(string text)
         => new(Asserts<AssertsInstance>.Create(_factory.When<AssertsInstance>(characteriser =>
                                                {
                                                   characteriser.AddClauseToCharacterisation($@"{nameof(The_user_enters_text)}: ""{text}""");

                                                   return instance => instance
                                                                     .The_user_enters_text(text)
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