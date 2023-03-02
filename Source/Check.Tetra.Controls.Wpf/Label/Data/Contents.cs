using Tetra;

namespace Check.Label;

internal static class Contents
{
   /* ------------------------------------------------------------ */
   // Constants
   /* ------------------------------------------------------------ */

   public static readonly ISequence<object> RepresentativeContents = Sequence.From("This is an art attack",
                                                                                   new object(),
                                                                                   "This... is an art attack",
                                                                                   1,
                                                                                   2,
                                                                                   "THIS IS art attack");

   /* ------------------------------------------------------------ */
}