using Tetra;
using Tetra.Testing;

namespace Check.Check_Button;

partial class Actions
{
   private sealed class HasNotBeenCreated : IActions
   {
      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly Actions          _parent;
      private readonly Action<IActions> _updateState;

      //Mutable
      private bool _finalised = false;

      /* ------------------------------------------------------------ */
      // Private Constructors
      /* ------------------------------------------------------------ */

      private HasNotBeenCreated
      (
         Actions          parent,
         Action<IActions> updateState
      )
      {
         _parent      = parent;
         _updateState = updateState;
      }

      /* ------------------------------------------------------------ */
      // Factory Functions
      /* ------------------------------------------------------------ */

      public static HasNotBeenCreated Create
      (
         Actions          parent,
         Action<IActions> updateState
      )
         => new(parent,
                updateState);

      /* ------------------------------------------------------------ */
      // IActions Properties
      /* ------------------------------------------------------------ */

      public ButtonActions<Actions> Button
         => throw Failed.InTestSetup("Cannot perform an action on the button; it has not been created.");

      /* ------------------------------------------------------------ */

      public TwoWayBindingActions<bool, Actions> IsEnabled
         => throw Failed.InTestSetup("Cannot perform an action on IsEnabled; the button has not been created.");

      /* ------------------------------------------------------------ */

      public TwoWayBindingActions<Visibility, Actions> Visibility
         => throw Failed.InTestSetup("Cannot perform an action on Visibility; the button has not been created.");

      /* ------------------------------------------------------------ */
      // IActions Methods
      /* ------------------------------------------------------------ */

      public Asserts Asserts()
         => throw Failed.InTestSetup("Cannot progress to the asserts; no actions have been performed.");

      /* ------------------------------------------------------------ */

      public void CreateButton
      (
         The_UI_creates_a_button args
      )
      {
         var system = FakeSystem.Create(args);
         var button = FakeButton.Create(ButtonContext.Create(Tetra
                                                            .Button
                                                            .Factory()
                                                            .OnClick(system
                                                                    .OnClick()
                                                                    .Action)
                                                            .IsEnabled(system.IsEnabled())
                                                            .Visibility(system.Visibility())));
         _updateState(HasBeenCreated.Create(_parent,
                                            _finalised,
                                            button,
                                            system));
      }

      /* ------------------------------------------------------------ */

      public void FinishArrange()
      {
         if (_finalised)
         {
            throw Failed.InTestSetup("The test environment cannot be finalised; it has already been finalised");
         }

         _finalised = true;
      }

      /* ------------------------------------------------------------ */
   }
}