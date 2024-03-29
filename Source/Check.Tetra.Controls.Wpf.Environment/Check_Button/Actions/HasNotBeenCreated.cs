﻿using Tetra;
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
         => throw Failed
                 .CannotPerformAnActionOnBecauseADependencyHasNotBeenCreated("button",
                                                                             "it")
                 .ToAssertFailedException();

      /* ------------------------------------------------------------ */

      public TwoWayBindingActions<bool, Actions> IsEnabled
         => throw Failed
                 .CannotPerformAnActionOnBecauseADependencyHasNotBeenCreated("IsEnabled",
                                                                             "the button")
                 .ToAssertFailedException();

      /* ------------------------------------------------------------ */

      public TwoWayBindingActions<Visibility, Actions> Visibility
         => throw Failed
                 .CannotPerformAnActionOnBecauseADependencyHasNotBeenCreated("Visibility",
                                                                             "the button")
                 .ToAssertFailedException();

      /* ------------------------------------------------------------ */
      // IActions Methods
      /* ------------------------------------------------------------ */

      public Asserts Asserts()
         => throw Failed
                 .CannotProgressToTheAssertsBecauseNoActionsHaveBeenPerformed()
                 .ToAssertFailedException();

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
                                            button,
                                            system));
      }

      /* ------------------------------------------------------------ */
   }
}