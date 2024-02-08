using Tetra;
using Tetra.Testing;

namespace Check.Check_Label;

partial class Actions
{
   private interface IActions
   {
      /* ------------------------------------------------------------ */
      // Properties
      /* ------------------------------------------------------------ */

      public TwoWayBindingActions<object, Actions> Content { get; }

      /* ------------------------------------------------------------ */

      public TwoWayBindingActions<Visibility, Actions> Visibility { get; }

      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */


      public Asserts Asserts();

      /* ------------------------------------------------------------ */

      public void CreateLabel
      (
         The_UI_creates_a_label args
      );

      /* ------------------------------------------------------------ */
   }
}