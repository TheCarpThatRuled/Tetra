using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tetra.Testing;

public sealed class TwoWayBindingAsserts<T, TNext> : Chainable<TNext>
{
   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly ITwoWayBinding<T> _actual;
   private readonly string            _description;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private TwoWayBindingAsserts
   (
      ITwoWayBinding<T> actual,
      string            description,
      Func<TNext>       next
   ) : base(next)
   {
      _actual      = actual;
      _description = description;
   }

   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static TwoWayBindingAsserts<T, TNext> Create
   (
      string            description,
      ITwoWayBinding<T> actual,
      Func<TNext>       next
   )
      => new(actual,
             description,
             next);

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public TwoWayBindingAsserts<T, TNext> Contains
   (
      T expected
   )
   {
      Assert.That
            .AreEqual(_description,
                      expected,
                      _actual.Pull());

      return this;
   }

   /* ------------------------------------------------------------ */
}