namespace Check;

internal static class Predicate
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Func<Message, bool> Contains_the_text(string expected)
      => message => message
                   .Content()
                   .Contains(expected);

   /* ------------------------------------------------------------ */
}