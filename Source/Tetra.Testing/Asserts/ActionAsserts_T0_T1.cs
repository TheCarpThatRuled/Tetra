using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tetra.Testing;

public sealed class ActionAsserts<T, TNext>
   where TNext : IAsserts
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static ActionAsserts<T, TNext> Create(string        description,
                                                FakeAction<T> action,
                                                Func<TNext>   next)
      => new(description,
             next,
             action);

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public TNext WasInvokedOnce(T expected)
   {
      Assert
        .That
        .WasInvokedOnce(_description,
                        expected,
                        _action);

      return _next();
   }

   /* ------------------------------------------------------------ */

   public TNext WasNotInvoked()
   {
      Assert
        .That
        .WasNotInvoked(_description,
                       _action);

      return _next();
   }

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly string        _description;
   private readonly Func<TNext>   _next;
   private readonly FakeAction<T> _action;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private ActionAsserts(string        description,
                         Func<TNext>   next,
                         FakeAction<T> action)
   {
      _description = description;
      _next        = next;
      _action      = action;
   }

   /* ------------------------------------------------------------ */
}