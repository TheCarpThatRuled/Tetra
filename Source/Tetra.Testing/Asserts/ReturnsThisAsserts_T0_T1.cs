using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tetra.Testing;

public sealed class ReturnsThisAsserts<TNext> : IAsserts
   where TNext : IAsserts
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static ReturnsThisAsserts<TNext> Create(object?     source,
                                                  object?     returnValue,
                                                  Func<TNext> next)
      => new(next,
             returnValue,
             source);

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public TNext AreEqual()
   {
      Assert.That
            .AreEqual("Return Value",
                      _source,
                      _returnValue);

      return _next();
   }

   /* ------------------------------------------------------------ */

   public TNext AreReferenceEqual()
   {
      Assert.That
            .AreReferenceEqual("Return Value",
                               _source,
                               _returnValue);

      return _next();
   }

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly Func<TNext> _next;
   private readonly object?     _returnValue;
   private readonly object?     _source;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private ReturnsThisAsserts(Func<TNext> next,
                              object?     returnValue,
                              object?     source)
   {
      _next        = next;
      _returnValue = returnValue;
      _source      = source;
   }

   /* ------------------------------------------------------------ */
}