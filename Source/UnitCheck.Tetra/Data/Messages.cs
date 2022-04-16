using Tetra;

namespace Check.Data;

internal static class Messages
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Message CastFailed<TFrom, TTo>()
      => Message
        .Create($"Could not cast an instance of {typeof(TFrom).FullName} to {typeof(TTo).FullName}");

   /* ------------------------------------------------------------ */
}