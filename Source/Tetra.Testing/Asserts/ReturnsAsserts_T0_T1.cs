using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tetra.Testing;

public sealed class ReturnsAsserts<T, TNext> : IAsserts
   where TNext : IAsserts
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static ReturnsAsserts<T, TNext> Create(string      description,
                                                T           error,
                                                Func<TNext> next)
      => new(description,
             error,
             next);

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public TNext IsEqualTo(T expected)
   {
      Assert.That
            .AreEqual(_description,
                      expected,
                      _actual);

      return _next();
   }

   /* ------------------------------------------------------------ */

   public TNext IsReferenceEqualTo(T expected)
   {
      Assert.That
            .AreReferenceEqual(_description,
                               expected,
                               _actual);

      return _next();
   }

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly string      _description;
   private readonly T           _actual;
   private readonly Func<TNext> _next;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private ReturnsAsserts(string      description,
                         T           actual,
                         Func<TNext> next)
   {
      _description = description;
      _actual      = actual;
      _next        = next;
   }

   /* ------------------------------------------------------------ */
}