using System.Windows;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tetra.Testing;

public sealed class TextBoxAssertsInstance<T>
{
   /* ------------------------------------------------------------ */
   // Constructors
   /* ------------------------------------------------------------ */

   public TextBoxAssertsInstance(string      descriptionHeader,
                                 FakeTextBox textBox,
                                 T           parent)
   {
      _textBox           = textBox;
      _descriptionHeader = descriptionHeader;
      _parent            = parent;
   }

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public TextBoxAssertsInstance<T> IsEnabled_is(bool expected)
   {
      Assert.That
            .AreEqual($"{_descriptionHeader}: IsEnabled",
                      expected,
                      _textBox.IsEnabled());

      return this;
   }

   /* ------------------------------------------------------------ */

   public TextBoxAssertsInstance<T> Text_is(object expected)
   {
      Assert.That
            .AreEqual($"{_descriptionHeader}: Text",
                      expected,
                      _textBox.Text());

      return this;
   }

   /* ------------------------------------------------------------ */

   public TextBoxAssertsInstance<T> Visibility_is(Visibility expected)
   {
      Assert.That
            .AreEqual($"{_descriptionHeader}: Visibility",
                      expected,
                      _textBox.Visibility());

      return this;
   }

   /* ------------------------------------------------------------ */
   public T ReturnToParent()
      => _parent;

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly FakeTextBox _textBox;
   private readonly string      _descriptionHeader;
   private readonly T           _parent;

   /* ------------------------------------------------------------ */
}