using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tetra.Testing;

public sealed class BooleanAsserts<TNext> : IAsserts
   where TNext : IAsserts
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static BooleanAsserts<TNext> Create(string      description,
                                              bool        actual,
                                              Func<TNext> next)
      => new(actual,
             description,
             next);

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public TNext IsFalse()
   {
      Assert.That
            .IsFalse(_description,
                     _actual);

      return _next();
   }

   /* ------------------------------------------------------------ */

   public TNext IsTrue()
   {
      Assert.That
            .IsTrue(_description,
                    _actual);

      return _next();
   }

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly bool        _actual;
   private readonly string      _description;
   private readonly Func<TNext> _next;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private BooleanAsserts(bool        actual,
                          string      description,
                          Func<TNext> next)
   {
      _actual      = actual;
      _description = description;
      _next        = next;
   }

   /* ------------------------------------------------------------ */
}