using Tetra;
using Tetra.Testing;

namespace Check;

public sealed partial class TheButtonHasNotBeenCreated
{
   public sealed class ActInstance : IActInstance
   {
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public ActInstance<TheButtonHasBeenCreated.AssertsInstance> The_UI_developer_creates_the_button(The_UI_creates_a_button args)
         => new(()=> CreateTheButton(args));

      /* ------------------------------------------------------------ */
      // Internal Constructors
      /* ------------------------------------------------------------ */

      internal ActInstance() { }

      /* ------------------------------------------------------------ */
      // Private Methods
      /* ------------------------------------------------------------ */

      private TheButtonHasBeenCreated.AssertsInstance CreateTheButton(The_UI_creates_a_button args)
         => new(FakeButton.Create(ButtonContext.Create(Button.Factory())));

      /* ------------------------------------------------------------ */
   }
}