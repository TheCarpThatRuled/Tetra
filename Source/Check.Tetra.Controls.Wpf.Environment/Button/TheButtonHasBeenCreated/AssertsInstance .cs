using Tetra.Testing;

// ReSharper disable InconsistentNaming

namespace Check;

public sealed partial class TheButtonHasBeenCreated
{
   public sealed class AssertsInstance : IAssertsInstance
   {
      /* ------------------------------------------------------------ */
      // Properties
      /* ------------------------------------------------------------ */

      public ButtonAssertsInstance<AssertsInstance> The_button
         => new("System under test",
                _button,
                this);

      /* ------------------------------------------------------------ */
      // Internal Constructors
      /* ------------------------------------------------------------ */

      internal AssertsInstance(FakeButton button)
         => _button = button;

      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly FakeButton _button;

      /* ------------------------------------------------------------ */
   }
}