using Tetra;
using Tetra.Testing;

namespace Check.Check_Label;

public sealed partial class TheLabelHasNotBeenCreated
{
   public sealed class ActInstance : IActInstance
   {
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public ActInstance<TheLabelHasBeenCreated.AssertsInstance> The_UI_creates_the_label(The_UI_creates_a_label args)
         => new(() => Create_the_label(args));

      /* ------------------------------------------------------------ */
      // Internal Constructors
      /* ------------------------------------------------------------ */

      internal ActInstance() { }

      /* ------------------------------------------------------------ */
      // Private Methods
      /* ------------------------------------------------------------ */

      private TheLabelHasBeenCreated.AssertsInstance Create_the_label(The_UI_creates_a_label args)
      {
         var system = FakeSystem.Create(args);
         return new(FakeLabel.Create(LabelContext.Create(Label.Factory())),
                    system);
      }

      /* ------------------------------------------------------------ */
   }
}