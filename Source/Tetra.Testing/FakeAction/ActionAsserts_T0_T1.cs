using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tetra.Testing;

public sealed class ActionAsserts<T, TNext>
{
   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly FakeAction<T> _actual;
   private readonly string        _description;
   private readonly Func<TNext>   _next;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private ActionAsserts
   (
      FakeAction<T> actual,
      string        description,
      Func<TNext>   next
   )
   {
      _actual      = actual;
      _description = description;
      _next        = next;
   }
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static ActionAsserts<T, TNext> Create
   (
      string        description,
      FakeAction<T> actual,
      Func<TNext>   next
   )
      => new(actual,
             description,
             next);

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public TNext WasInvokedOnce
   (
      T expected
   )
   {
      Assert
        .That
        .WasInvokedOnce(_description,
                        expected,
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