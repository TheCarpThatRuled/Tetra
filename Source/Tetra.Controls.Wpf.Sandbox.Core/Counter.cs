namespace Tetra;

internal sealed class Count
//internal sealed class Counter<T> where T : INumber<T> //Just wait til .Net 7!
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static Count Create(int initialCount)
      => new(initialCount);

   /* ------------------------------------------------------------ */

   public static Count FromZero()
      => Create(0);

   /* ------------------------------------------------------------ */
   // Properties
   /* ------------------------------------------------------------ */

   public int Value()
      => _value;

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public Count Decrement()
   {
      --_value;

      return this;
   }

   /* ------------------------------------------------------------ */

   public Count Increment()
   {
      ++_value;

      return this;
   }

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private int _value;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private Count(int initialCount)
      => _value = initialCount;

   /* ------------------------------------------------------------ */
}