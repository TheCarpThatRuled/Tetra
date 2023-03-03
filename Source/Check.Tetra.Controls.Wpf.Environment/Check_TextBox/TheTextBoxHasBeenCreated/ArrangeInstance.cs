using Tetra;
using Tetra.Testing;

// ReSharper disable InconsistentNaming

namespace Check.Check_TextBox;

public sealed partial class TheTextBoxHasBeenCreated
{
   public sealed class ArrangeInstance : IArrangeInstance<ActInstance>
   {
      /* ------------------------------------------------------------ */
      // IArrangeInstance<ActInstance> Methods
      /* ------------------------------------------------------------ */

      public ActInstance WHEN()
         => new(_textBox,
                _system);

      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public ArrangeInstance The_system_updates_IsEnabled(bool isEnabled)
      {
         _system.IsEnabled()
                .Push(isEnabled);

         return this;
      }

      /* ------------------------------------------------------------ */

      public ArrangeInstance The_system_updates_Text(string text)
      {
         _system.Text()
                .Push(text);

         return this;
      }

      /* ------------------------------------------------------------ */

      public ArrangeInstance The_system_updates_Visibility(Visibility visibility)
      {
         _system.Visibility()
                .Push(visibility);

         return this;
      }

      /* ------------------------------------------------------------ */

      public ArrangeInstance The_user_enters_text(string text)
      {
         _textBox.EnterText(text);

         return this;
      }

      /* ------------------------------------------------------------ */
      // Internal Constructors
      /* ------------------------------------------------------------ */

      internal ArrangeInstance(FakeTextBox textBox,
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
   }
}