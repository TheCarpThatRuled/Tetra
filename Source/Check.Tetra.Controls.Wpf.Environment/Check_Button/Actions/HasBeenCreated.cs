using Tetra;
using Tetra.Testing;

namespace Check.Check_Button;

partial class Actions
{
   private sealed class HasBeenCreated : Actions
   {
      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly FakeButton _button;
      private readonly FakeSystem _system;

      /* ------------------------------------------------------------ */
      // Constructors
      /* ------------------------------------------------------------ */

      public HasBeenCreated
      (
         FakeButton button,
         FakeSystem system
      )
      {
         _button = button;
         _system = system;

         Button = ButtonActions<Actions>.Create("Button",
                                                button,
                                                () => this);

         IsEnabled = TwoWayBindingActions<bool, Actions>.Create("IsEnabled",
                                                                system.IsEnabled(),
                                                                () => this);

         Visibility = TwoWayBindingActions<Visibility, Actions>.Create("Visibility",
                                                                       system.Visibility(),
                                                                       () => this);
      }

      /* ------------------------------------------------------------ */
      // ITestEnvironment<Asserts> Methods
      /* ------------------------------------------------------------ */

      public override Asserts Asserts()
         => new(_button,
                _system);

      /* ------------------------------------------------------------ */

      public override void FinishArrange() { }

      /* ------------------------------------------------------------ */
      // Properties
      /* ------------------------------------------------------------ */

      public override ButtonActions<Actions> Button { get; }

      /* ------------------------------------------------------------ */

      public override TwoWayBindingActions<bool, Actions> IsEnabled { get; }

      /* ------------------------------------------------------------ */

      public override TwoWayBindingActions<Visibility, Actions> Visibility { get; }

      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public override Actions CreateButton
      (
         The_UI_creates_a_button args
      )
         => throw Failed.Assert("Cannot create the button; it has already been created.");

      /* ------------------------------------------------------------ */
   }
}