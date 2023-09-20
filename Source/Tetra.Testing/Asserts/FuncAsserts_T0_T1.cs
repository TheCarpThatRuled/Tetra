using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tetra.Testing;

public sealed class FuncAsserts<TReturn, TNext>
   where TNext : IAsserts
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static FuncAsserts<TReturn, TNext> Create(string                description,
                                                    FakeFunction<TReturn> actual,
                                                    Func<TNext>           next)
      => new(description,
             next,
             actual);

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public TNext WasInvokedOnce()
   {
      Assert
        .That
        .WasInvokedOnce(_description,
                        _actual);

      return _next();
   }

   /* ------------------------------------------------------------ */

   public TNext WasNotInvoked()
   {
      Assert
        .That
        .WasNotInvoked(_description,
                       _actual);

      return _next();
   }

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly FakeFunction<TReturn> _actual;
   private readonly string                _description;
   private readonly Func<TNext>           _next;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private FuncAsserts(string                description,
                       Func<TNext>           next,
                       FakeFunction<TReturn> actual)
   {
      _actual      = actual;
      _description = description;
      _next        = next;
   }

   /* ------------------------------------------------------------ */
}