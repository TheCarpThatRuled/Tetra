using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tetra.Testing;

public sealed class ActionAsserts<TNext>
   where TNext : IAsserts
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static ActionAsserts<TNext> Create(string      description,
                                             FakeAction  whenNone,
                                             Func<TNext> next)
      => new(description,
             next,
             whenNone);

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public TNext WasInvokedOnce()
   {
      Assert
        .That
        .WasInvokedOnce(_description,
                        _whenNone);

      return _next();
   }

   /* ------------------------------------------------------------ */

   public TNext WasNotInvoked()
   {
      Assert
        .That
        .WasNotInvoked(_description,
                       _whenNone);

      return _next();
   }

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly string      _description;
   private readonly Func<TNext> _next;
   private readonly FakeAction  _whenNone;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private ActionAsserts(string      description,
                         Func<TNext> next,
                         FakeAction  whenNone)
   {
      _description = description;
      _next        = next;
      _whenNone    = whenNone;
   }

   /* ------------------------------------------------------------ */
}