using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tetra.Testing;

public sealed class ActionAsserts<TNext>
   where TNext : IAsserts
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static ActionAsserts<TNext> Create(string      description,
                                             FakeAction  actual,
                                             Func<TNext> next)
      => new(actual,
             description,
             next);

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

   private readonly FakeAction  _actual;
   private readonly string      _description;
   private readonly Func<TNext> _next;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private ActionAsserts(FakeAction  actual,
                         string      description,
                         Func<TNext> next)
   {
      _actual      = actual;
      _description = description;
      _next        = next;
   }

   /* ------------------------------------------------------------ */
}