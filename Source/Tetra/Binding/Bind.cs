namespace Tetra;

public static class Bind
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static ITwoWayBinding<T> To<T>(T initialValue)
      => Binding<T>
        .Create(initialValue);

   /* ------------------------------------------------------------ */
}