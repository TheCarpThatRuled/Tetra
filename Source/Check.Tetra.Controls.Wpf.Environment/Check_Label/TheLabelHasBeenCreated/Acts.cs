using Tetra;
using Tetra.Testing;

namespace Check.Check_Label;

public sealed partial class TheLabelHasBeenCreated
{
   public sealed class Acts : IActs
   {
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public Act<Asserts> The_system_updates_Content(object content)
         => new(() => Update_Content(content));

      /* ------------------------------------------------------------ */

      public Act<Asserts> The_system_updates_Visibility(Visibility visibility)
         => new(() => Update_Visibility(visibility));

      /* ------------------------------------------------------------ */
      // Internal Constructors
      /* ------------------------------------------------------------ */

      internal Acts(FakeLabel  label,
                    FakeSystem system)
      {
         _label  = label;
         _system = system;
      }

      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly FakeLabel  _label;
      private readonly FakeSystem _system;

      /* ------------------------------------------------------------ */
      // Private Methods
      /* ------------------------------------------------------------ */

      private Asserts Update_Content(object content)
      {
         _system.Content()
                .Push(content);

         return new(_label,
                    _system);
      }

      /* ------------------------------------------------------------ */

      private Asserts Update_Visibility(Visibility visibility)
      {
         _system.Visibility()
                .Push(visibility);

         return new(_label,
                    _system);
      }

      /* ------------------------------------------------------------ */
   }
}