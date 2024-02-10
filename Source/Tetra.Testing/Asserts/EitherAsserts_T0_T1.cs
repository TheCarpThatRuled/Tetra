using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tetra.Testing;

public sealed class EitherAsserts<TLeft, TRight, TNext>
{
   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly IEither<TLeft, TRight> _actual;
   private readonly string                 _description;
   private readonly Func<TNext>            _next;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private EitherAsserts
   (
      IEither<TLeft, TRight> actual,
      string                 description,
      Func<TNext>            next
   )
   {
      _actual      = actual;
      _description = description;
      _next        = next;
   }

   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static EitherAsserts<TLeft, TRight, TNext> Create
   (
      string                 description,
      IEither<TLeft, TRight> actual,
      Func<TNext>            next
   )
      => new(actual,
             description,
             next);

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public TNext IsALeft
   (
      TLeft expected
   )
   {
      Assert
        .That
        .IsALeft(_description,
                 expected,
                 _actual);

      return _next();
   }

   /* ------------------------------------------------------------ */

   public TNext IsARight
   (
      TRight expected
   )
   {
      Assert
        .That
        .IsARight(_description,
                  expected,
                  _actual);

      return _next();
   }

   /* ------------------------------------------------------------ */

   public TNext IsEqualTo
   (
      object? expected
   )
   {
      Assert.That
            .AreEqual(_description,
                      expected,
                      _actual);

      return _next();
   }

   /* ------------------------------------------------------------ */

   public TNext IsReferenceEqualTo
   (
      object? expected
   )
   {
      Assert.That
            .AreReferenceEqual(_description,
                               expected,
                               _actual);

      return _next();
   }

   /* ------------------------------------------------------------ */
}