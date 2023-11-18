using Tetra;
using Tetra.Testing;

namespace Check.Check_TextBox;

partial class Actions
{
   private sealed class HasNotBeenCreated : Actions
   {
      /* ------------------------------------------------------------ */
      // ITestEnvironment<Asserts> Methods
      /* ------------------------------------------------------------ */

      public override Asserts Asserts()
         => throw Failed.Assert("Cannot progress to the asserts; no actions have been performed.");

      /* ------------------------------------------------------------ */

      public override void FinishArrange() { }

      /* ------------------------------------------------------------ */
      // Properties
      /* ------------------------------------------------------------ */

      public override TwoWayBindingActions<bool, Actions> IsEnabled
         => throw Failed.Assert("Cannot perform an action on Content; the text box has not been created.");

      /* ------------------------------------------------------------ */

      public override TwoWayBindingActions<string, Actions> Text
         => throw Failed.Assert("Cannot perform an action on Text; the text box has not been created.");

      /* ------------------------------------------------------------ */

      public override TextBoxActions<Actions> TextBox
         => throw Failed.Assert("Cannot perform an action on the text box; it has not been created.");

      /* ------------------------------------------------------------ */

      public override TwoWayBindingActions<Visibility, Actions> Visibility
         => throw Failed.Assert("Cannot perform an action on Visibility; the text box has not been created.");

      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public override Actions CreateTextBox
      (
         The_UI_creates_a_text_box args
      )
      {
         var system = FakeSystem.Create(args);
         var textBox = FakeTextBox.Create(TextBoxContext.Create(Tetra
                                                               .TextBox
                                                               .Factory()
                                                               .Text(system.Text())
                                                               .IsEnabled(system.IsEnabled())
                                                               .Visibility(system.Visibility())));

         return new HasBeenCreated(textBox,
                                   system);
      }

      /* ------------------------------------------------------------ */
   }
}