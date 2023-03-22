using Tetra;
using Tetra.Testing;

// ReSharper disable InconsistentNaming

namespace Check.Check_Button;

public sealed partial class TheButtonHasBeenCreated
{
   public sealed class Arranges : IArranges
   {
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public Arranges The_system_updates_IsEnabled(bool isEnabled)
      {
         _system.IsEnabled()
                .Push(isEnabled);

         return this;
      }

      /* ------------------------------------------------------------ */

      public Arranges The_system_updates_Visibility(Visibility visibility)
      {
         _system.Visibility()
                .Push(visibility);

         return this;
      }

      /* ------------------------------------------------------------ */

      public Arranges The_user_clicks_the_button(uint numberOfClicks)
      {
         _button.Click(numberOfClicks);

         return this;
      }

      /* ------------------------------------------------------------ */

      public Acts WHEN()
         => new(_button,
                _system);

      /* ------------------------------------------------------------ */
      // Internal Constructors
      /* ------------------------------------------------------------ */

      internal Arranges(FakeButton button,
                        FakeSystem system)
      {
         _button = button;
         _system = system;
      }

      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly FakeButton _button;
      private readonly FakeSystem _system;

      /* ------------------------------------------------------------ */
   }
}