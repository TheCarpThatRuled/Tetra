using Tetra;
using Tetra.Testing;

namespace Check.Check_Button;

public sealed partial class TheButtonHasBeenCreated
{
   public sealed class ActInstance : IActInstance
   {
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public ActInstance<AssertsInstance> The_system_updates_IsEnabled(bool isEnabled)
         => new(() => Update_IsEnabled(isEnabled));

      /* ------------------------------------------------------------ */

      public ActInstance<AssertsInstance> The_system_updates_Visibility(Visibility visibility)
         => new(() => Update_Visibility(visibility));

      /* ------------------------------------------------------------ */

      public ActInstance<AssertsInstance> The_user_clicks_the_button(uint numberOfClicks)
         => new(()=> Click_the_button(numberOfClicks));

      /* ------------------------------------------------------------ */
      // Internal Constructors
      /* ------------------------------------------------------------ */

      internal ActInstance(FakeButton button,
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
      // Private Methods
      /* ------------------------------------------------------------ */

      private AssertsInstance Click_the_button(uint numberOfClicks)
      {
         _button.Click(numberOfClicks);

         return new(_button,
                    _system);
      }

      /* ------------------------------------------------------------ */

      private AssertsInstance Update_IsEnabled(bool isEnabled)
      {
         _system.IsEnabled()
                .Push(isEnabled);

         return new(_button,
                    _system);
      }

      /* ------------------------------------------------------------ */

      private AssertsInstance Update_Visibility(Visibility visibility)
      {
         _system.Visibility()
                .Push(visibility);

         return new(_button,
                    _system);
      }

      /* ------------------------------------------------------------ */
   }
}