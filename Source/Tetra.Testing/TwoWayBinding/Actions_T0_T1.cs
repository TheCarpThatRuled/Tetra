namespace Tetra.Testing;

public sealed class TwoWayBindingActions<T, TNext> : Chainable<TNext>
{
   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly ITwoWayBinding<T> _actual;
   private readonly string            _description;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private TwoWayBindingActions
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

   public static TwoWayBindingActions<T, TNext> Create
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

   public TwoWayBindingActions<T, TNext> Push
   (
      T value
   )
   {
      _actual.Push(value);

      return this;
   }

   /* ------------------------------------------------------------ */
}