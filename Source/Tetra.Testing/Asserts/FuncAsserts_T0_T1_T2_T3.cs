using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tetra.Testing;

public sealed class FuncAsserts<T0, T1, TReturn, TNext>
   where TNext : IAsserts
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static FuncAsserts<T0, T1, TReturn, TNext> Create(string                        description,
                                                            FakeFunction<T0, T1, TReturn> function,
                                                            Func<TNext>                   next)
      => new(description,
             next,
             function);

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public TNext WasInvokedOnce(T0 expectedArg0,
                               T1 expectedArg1)
   {
      Assert
        .That
        .WasInvokedOnce(_description,
                        expectedArg0,
                        expectedArg1,
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

   private readonly string                        _description;
   private readonly Func<TNext>                   _next;
   private readonly FakeFunction<T0, T1, TReturn> _function;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private FuncAsserts(string                        description,
                       Func<TNext>                   next,
                       FakeFunction<T0, T1, TReturn> function)
   {
      _description = description;
      _next        = next;
      _function    = function;
   }

   /* ------------------------------------------------------------ */
}