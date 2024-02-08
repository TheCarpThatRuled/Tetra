using Tetra;
using Tetra.Testing;

namespace Check.Check_Text_Box;

partial class Actions
{
   private interface IActions
   {
      /* ------------------------------------------------------------ */
      // Properties
      /* ------------------------------------------------------------ */

      public TwoWayBindingActions<bool, Actions> IsEnabled { get; }

      /* ------------------------------------------------------------ */

      public TwoWayBindingActions<string, Actions> Text { get; }

      /* ------------------------------------------------------------ */

      public TextBoxActions<Actions> TextBox { get; }

      /* ------------------------------------------------------------ */

      public TwoWayBindingActions<Visibility, Actions> Visibility { get; }

      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */


      public Asserts Asserts();

      /* ------------------------------------------------------------ */

      public void CreateTextBox
      (
         The_UI_creates_a_text_box args
      );

      /* ------------------------------------------------------------ */
   }
}