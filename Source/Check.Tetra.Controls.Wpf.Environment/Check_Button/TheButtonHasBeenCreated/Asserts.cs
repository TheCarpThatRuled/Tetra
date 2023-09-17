using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra.Testing;

// ReSharper disable InconsistentNaming

namespace Check.Check_Button;

public sealed partial class TheButtonHasBeenCreated
{
   public sealed class Asserts :IAsserts
   {
      /* ------------------------------------------------------------ */
      // Properties
      /* ------------------------------------------------------------ */

      public ButtonAsserts<Asserts> The_button
         => new("System under test",
                _button,
                this);

      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public Asserts The_Click_callback_was_invoked(uint numberOfClicks)
      {
         Assert.That
               .WasInvoked("On Click",
                           _system.OnClick(),
                           (int) numberOfClicks);

         return this;
      }

      /* ------------------------------------------------------------ */
      // Internal Constructors
      /* ------------------------------------------------------------ */

      internal Asserts(FakeButton button,
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