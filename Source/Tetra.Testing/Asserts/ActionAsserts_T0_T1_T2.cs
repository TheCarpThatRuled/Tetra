using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tetra.Testing;

public sealed class ActionAsserts<T0, T1, TNext>
   where TNext : IAsserts
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static ActionAsserts<T0, T1, TNext> Create(string             description,
                                                     FakeAction<T0, T1> whenSome,
                                                     Func<TNext>        next)
      => new(description,
             next,
             whenSome);

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
                        _whenSome);

      return _next();
   }

   /* ------------------------------------------------------------ */

   public TNext WasNotInvoked()
   {
      Assert
        .That
        .WasNotInvoked(_description,
                       _whenSome);

      return _next();
   }

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly string             _description;
   private readonly Func<TNext>        _next;
   private readonly FakeAction<T0, T1> _whenSome;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private ActionAsserts(string             description,
                         Func<TNext>        next,
                         FakeAction<T0, T1> whenSome)
   {
      _description = description;
      _next        = next;
      _whenSome    = whenSome;
   }

   /* ------------------------------------------------------------ */
}