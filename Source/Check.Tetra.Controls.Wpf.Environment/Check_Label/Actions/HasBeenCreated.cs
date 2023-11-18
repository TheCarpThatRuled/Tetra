using Tetra;
using Tetra.Testing;

namespace Check.Check_Label;

partial class Actions
{
   private sealed class HasBeenCreated : Actions
   {
      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly FakeLabel  _label;
      private readonly FakeSystem _system;

      /* ------------------------------------------------------------ */
      // Constructors
      /* ------------------------------------------------------------ */

      public HasBeenCreated
      (
         FakeLabel  label,
         FakeSystem system
      )
      {
         _label  = label;
         _system = system;

         Content = TwoWayBindingActions<object, Actions>.Create("Content",
                                                                system.Content(),
                                                                () => this);

         Visibility = TwoWayBindingActions<Visibility, Actions>.Create("Visibility",
                                                                       system.Visibility(),
                                                                       () => this);
      }

      /* ------------------------------------------------------------ */
      // ITestEnvironment<Asserts> Methods
      /* ------------------------------------------------------------ */

      public override Asserts Asserts()
         => new(_label,
                _system);

      /* ------------------------------------------------------------ */

      public override void FinishArrange() { }

      /* ------------------------------------------------------------ */
      // Properties
      /* ------------------------------------------------------------ */

      public override TwoWayBindingActions<object, Actions> Content { get; }

      /* ------------------------------------------------------------ */

      public override TwoWayBindingActions<Visibility, Actions> Visibility { get; }

      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public override Actions CreateLabel
      (
         The_UI_creates_a_label args
      )
         => throw Failed.Assert("Cannot create the label; it has already been created.");

      /* ------------------------------------------------------------ */
   }
}