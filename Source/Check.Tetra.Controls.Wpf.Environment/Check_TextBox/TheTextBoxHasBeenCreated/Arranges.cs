using Tetra;
using Tetra.Testing;

// ReSharper disable InconsistentNaming

namespace Check.Check_TextBox;

public sealed partial class TheTextBoxHasBeenCreated
{
   public sealed class Arranges : IArranges
   {
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public Arranges The_system_updates_IsEnabled(bool isEnabled)
      {
         _system.IsEnabled()
                .Push(isEnabled);

         return this;
      }

      /* ------------------------------------------------------------ */

      public Arranges The_system_updates_Text(string text)
      {
         _system.Text()
                .Push(text);

         return this;
      }

      /* ------------------------------------------------------------ */

      public Arranges The_system_updates_Visibility(Visibility visibility)
      {
         _system.Visibility()
                .Push(visibility);

         return this;
      }

      /* ------------------------------------------------------------ */

      public Arranges The_user_enters_text(string text)
      {
         _textBox.EnterText(text);

         return this;
      }

      /* ------------------------------------------------------------ */

      public Acts WHEN()
         => new(_textBox,
                _system);

      /* ------------------------------------------------------------ */
      // Internal Constructors
      /* ------------------------------------------------------------ */

      internal Arranges(FakeTextBox textBox,
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