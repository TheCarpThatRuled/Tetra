using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tetra.Testing;

public sealed class BooleanAsserts<TNext> : IAsserts
   where TNext : IAsserts
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static BooleanAsserts<TNext> Create(string      description,
                                              bool        returnValue,
                                              Func<TNext> next)
      => new(description,
             next,
             returnValue);

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public TNext IsFalse()
   {
      Assert.That
            .IsFalse(_description,
                     _returnValue);

      return _next();
   }

   /* ------------------------------------------------------------ */

   public TNext IsTrue()
   {
      Assert.That
            .IsTrue(_description,
                    _returnValue);

      return _next();
   }

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly string      _description;
   private readonly Func<TNext> _next;
   private readonly bool        _returnValue;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private BooleanAsserts(string      description,
                          Func<TNext> next,
                          bool        returnValue)
   {
      _description = description;
      _next        = next;
      _returnValue = returnValue;
   }

   /* ------------------------------------------------------------ */
}