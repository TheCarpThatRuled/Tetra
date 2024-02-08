using Tetra;
using Tetra.Testing;

namespace Check.Check_Text_Box;

partial class Actions
{
   private sealed class HasBeenCreated : IActions
   {
      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly FakeTextBox _textBox;
      private readonly FakeSystem  _system;

      /* ------------------------------------------------------------ */
      // Constructors
      /* ------------------------------------------------------------ */

      public HasBeenCreated
      (
         Actions     actions,
         FakeTextBox textBox,
         FakeSystem  system
      )
      {
         _textBox = textBox;
         _system  = system;

         IsEnabled = TwoWayBindingActions<bool, Actions>.Create("IsEnabled",
                                                                system.IsEnabled(),
                                                                () => actions);

         Text = TwoWayBindingActions<string, Actions>.Create("Text",
                                                             system.Text(),
                                                             () => actions);

         TextBox = TextBoxActions<Actions>.Create("TextBox",
                                                  textBox,
                                                  () => actions);

         Visibility = TwoWayBindingActions<Visibility, Actions>.Create("Visibility",
                                                                       system.Visibility(),
                                                                       () => actions);
      }

      /* ------------------------------------------------------------ */
      // IActions Properties
      /* ------------------------------------------------------------ */

      public TwoWayBindingActions<bool, Actions> IsEnabled { get; }

      /* ------------------------------------------------------------ */

      public TwoWayBindingActions<string, Actions> Text { get; }

      /* ------------------------------------------------------------ */

      public TextBoxActions<Actions> TextBox { get; }

      /* ------------------------------------------------------------ */

      public TwoWayBindingActions<Visibility, Actions> Visibility { get; }

      /* ------------------------------------------------------------ */
      // IActions Methods
      /* ------------------------------------------------------------ */

      public Asserts Asserts()
         => Check_Text_Box
           .Asserts
           .Create(_textBox,
                   _system);

      /* ------------------------------------------------------------ */

      public void CreateTextBox
      (
         The_UI_creates_a_text_box args
      )
         => throw Failed.Assert("Cannot create the label; it has already been created.");

      /* ------------------------------------------------------------ */
   }
}