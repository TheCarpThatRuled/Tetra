using Tetra;
using static Tetra.Testing.AAA_property_test;

namespace Check;

internal static class Predicate
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Func<Message, bool> Contains_the_text
   (
      string expected
   )
      => message => message
                   .Content()
                   .Contains(expected);

   /* ------------------------------------------------------------ */

   public static Func<Parameters, Func<Message, bool>> Contains_the_text
   (
      Func<Parameters, string> expected
   )
      => parameters => Contains_the_text(expected(parameters));

   /* ------------------------------------------------------------ */
}