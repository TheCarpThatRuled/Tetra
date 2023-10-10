namespace Tetra;

// ReSharper disable once InconsistentNaming
public static class Func_Extensions
{
   /* ------------------------------------------------------------ */
   // Extensions
   /* ------------------------------------------------------------ */

   public static Func<T1> Apply<T0, T1>
   (
      this Func<T0, T1> func,
      T0                arg0
   )
   {
      T1 Func()
         => func(arg0);

      return Func;
   }

   /* ------------------------------------------------------------ */

   public static Func<T1, T2> Apply<T0, T1, T2>
   (
      this Func<T0, T1, T2> func,
      T0                    arg0
   )
   {
      T2 Func
      (
         T1 arg1
      )
         => func(arg0,
                 arg1);

      return Func;
   }

   /* ------------------------------------------------------------ */

   public static Func<TIn, TOut> Then<TIn, TIntermediate, TOut>
   (
      this Func<TIn, TIntermediate> first,
      Func<TIntermediate, TOut>     second
   )
   {
      TOut Func
      (
         TIn @in
      )
         => second(first(@in));

      return Func;
   }

   /* ------------------------------------------------------------ */

   public static Func<TIn, TOut> Then<TIn, TOut>
   (
      this Func<TIn, TOut> first,
      Action<TOut>         second
   )
   {
      TOut Func
      (
         TIn @in
      )
      {
         var @out = first(@in);
         second(@out);
         return @out;
      }

      return Func;
   }

   /* ------------------------------------------------------------ */
}