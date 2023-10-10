namespace Tetra;

internal sealed class InvariantBinding<T> : IOneWayBinding<T>
{
   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly T _value;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private InvariantBinding
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
   ) { }

   /* ------------------------------------------------------------ */

   public T Pull()
      => _value;
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static InvariantBinding<T> Create
   (
      T initialValue
   )
      => new(initialValue);

   /* ------------------------------------------------------------ */
}