using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tetra.Testing;

public sealed class ObjectAsserts<T, TNext>
{
   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly T           _actual;
   private readonly string      _description;
   private readonly Func<TNext> _next;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private ObjectAsserts
   (
      T           actual,
      string      description,
      Func<TNext> next
   )
   {
      _actual      = actual;
      _description = description;
      _next        = next;
   }

   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static ObjectAsserts<T, TNext> Create
   (
      string      description,
      T           actual,
      Func<TNext> next
   )
      => new(actual,
             description,
             next);

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public TNext IsEqualTo
   (
      T expected
   )
   {
      Assert.That
            .AreEqual(_description,
                      expected,
                      _actual);

      return _next();
   }

   /* ------------------------------------------------------------ */

   public TNext IsReferenceEqualTo
   (
      T expected
   )
   {
      Assert.That
            .AreReferenceEqual(_description,
                               expected,
                               _actual);

      return _next();
   }

   /* ------------------------------------------------------------ */
}