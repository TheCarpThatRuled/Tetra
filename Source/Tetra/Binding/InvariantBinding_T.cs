namespace Tetra;

internal sealed class InvariantBinding<T> : IOneWayBinding<T>
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static InvariantBinding<T> Create(T initialValue)
      => new(initialValue);

   /* ------------------------------------------------------------ */
   // IOneWayBinding<T> Methods
   /* ------------------------------------------------------------ */

   public void OnUpdated(Action onUpdated) { }

   /* ------------------------------------------------------------ */

   public T Pull()
      => _value;

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly T _value;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private InvariantBinding(T value)
      => _value = value;

   /* ------------------------------------------------------------ */
}