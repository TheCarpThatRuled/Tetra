namespace Tetra;

// ReSharper disable once InconsistentNaming
public static class Action_Extensions
{
   /* ------------------------------------------------------------ */
   // Extensions
   /* ------------------------------------------------------------ */

   public static Action Then
   (
      this Action first,
      Action      second
   )
      => () =>
      {
         first();
         second();
      };

   /* ------------------------------------------------------------ */

   public static Action<T> Then<T>
   (
      this Action first,
      Action<T>   second
   )
      => @in =>
      {
         first();
         second(@in);
      };

   /* ------------------------------------------------------------ */

   public static Action<T> Then<T>
   (
      this Action<T> first,
      Action         second
   )
      => @in =>
      {
         first(@in);
         second();
      };

   /* ------------------------------------------------------------ */

   public static Action<T> Then<T>
   (
      this Action<T> first,
      Action<T>      second
   )
      => @in =>
      {
         first(@in);
         second(@in);
      };

   /* ------------------------------------------------------------ */
}