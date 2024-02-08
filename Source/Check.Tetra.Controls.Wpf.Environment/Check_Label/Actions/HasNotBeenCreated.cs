using Tetra;
using Tetra.Testing;

namespace Check.Check_Label;

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

      public TwoWayBindingActions<object, Actions> Content
         => throw Failed.Assert("Cannot perform an action on Content; the label has not been created.");

      /* ------------------------------------------------------------ */

      public TwoWayBindingActions<Visibility, Actions> Visibility
         => throw Failed.Assert("Cannot perform an action on Visibility; the label has not been created.");

      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public Asserts Asserts()
         => throw Failed.InTestSetup("Cannot progress to the asserts; no actions have been performed.");

      /* ------------------------------------------------------------ */

      public void CreateLabel
      (
         The_UI_creates_a_label args
      )
      {
         var system = FakeSystem.Create(args);
         var label = FakeLabel.Create(LabelContext.Create(Label
                                                         .Factory()
                                                         .Content(system.Content())
                                                         .Visibility(system.Visibility())));

         _updateState(new HasBeenCreated(_parent,
                                         label,
                                         system));
      }

      /* ------------------------------------------------------------ */
   }
}