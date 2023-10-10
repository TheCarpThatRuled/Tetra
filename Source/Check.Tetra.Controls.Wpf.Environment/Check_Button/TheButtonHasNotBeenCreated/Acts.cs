using Tetra;
using Tetra.Testing;

namespace Check.Check_Button;

public sealed partial class TheButtonHasNotBeenCreated
{
   public sealed class Act : IActs
   {
      /* ------------------------------------------------------------ */
      // Internal Constructors
      /* ------------------------------------------------------------ */

      internal Act() { }
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public Act<TheButtonHasBeenCreated.Asserts> The_UI_creates_the_button
      (
         The_UI_creates_a_button args
      )
         => new(() => Create_the_button(args));

      /* ------------------------------------------------------------ */
      // Private Methods
      /* ------------------------------------------------------------ */

      private TheButtonHasBeenCreated.Asserts Create_the_button
      (
         The_UI_creates_a_button args
      )
      {
         var system = FakeSystem.Create(args);
         return new(FakeButton.Create(ButtonContext.Create(Button
                                                          .Factory()
                                                          .OnClick(system
                                                                  .OnClick()
                                                                  .Action)
                                                          .IsEnabled(system.IsEnabled())
                                                          .Visibility(system.Visibility()))),
                    system);
      }

      /* ------------------------------------------------------------ */
   }
}