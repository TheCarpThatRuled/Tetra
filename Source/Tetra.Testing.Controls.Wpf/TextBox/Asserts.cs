using System.Windows;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tetra.Testing;

public sealed class TextBoxAsserts<T> : Chainable<T>
{
   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly FakeTextBox _actual;
   private readonly string      _descriptionHeader;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private TextBoxAsserts
   (
      FakeTextBox actual,
      string      descriptionHeader,
      Func<T>     next
   ) : base(next)
   {
      _actual            = actual;
      _descriptionHeader = descriptionHeader;
   }

   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static TextBoxAsserts<T> Create
   (
      string      descriptionHeader,
      FakeTextBox actual,
      Func<T>     next
   )
      => new(actual,
             descriptionHeader,
             next);

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public TextBoxAsserts<T> IsEnabledEquals
   (
      bool expected
   )
   {
      Assert.That
            .AreEqual($"{_descriptionHeader}: IsEnabled",
                      expected,
                      _actual.IsEnabled());

      return this;
   }

   /* ------------------------------------------------------------ */

   public TextBoxAsserts<T> TextEquals
   (
      object expected
   )
   {
      Assert.That
            .AreEqual($"{_descriptionHeader}: Text",
                      expected,
                      _actual.Text());

      return this;
   }

   /* ------------------------------------------------------------ */

   public TextBoxAsserts<T> VisibilityEquals
   (
      Visibility expected
   )
   {
      Assert.That
            .AreEqual($"{_descriptionHeader}: Visibility",
                      expected,
                      _actual.Visibility());

      return this;
   }

   /* ------------------------------------------------------------ */
}