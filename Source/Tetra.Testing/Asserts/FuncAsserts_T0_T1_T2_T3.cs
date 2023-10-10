using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tetra.Testing;

public sealed class FuncAsserts<T0, T1, TReturn, TNext>
   where TNext : IAsserts
{
   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly FakeFunction<T0, T1, TReturn> _actual;
   private readonly string                        _description;
   private readonly Func<TNext>                   _next;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private FuncAsserts
   (
      FakeFunction<T0, T1, TReturn> actual,
      string                        description,
      Func<TNext>                   next
   )
   {
      _actual      = actual;
      _description = description;
      _next        = next;
   }
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static FuncAsserts<T0, T1, TReturn, TNext> Create
   (
      string                        description,
      FakeFunction<T0, T1, TReturn> actual,
      Func<TNext>                   next
   )
      => new(actual,
             description,
             next);

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public TNext WasInvokedOnce
   (
      T0 expectedArg0,
      T1 expectedArg1
   )
   {
      Assert
        .That
        .WasInvokedOnce(_description,
                        expectedArg0,
                        expectedArg1,
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
}