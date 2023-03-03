using Tetra;
using Tetra.Testing;

namespace Check.Check_TextBox;

public sealed partial class TheTextBoxHasBeenCreated
{
   public sealed class ActInstance : IActInstance
   {
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public ActInstance<AssertsInstance> The_system_updates_IsEnabled(bool isEnabled)
         => new(() => Update_IsEnabled(isEnabled));

      /* ------------------------------------------------------------ */

      public ActInstance<AssertsInstance> The_system_updates_Text(string text)
         => new(() => Update_Text(text));

      /* ------------------------------------------------------------ */

      public ActInstance<AssertsInstance> The_system_updates_Visibility(Visibility visibility)
         => new(() => Update_Visibility(visibility));

      /* ------------------------------------------------------------ */

      public ActInstance<AssertsInstance> The_user_enters_text(string text)
         => new(() => Enter_Text(text));

      /* ------------------------------------------------------------ */
      // Internal Constructors
      /* ------------------------------------------------------------ */

      internal ActInstance(FakeTextBox textBox,
                           FakeSystem  system)
      {
         _textBox = textBox;
         _system  = system;
      }

      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly FakeTextBox _textBox;
      private readonly FakeSystem  _system;

      /* ------------------------------------------------------------ */
      // Private Methods
      /* ------------------------------------------------------------ */

      private AssertsInstance Enter_Text(string text)
      {
         _textBox.EnterText(text);

         return new(_textBox,
                    _system);
      }

      /* ------------------------------------------------------------ */

      private AssertsInstance Update_IsEnabled(bool isEnabled)
      {
         _system.IsEnabled()
                .Push(isEnabled);

         return new(_textBox,
                    _system);
      }

      /* ------------------------------------------------------------ */

      private AssertsInstance Update_Text(string text)
      {
         _system.Text()
                .Push(text);

         return new(_textBox,
                    _system);
      }

      /* ------------------------------------------------------------ */

      private AssertsInstance Update_Visibility(Visibility visibility)
      {
         _system.Visibility()
                .Push(visibility);

         return new(_textBox,
                    _system);
      }

      /* ------------------------------------------------------------ */
   }
}