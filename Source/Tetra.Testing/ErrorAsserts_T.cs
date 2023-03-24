using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tetra.Testing;

public sealed class ErrorAsserts<T> : IAsserts
   where T : IAsserts
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static ErrorAsserts<T> Create(string  description,
                                        IError  error,
                                        Func<T> next)
      => new(description,
             error,
             next);

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public T The_returned_value_was_not_in_error()
   {
      Assert.That
            .IsANone(_description,
                     _error);

      return _next();
   }

   /* ------------------------------------------------------------ */

   public T The_returned_value_was_in_error(Message expected)
   {
      Assert.That
            .IsASome(_description,
                     expected,
                     _error);

      return _next();
   }

   /* ------------------------------------------------------------ */

   public T The_returned_value_was_in_error(Func<Message, bool> predicate)
   {
      Assert.That
            .IsASomeAnd(_description,
                        predicate,
                        _error);

      return _next();
   }

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly string  _description;
   private readonly IError  _error;
   private readonly Func<T> _next;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private ErrorAsserts(string  description,
                        IError  error,
                        Func<T> next)
   {
      _description = description;
      _error       = error;
      _next        = next;
   }

   /* ------------------------------------------------------------ */
}