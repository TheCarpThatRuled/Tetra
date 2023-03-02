namespace Tetra;

internal sealed class Binding<T> : ITwoWayBinding<T>
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static Binding<T> Create(T initialValue)
      => new(initialValue);

   /* ------------------------------------------------------------ */
   // IOneWayBinding<T> Methods
   /* ------------------------------------------------------------ */

   public void OnUpdated(Action onUpdated)
      => _onUpdated = onUpdated;

   /* ------------------------------------------------------------ */

   public T Pull()
      => _value;

   /* ------------------------------------------------------------ */
   // ITwoWayBinding<T> Methods
   /* ------------------------------------------------------------ */

   public void Push(T value)
   {
      _value = value;

      _onUpdated();
   }

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private Action _onUpdated = Function.NoOp;

   private T _value;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private Binding(T value)
      => _value = value;

   /* ------------------------------------------------------------ */
}