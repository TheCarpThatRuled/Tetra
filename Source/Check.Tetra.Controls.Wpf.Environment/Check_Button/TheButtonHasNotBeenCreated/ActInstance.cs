using Tetra;
using Tetra.Testing;

namespace Check.Check_Button;

public sealed partial class TheButtonHasNotBeenCreated
{
   public sealed class ActInstance : IActInstance
   {
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public ActInstance<TheButtonHasBeenCreated.AssertsInstance> The_UI_creates_the_button(The_UI_creates_a_button args)
         => new(() => Create_the_button(args));

      /* ------------------------------------------------------------ */
      // Internal Constructors
      /* ------------------------------------------------------------ */

      internal ActInstance() { }

      /* ------------------------------------------------------------ */
      // Private Methods
      /* ------------------------------------------------------------ */

      private TheButtonHasBeenCreated.AssertsInstance Create_the_button(The_UI_creates_a_button args)
      {
         var system = FakeSystem.Create(args);
         return new(FakeButton.Create(ButtonContext.Create(Button
                                                          .Factory()
                                                          .OnClick(system
                                                                  .OnClick()
                                                                  .Func)
                                                          .IsEnabled(system.IsEnabled())
                                                          .Visibility(system.Visibility()))),
                    system);
      }

      /* ------------------------------------------------------------ */
   }
}