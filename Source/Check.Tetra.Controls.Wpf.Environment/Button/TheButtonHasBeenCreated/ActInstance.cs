using Tetra.Testing;

namespace Check;

public sealed partial class TheButtonHasBeenCreated
{
   public sealed class ActInstance : IActInstance
   {
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      /* ------------------------------------------------------------ */
      // Internal Constructors
      /* ------------------------------------------------------------ */

      internal ActInstance(FakeButton fakeButton)
         => _fakeButton = fakeButton;

      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly FakeButton _fakeButton;

      /* ------------------------------------------------------------ */
   }
}