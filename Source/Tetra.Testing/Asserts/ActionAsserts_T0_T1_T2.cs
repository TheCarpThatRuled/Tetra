using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tetra.Testing;

public sealed class ActionAsserts<T0, T1, TNext>
   where TNext : IAsserts
{
   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly FakeAction<T0, T1> _actual;
   private readonly string             _description;
   private readonly Func<TNext>        _next;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private ActionAsserts
   (
      FakeAction<T0, T1> actual,
      string             description,
      Func<TNext>        next
   )
   {
      _actual      = actual;
      _description = description;
      _next        = next;
   }
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static ActionAsserts<T0, T1, TNext> Create
   (
      string             description,
      FakeAction<T0, T1> actual,
      Func<TNext>        next
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