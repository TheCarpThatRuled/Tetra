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
   // Extensions
   /* ------------------------------------------------------------ */

   public static IOneWayBinding<TNew> Map<T, TNew>(this IOneWayBinding<T> source,
                                                   Func<T, TNew>          mapFrom)
      => OneWayMapBinding<T, TNew>
        .Create(source,
                mapFrom);

   /* ------------------------------------------------------------ */

   public static ITwoWayBinding<TNew> Map<T, TNew>(this ITwoWayBinding<T> source,
                                                   Func<T, TNew>          mapFrom,
                                                   Func<TNew, T>          mapTo)
      => null;

   /* ------------------------------------------------------------ */
}