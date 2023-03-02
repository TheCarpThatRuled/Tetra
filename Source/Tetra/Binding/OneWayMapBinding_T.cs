namespace Tetra;

internal sealed class OneWayMapBinding<T, TNew> : IOneWayBinding<TNew>
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static OneWayMapBinding<T, TNew> Create(IOneWayBinding<T> innerBinding,
                                                  Func<T, TNew>     mapFrom)
      => new(innerBinding,
             mapFrom);

   /* ------------------------------------------------------------ */
   // IOneWayBinding<TNew> Methods
   /* ------------------------------------------------------------ */

   public void OnUpdated(Action onUpdated)
      => _innerBinding
        .OnUpdated(onUpdated);

   /* ------------------------------------------------------------ */

   public TNew Pull()
      => _mapFrom(_innerBinding.Pull());

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly IOneWayBinding<T> _innerBinding;
   private readonly Func<T, TNew>     _mapFrom;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private OneWayMapBinding(IOneWayBinding<T> innerBinding,
                            Func<T, TNew>     mapFrom)
   {
      _innerBinding = innerBinding;
      _mapFrom      = mapFrom;
   }

   /* ------------------------------------------------------------ */
}