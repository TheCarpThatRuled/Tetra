namespace Tetra;

internal sealed class Binding<T> : ITwoWayBinding<T>
{
   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private Action _onUpdated = Function.NoOp;

   private T _value;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private Binding
   (
      T value
   )
      => _value = value;

   /* ------------------------------------------------------------ */
   // IOneWayBinding<T> Methods
   /* ------------------------------------------------------------ */

   public void OnUpdated
   (
      Action onUpdated
   )
      => _onUpdated = onUpdated;

   /* ------------------------------------------------------------ */

   public T Pull()
      => _value;

   /* ------------------------------------------------------------ */
   // ITwoWayBinding<T> Methods
   /* ------------------------------------------------------------ */

   public void Push
   (
      T value
   )
   {
      _value = value;

      _onUpdated();
   }
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static Binding<T> Create
   (
      T initialValue
   )
      => new(initialValue);

   /* ------------------------------------------------------------ */
}