using Tetra;
using Tetra.Testing;

namespace Check.Check_Label;

partial class Actions
{
   private sealed class HasBeenCreated : IActions
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
         Actions    actions,
         FakeLabel  label,
         FakeSystem system
      )
      {
         _label  = label;
         _system = system;

         Content = TwoWayBindingActions<object, Actions>.Create("Content",
                                                                system.Content(),
                                                                () => actions);

         Visibility = TwoWayBindingActions<Visibility, Actions>.Create("Visibility",
                                                                       system.Visibility(),
                                                                       () => actions);
      }

      /* ------------------------------------------------------------ */
      // IActions Properties
      /* ------------------------------------------------------------ */

      public TwoWayBindingActions<object, Actions> Content { get; }

      /* ------------------------------------------------------------ */

      public TwoWayBindingActions<Visibility, Actions> Visibility { get; }

      /* ------------------------------------------------------------ */
      // IActions Methods
      /* ------------------------------------------------------------ */

      public Asserts Asserts()
         => Check_Label
           .Asserts
           .Create(_label,
                   _system);

      /* ------------------------------------------------------------ */

      public void CreateLabel
      (
         The_UI_creates_a_label args
      )
         => throw Failed.Assert("Cannot create the label; it has already been created.");

      /* ------------------------------------------------------------ */
   }
}