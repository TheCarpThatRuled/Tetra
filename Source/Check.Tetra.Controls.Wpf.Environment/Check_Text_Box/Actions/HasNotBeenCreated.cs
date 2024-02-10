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
         => throw Failed
                 .CannotPerformAnActionOnBecauseADependencyHasNotBeenCreated("IsEnabled",
                                                                             "the text box")
                 .ToAssertFailedException();

      /* ------------------------------------------------------------ */

      public TwoWayBindingActions<string, Actions> Text
         => throw Failed
                 .CannotPerformAnActionOnBecauseADependencyHasNotBeenCreated("Text",
                                                                             "the text box")
                 .ToAssertFailedException();

      /* ------------------------------------------------------------ */

      public TextBoxActions<Actions> TextBox
         => throw Failed
                 .CannotPerformAnActionOnBecauseADependencyHasNotBeenCreated("the text box",
                                                                             "it")
                 .ToAssertFailedException();

      /* ------------------------------------------------------------ */

      public TwoWayBindingActions<Visibility, Actions> Visibility
         => throw Failed
                 .CannotPerformAnActionOnBecauseADependencyHasNotBeenCreated("Visibility",
                                                                             "the text box")
                 .ToAssertFailedException();

      /* ------------------------------------------------------------ */
      // IActions Methods
      /* ------------------------------------------------------------ */

      public Asserts Asserts()
         => throw Failed
                 .CannotProgressToTheAssertsBecauseNoActionsHaveBeenPerformed()
                 .ToAssertFailedException();

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