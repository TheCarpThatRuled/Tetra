using Tetra;
using Tetra.Testing;

namespace Check.Check_Button;

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

      public override ButtonActions<Actions> Button
         => throw Failed.Assert("Cannot perform an action on the button; it has not been created.");

      /* ------------------------------------------------------------ */

      public override TwoWayBindingActions<bool, Actions> IsEnabled
         => throw Failed.Assert("Cannot perform an action on IsEnabled; the button has not been created.");

      /* ------------------------------------------------------------ */

      public override TwoWayBindingActions<Visibility, Actions> Visibility
         => throw Failed.Assert("Cannot perform an action on Visibility; the button has not been created.");

      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public override Actions CreateButton
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

         return new HasBeenCreated(button,
                                   system);
      }

      /* ------------------------------------------------------------ */
   }
}