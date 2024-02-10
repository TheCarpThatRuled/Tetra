using System.Windows;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tetra.Testing;

public sealed class ButtonAsserts<T> : Chainable<T>
{
   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly FakeButton _actual;
   private readonly string     _descriptionHeader;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private ButtonAsserts
   (
      FakeButton actual,
      string     descriptionHeader,
      Func<T>    next
   ) : base(next)
   {
      _actual            = actual;
      _descriptionHeader = descriptionHeader;
   }

   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static ButtonAsserts<T> Create
   (
      string     descriptionHeader,
      FakeButton actual,
      Func<T>    next
   )
      => new(actual,
             descriptionHeader,
             next);

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public ButtonAsserts<T> IsEnabledEquals
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

   public ButtonAsserts<T> VisibilityEquals
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