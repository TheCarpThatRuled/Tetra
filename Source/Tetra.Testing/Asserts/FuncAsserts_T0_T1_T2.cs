using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tetra.Testing;

public sealed class FuncAsserts<T, TReturn, TNext>
   where TNext : IAsserts
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static FuncAsserts<T, TReturn, TNext> Create(string                   description,
                                                       FakeFunction<T, TReturn> function,
                                                       Func<TNext>              next)
      => new(description,
             next,
             function);

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public TNext WasInvokedOnce(T expected)
   {
      Assert
        .That
        .WasInvokedOnce(_description,
                        expected,
                        _function);

      return _next();
   }

   /* ------------------------------------------------------------ */

   public TNext WasNotInvoked()
   {
      Assert
        .That
        .WasNotInvoked(_description,
                       _function);

      return _next();
   }

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly string                   _description;
   private readonly Func<TNext>              _next;
   private readonly FakeFunction<T, TReturn> _function;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private FuncAsserts(string                   description,
                       Func<TNext>              next,
                       FakeFunction<T, TReturn> function)
   {
      _description = description;
      _next        = next;
      _function    = function;
   }

   /* ------------------------------------------------------------ */
}