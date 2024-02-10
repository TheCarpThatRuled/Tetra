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
         => throw Failed
                 .CannotPerformAnActionOnBecauseADependencyHasNotBeenCreated("Content",
                                                                             "the label")
                 .ToAssertFailedException();
      /* ------------------------------------------------------------ */

      public TwoWayBindingActions<Visibility, Actions> Visibility
         => throw Failed
                 .CannotPerformAnActionOnBecauseADependencyHasNotBeenCreated("Visibility",
                                                                             "the label")
                 .ToAssertFailedException();

      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public Asserts Asserts()
         => throw Failed
                 .CannotProgressToTheAssertsBecauseNoActionsHaveBeenPerformed()
                 .ToAssertFailedException();

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