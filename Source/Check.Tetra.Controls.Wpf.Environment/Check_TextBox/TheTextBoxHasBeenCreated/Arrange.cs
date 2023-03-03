using Tetra;
using Tetra.Testing;
using static Tetra.Testing.AAATest;

// ReSharper disable InconsistentNaming

namespace Check.Check_TextBox;

public sealed partial class TheTextBoxHasBeenCreated
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

      public Arrange The_system_updates_IsEnabled(bool isEnabled)
      {
         Add(characteriser => characteriser.AddClauseToFullCharacterisation($"{nameof(The_system_updates_IsEnabled)}: {isEnabled}"),
             given => given.The_system_updates_IsEnabled(isEnabled));

         return this;
      }

      /* ------------------------------------------------------------ */

      public Arrange The_system_updates_Text(string isEnabled)
      {
         Add(characteriser => characteriser.AddClauseToFullCharacterisation($"{nameof(The_system_updates_Text)}: {isEnabled}"),
             given => given.The_system_updates_Text(isEnabled));

         return this;
      }

      /* ------------------------------------------------------------ */

      public Arrange The_system_updates_Visibility(Visibility visibility)
      {
         Add(characteriser => characteriser.AddClauseToFullCharacterisation($"{nameof(The_system_updates_Visibility)}: {visibility}"),
             given => given.The_system_updates_Visibility(visibility));

         return this;
      }

      /* ------------------------------------------------------------ */

      public Arrange The_user_enters_text(string text)
      {
         Add(characteriser => characteriser.AddClauseToFullCharacterisation($"{nameof(The_user_enters_text)}: {text}"),
             given => given.The_user_enters_text(text));

         return this;
      }

      /* ------------------------------------------------------------ */
      // Internal Factory Functions
      /* ------------------------------------------------------------ */

      internal static Arrange Create(DefineGiven                                  factory,
                                     Func<GivenCharacteriser, GivenCharacteriser> characterisation,
                                     Func<Disposables, ArrangeInstance>           given)
         => new(factory,
                characterisation,
                given);

      /* ------------------------------------------------------------ */
      // Private Constructors
      /* ------------------------------------------------------------ */

      private Arrange(DefineGiven                                  factory,
                      Func<GivenCharacteriser, GivenCharacteriser> characterisation,
                      Func<Disposables, ArrangeInstance>           given) : base(factory,
                                                                                 characterisation,
                                                                                 given) { }

      /* ------------------------------------------------------------ */
   }
}