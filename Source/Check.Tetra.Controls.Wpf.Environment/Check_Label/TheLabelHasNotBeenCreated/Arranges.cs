using Tetra;
using Tetra.Testing;

// ReSharper disable InconsistentNaming

namespace Check.Check_Label;

public sealed partial class TheLabelHasNotBeenCreated
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

      public TheLabelHasBeenCreated.Arranges The_UI_creates_the_label
      (
         The_UI_creates_a_label args
      )
      {
         var system = FakeSystem.Create(args);
         return new(FakeLabel.Create(LabelContext.Create(Label
                                                        .Factory()
                                                        .Content(system.Content())
                                                        .Visibility(system.Visibility()))),
                    system);
      }

      /* ------------------------------------------------------------ */

      public Acts WHEN()
         => new();

      /* ------------------------------------------------------------ */
      // Internal Factory Functions
      /* ------------------------------------------------------------ */

      public static Arranges Create
      (
         AAA_test.Disposables _
      )
         => new();

      /* ------------------------------------------------------------ */
   }
}