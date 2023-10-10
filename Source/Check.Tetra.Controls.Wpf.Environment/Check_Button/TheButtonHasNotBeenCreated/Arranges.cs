using Tetra;
using Tetra.Testing;

// ReSharper disable InconsistentNaming

namespace Check.Check_Button;

public sealed partial class TheButtonHasNotBeenCreated
{
   public sealed class Arranges : IArranges
   {
      /* ------------------------------------------------------------ */
      // Private Constructors
      /* ------------------------------------------------------------ */

      private Arranges() { }
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public TheButtonHasBeenCreated.Arranges The_UI_creates_the_button
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

      public Act WHEN()
         => new();

      /* ------------------------------------------------------------ */
      // Internal Factory Functions
      /* ------------------------------------------------------------ */

      internal static Arranges Create
      (
         AAA_test.Disposables _
      )
         => new();

      /* ------------------------------------------------------------ */
   }
}