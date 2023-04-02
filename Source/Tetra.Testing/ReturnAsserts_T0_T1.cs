using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tetra.Testing;

public sealed class ReturnAsserts<T, TNext> : AAA_test.IAsserts
   where TNext : AAA_test.IAsserts
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static ReturnAsserts<T, TNext> Create(string      description,
                                                T           error,
                                                Func<TNext> next)
      => new(description,
             error,
             next);

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public TNext The_return_value_was(T expected)
   {
      Assert.That
            .AreEqual(_description,
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

   private ReturnAsserts(string      description,
                         T           actual,
                         Func<TNext> next)
   {
      _description = description;
      _actual      = actual;
      _next        = next;
   }

   /* ------------------------------------------------------------ */
}