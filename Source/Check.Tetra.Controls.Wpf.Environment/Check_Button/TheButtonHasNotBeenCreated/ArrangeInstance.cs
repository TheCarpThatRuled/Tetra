using Tetra;
using Tetra.Testing;

// ReSharper disable InconsistentNaming

namespace Check.Check_Button;

public sealed partial class TheButtonHasNotBeenCreated
{
   public sealed class ArrangeInstance : IArrangeInstance<ActInstance>
   {
      /* ------------------------------------------------------------ */
      // IArrangeInstance<ActInstance> Methods
      /* ------------------------------------------------------------ */

      public ActInstance WHEN()
         => new();

      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public TheButtonHasBeenCreated.ArrangeInstance The_UI_creates_the_button(The_UI_creates_a_button args)
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
      // Internal Constructors
      /* ------------------------------------------------------------ */

      internal ArrangeInstance() { }

      /* ------------------------------------------------------------ */
   }
}