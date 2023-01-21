namespace Tetra;

partial class DataContext
{
   protected sealed class Binding<T>
   {
      /* ------------------------------------------------------------ */
      // Properties
      /* ------------------------------------------------------------ */

      public T Pull()
         => _value;

      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public void Push(T value)
      {
         _value = value;
         _onPush();
      }

      /* ------------------------------------------------------------ */

      public void Set(T value)
         => _value = value;

      /* ------------------------------------------------------------ */
      // Internal Factory Functions
      /* ------------------------------------------------------------ */

      internal static Binding<T> Create(T      initialValue,
                                        Action onPush)
         => new(onPush,
                initialValue);

      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly Action _onPush;

      //Mutable
      private T _value;

      /* ------------------------------------------------------------ */
      // Private Constructors
      /* ------------------------------------------------------------ */

      private Binding(Action onPush,
                      T      value)
      {
         _onPush = onPush;
         _value  = value;
      }

      /* ------------------------------------------------------------ */
   }
}