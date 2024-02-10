using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tetra.Testing;

public sealed class OptionAsserts<T, TNext> : IAsserts
{
   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly IOption<T>  _actual;
   private readonly string      _description;
   private readonly Func<TNext> _next;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private OptionAsserts
   (
      IOption<T>  actual,
      string      description,
      Func<TNext> next
   )
   {
      _actual      = actual;
      _description = description;
      _next        = next;
   }

   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static OptionAsserts<T, TNext> Create
   (
      string      description,
      IOption<T>  actual,
      Func<TNext> next
   )
      => new(actual,
             description,
             next);

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public TNext IsANone()
   {
      Assert
        .That
        .IsANone(_description,
                 _actual);

      return _next();
   }

   /* ------------------------------------------------------------ */

   public TNext IsASome
   (
      T expected
   )
   {
      Assert
        .That
        .IsASome(_description,
                 expected,
                 _actual);

      return _next();
   }

   /* ------------------------------------------------------------ */

   public TNext IsASomeAnd
   (
      Func<T, bool> predicate
   )
   {
      Assert
        .That
        .IsASomeAnd(_description,
                    predicate,
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