using System.Windows;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tetra.Testing;

public sealed class ButtonAssertsInstance<T>
{
   /* ------------------------------------------------------------ */
   // Constructors
   /* ------------------------------------------------------------ */

   public ButtonAssertsInstance(string     descriptionHeader,
                                FakeButton button,
                                T          parent)
   {
      _button            = button;
      _descriptionHeader = descriptionHeader;
      _parent            = parent;
   }

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public ButtonAssertsInstance<T> IsEnabled_is(bool expected)
   {
      Assert.That
            .AreEqual($"{_descriptionHeader}: IsEnabled",
                      expected,
                      _button.IsEnabled());

      return this;
   }

   /* ------------------------------------------------------------ */

   public ButtonAssertsInstance<T> Visibility_is(Visibility expected)
   {
      Assert.That
            .AreEqual($"{_descriptionHeader}: Visibility",
                      expected,
                      _button.Visibility());

      return this;
   }

   /* ------------------------------------------------------------ */
   public T ReturnToParent()
      => _parent;

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly FakeButton _button;
   private readonly string     _descriptionHeader;
   private readonly T          _parent;

   /* ------------------------------------------------------------ */
}