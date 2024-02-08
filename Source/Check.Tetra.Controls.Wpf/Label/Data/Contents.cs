using Tetra;

namespace Check.Label;

internal static class Contents
{
   /* ------------------------------------------------------------ */
   // Constants
   /* ------------------------------------------------------------ */

   public static readonly ISequence<object> Representative_contents = Sequence.From("This is an art attack",
                                                                                    new object(),
                                                                                    "This... is an art attack",
                                                                                    1,
                                                                                    2,
                                                                                    "THIS IS art attack");

   public static readonly object Object = new();

   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static object From
   (
      string content
   )
      => content switch
         {
            "1"      => 1,
            "2"      => 2,
            "object" => Object,
            _        => content,
         };

   /* ------------------------------------------------------------ */
}