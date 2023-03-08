namespace Tetra;

internal sealed class OuterPushBinding<T> : ITwoWayBinding<T>
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static OuterPushBinding<T> Create(ITwoWayBinding<T> source,
                                            Action<T>         onOuterPush)
      => new(onOuterPush,
             source);

   /* ------------------------------------------------------------ */
   // IOneWayBinding<T> Methods
   /* ------------------------------------------------------------ */

   public void OnUpdated(Action onUpdated)
   {
      _onUpdated = onUpdated;
      _source.OnUpdated(onUpdated);
   }

   /* ------------------------------------------------------------ */

   public T Pull()
      => _source
        .Pull();

   /* ------------------------------------------------------------ */
   // ITwoWayBinding<T> Methods
   /* ------------------------------------------------------------ */

   public void Push(T value)
   {
      _source.PushWithoutUpdate(value,
                                _onUpdated);
      _onOuterPush(value);
   }

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly Action<T>         _onOuterPush;
   private readonly ITwoWayBinding<T> _source;

   //Mutable
   private Action _onUpdated = Function.NoOp;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private OuterPushBinding(Action<T>         onOuterPush,
                            ITwoWayBinding<T> source)
   {
      _onOuterPush = onOuterPush;
      _source      = source;
   }

   /* ------------------------------------------------------------ */
}