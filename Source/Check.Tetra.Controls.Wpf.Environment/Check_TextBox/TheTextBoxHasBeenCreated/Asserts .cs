using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra.Testing;

// ReSharper disable InconsistentNaming

namespace Check.Check_TextBox;

public sealed partial class TheTextBoxHasBeenCreated
{
   public sealed class Asserts : AAA_test.IAsserts
   {
      /* ------------------------------------------------------------ */
      // Properties
      /* ------------------------------------------------------------ */

      public TextBoxAsserts<Asserts> The_text_box
         => new("System under test",
                _text_box,
                this);

      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public Asserts The_system_Text_is(string expected)
      {
         Assert.That
               .AreEqual($"{nameof(_system)}{nameof(_system.Text)}",
                         expected,
                         _system.Text()
                                .Pull());


         return this;
      }

      /* ------------------------------------------------------------ */
      // Internal Constructors
      /* ------------------------------------------------------------ */

      internal Asserts(FakeTextBox text_box,
                       FakeSystem  system)
      {
         _text_box = text_box;
         _system   = system;
      }

      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly FakeTextBox _text_box;
      private readonly FakeSystem  _system;

      /* ------------------------------------------------------------ */
   }
}