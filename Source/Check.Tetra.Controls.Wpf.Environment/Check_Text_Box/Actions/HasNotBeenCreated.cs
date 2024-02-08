using Tetra;
using Tetra.Testing;

namespace Check.Check_Text_Box;

partial class Actions
{
   private sealed class HasNotBeenCreated : IActions
   {
      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly Actions          _parent;
      private readonly Action<IActions> _updateState;

      /* ------------------------------------------------------------ */
      // Constructors
      /* ------------------------------------------------------------ */

      public HasNotBeenCreated
      (
         Actions          parent,
         Action<IActions> updateState
      )
      {
         _parent      = parent;
         _updateState = updateState;
      }

      /* ------------------------------------------------------------ */
      // IActions Properties
      /* ------------------------------------------------------------ */

      public TwoWayBindingActions<bool, Actions> IsEnabled
         => throw Failed.Assert("Cannot perform an action on Content; the text box has not been created.");

      /* ------------------------------------------------------------ */

      public TwoWayBindingActions<string, Actions> Text
         => throw Failed.Assert("Cannot perform an action on Text; the text box has not been created.");

      /* ------------------------------------------------------------ */

      public TextBoxActions<Actions> TextBox
         => throw Failed.Assert("Cannot perform an action on the text box; it has not been created.");

      /* ------------------------------------------------------------ */

      public TwoWayBindingActions<Visibility, Actions> Visibility
         => throw Failed.Assert("Cannot perform an action on Visibility; the text box has not been created.");

      /* ------------------------------------------------------------ */
      // IActions Methods
      /* ------------------------------------------------------------ */

      public Asserts Asserts()
         => throw Failed.InTestSetup("Cannot progress to the asserts; no actions have been performed.");

      /* ------------------------------------------------------------ */

      public void CreateTextBox
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

         _updateState(new HasBeenCreated(_parent,
                                         textBox,
                                         system));
      }

      /* ------------------------------------------------------------ */
   }
}