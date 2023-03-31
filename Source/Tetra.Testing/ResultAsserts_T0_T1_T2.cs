using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tetra.Testing;

public sealed class ResultAsserts<TSuccess, TFailure, TAsserts> : IAsserts
   where TAsserts : IAsserts
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static ResultAsserts<TSuccess, TFailure, TAsserts> Create(string                      description,
                                                                    IResult<TSuccess, TFailure> result,
                                                                    Func<TAsserts>              next)
      => new(description,
             result,
             next);

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public TAsserts The_returned_value_was_not_in_error(TSuccess expected)
   {
      Assert.That
            .IsASuccess(_description,
                        expected,
                        _result);

      return _next();
   }

   /* ------------------------------------------------------------ */

   public TAsserts The_returned_value_was_in_error(TFailure expected)
   {
      Assert.That
            .IsAFailure(_description,
                        expected,
                        _result);

      return _next();
   }

   /* ------------------------------------------------------------ */

   public TAsserts The_returned_value_was_in_error(Func<TFailure, bool> predicate)
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

   private readonly string                      _description;
   private readonly IResult<TSuccess, TFailure> _result;
   private readonly Func<TAsserts>              _next;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private ResultAsserts(string                      description,
                         IResult<TSuccess, TFailure> result,
                         Func<TAsserts>              next)
   {
      _description = description;
      _result      = result;
      _next        = next;
   }

   /* ------------------------------------------------------------ */
}