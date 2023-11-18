using System.Windows;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tetra.Testing;

public sealed class TextBoxAsserts<T> : IAsserts
{
   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly FakeTextBox _actual;
   private readonly string      _descriptionHeader;
   private readonly Func<T>     _next;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private TextBoxAsserts
   (
      FakeTextBox actual,
      string      descriptionHeader,
      Func<T>     next
   )
   {
      _actual            = actual;
      _descriptionHeader = descriptionHeader;
      _next              = next;
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

   public TextBoxAsserts<T> EnabledEquals
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

   public T Next()
      => _next();

   /* ------------------------------------------------------------ */
}