using Tetra;
using Tetra.Testing;

namespace Check.Check_TextBox;

partial class Actions
{
   private sealed class HasBeenCreated : Actions
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
         FakeTextBox textBox,
         FakeSystem  system
      )
      {
         _textBox = textBox;
         _system  = system;

         IsEnabled = TwoWayBindingActions<bool, Actions>.Create("IsEnabled",
                                                                system.IsEnabled(),
                                                                () => this);

         Text = TwoWayBindingActions<string, Actions>.Create("Text",
                                                             system.Text(),
                                                             () => this);

         TextBox = TextBoxActions<Actions>.Create("TextBox",
                                                  textBox,
                                                  () => this);

         Visibility = TwoWayBindingActions<Visibility, Actions>.Create("Visibility",
                                                                       system.Visibility(),
                                                                       () => this);
      }

      /* ------------------------------------------------------------ */
      // ITestEnvironment<Asserts> Methods
      /* ------------------------------------------------------------ */

      public override Asserts Asserts()
         => new(_textBox,
                _system);

      /* ------------------------------------------------------------ */

      public override void FinishArrange() { }

      /* ------------------------------------------------------------ */
      // Properties
      /* ------------------------------------------------------------ */

      public override TwoWayBindingActions<bool, Actions> IsEnabled { get; }

      /* ------------------------------------------------------------ */

      public override TwoWayBindingActions<string, Actions> Text { get; }

      /* ------------------------------------------------------------ */

      public override TextBoxActions<Actions> TextBox { get; }

      /* ------------------------------------------------------------ */

      public override TwoWayBindingActions<Visibility, Actions> Visibility { get; }

      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public override Actions CreateTextBox
      (
         The_UI_creates_a_text_box args
      )
         => throw Failed.Assert("Cannot create the label; it has already been created.");

      /* ------------------------------------------------------------ */
   }
}