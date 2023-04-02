using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tetra.Testing;

public sealed class ResultAsserts<T, TAsserts> : AAA_test.IAsserts
   where TAsserts : AAA_test.IAsserts
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static ResultAsserts<T, TAsserts> Create(string         description,
                                                   IResult<T>     result,
                                                   Func<TAsserts> next)
      => new(description,
             result,
             next);

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public TAsserts The_returned_value_was_not_in_error()
   {
      Assert.That
            .IsASuccess(_description,
                        _result);

      return _next();
   }

   /* ------------------------------------------------------------ */

   public TAsserts The_returned_value_was_in_error(T expected)
   {
      Assert.That
            .IsAFailure(_description,
                        expected,
                        _result);

      return _next();
   }

   /* ------------------------------------------------------------ */

   public TAsserts The_returned_value_was_in_error(Func<T, bool> predicate)
   {
      Assert.That
            .IsAFailureAnd(_description,
                           predicate,
                           _result);

      return _next();
   }

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly string         _description;
   private readonly IResult<T>     _result;
   private readonly Func<TAsserts> _next;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private ResultAsserts(string         description,
                         IResult<T>     result,
                         Func<TAsserts> next)
   {
      _description = description;
      _result      = result;
      _next        = next;
   }

   /* ------------------------------------------------------------ */
}