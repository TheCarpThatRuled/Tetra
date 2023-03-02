using Tetra;
using Tetra.Testing;

// ReSharper disable InconsistentNaming

namespace Check.Check_Button;

public sealed partial class TheButtonHasBeenCreated
{
   public sealed class ArrangeInstance : IArrangeInstance<ActInstance>
   {
      /* ------------------------------------------------------------ */
      // IArrangeInstance<ActInstance> Methods
      /* ------------------------------------------------------------ */

      public ActInstance WHEN()
         => new(_button,
                _system);

      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public ArrangeInstance The_system_updates_IsEnabled(bool isEnabled)
      {
         _system.IsEnabled()
                .Push(isEnabled);

         return this;
      }

      /* ------------------------------------------------------------ */

      public ArrangeInstance The_system_updates_Visibility(Visibility visibility)
      {
         _system.Visibility()
                .Push(visibility);

         return this;
      }

      /* ------------------------------------------------------------ */

      public ArrangeInstance The_user_clicks_the_button(uint numberOfClicks)
      {
         _button.Click(numberOfClicks);

         return this;
      }

      /* ------------------------------------------------------------ */
      // Internal Constructors
      /* ------------------------------------------------------------ */

      internal ArrangeInstance(FakeButton button,
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