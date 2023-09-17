using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tetra.Testing;

public sealed class OptionAsserts<T, TNext> : IAsserts
   where TNext : IAsserts
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static OptionAsserts<T, TNext> Create(string      description,
                                                IOption<T>  actual,
                                                Func<TNext> next)
      => new(description,
             actual,
             next);

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public TNext IsANone()
   {
      Assert
        .That
        .IsANone("Return Value",
                 _actual);

      return _next();
   }

   /* ------------------------------------------------------------ */

   public TNext IsASome(T expected)
   {
      Assert
        .That
        .IsASome("Return Value",
                 expected,
                 _actual);

      return _next();
   }

   /* ------------------------------------------------------------ */

   public TNext IsReferenceEqualTo(T expected)
   {
      Assert.That
            .AreReferenceEqual(_description,
                               expected,
                               _actual);

      return _next();
   }

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly string      _description;
   private readonly IOption<T>  _actual;
   private readonly Func<TNext> _next;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private OptionAsserts(string      description,
                         IOption<T>  actual,
                         Func<TNext> next)
   {
      _description = description;
      _actual      = actual;
      _next        = next;
   }

   /* ------------------------------------------------------------ */
}