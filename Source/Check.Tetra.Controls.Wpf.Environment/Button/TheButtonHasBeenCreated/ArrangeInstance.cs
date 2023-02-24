using Tetra.Testing;

// ReSharper disable InconsistentNaming

namespace Check;

public sealed partial class TheButtonHasBeenCreated
{
   public sealed class ArrangeInstance : IArrangeInstance<ActInstance>
   {
      /* ------------------------------------------------------------ */
      // IArrangeInstance<ActInstance> Methods
      /* ------------------------------------------------------------ */

      public ActInstance WHEN()
         => new(_fakeButton);

      /* ------------------------------------------------------------ */
      // Internal Constructors
      /* ------------------------------------------------------------ */

      internal ArrangeInstance(FakeButton fakeButton)
         => _fakeButton = fakeButton;

      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly FakeButton _fakeButton;

      /* ------------------------------------------------------------ */
   }
}