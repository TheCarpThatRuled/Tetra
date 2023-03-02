using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra.Testing;

// ReSharper disable InconsistentNaming

namespace Check.Check_Button;

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
      // Methods
      /* ------------------------------------------------------------ */

      public AssertsInstance The_Click_callback_was_invoked()
      {
         Assert.That
               .WasInvokedOnce("On Click",
                               _system.OnClick());

         return this;
      }

      /* ------------------------------------------------------------ */
      // Internal Constructors
      /* ------------------------------------------------------------ */

      internal AssertsInstance(FakeButton button,
                               FakeSystem system)
      {
         _button = button;
         _system = system;
      }

      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly FakeButton _button;
      private readonly FakeSystem _system;

      /* ------------------------------------------------------------ */
   }
}