using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tetra.Testing;

public sealed class ReturnsThisAsserts<TNext>
{
   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly object?     _actual;
   private readonly object?     _expected;
   private readonly Func<TNext> _next;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private ReturnsThisAsserts
   (
      object?     actual,
      object?     expected,
      Func<TNext> next
   )
   {
      _actual   = actual;
      _expected = expected;
      _next     = next;
   }

   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static ReturnsThisAsserts<TNext> Create
   (
      object?     expected,
      object?     actual,
      Func<TNext> next
   )
      => new(actual,
             expected,
             next);

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public TNext AreEqual()
   {
      Assert.That
            .AreEqual("Return Value",
                      _expected,
                      _actual);

      return _next();
   }

   /* ------------------------------------------------------------ */

   public TNext AreReferenceEqual()
   {
      Assert.That
            .AreReferenceEqual("Return Value",
                               _expected,
                               _actual);

      return _next();
   }

   /* ------------------------------------------------------------ */
}