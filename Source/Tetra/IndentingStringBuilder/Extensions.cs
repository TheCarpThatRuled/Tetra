namespace Tetra;

// ReSharper disable once InconsistentNaming
public static class IndentingStringBuilder_Extension
{
   /* ------------------------------------------------------------ */
   // Extensions
   /* ------------------------------------------------------------ */

   public static IndentingStringBuilder AppendBrief(this IndentingStringBuilder builder,
                                                    Characterisation            characterisation)
      => characterisation
        .AppendBrief(builder);

   /* ------------------------------------------------------------ */

   public static IndentingStringBuilder AppendFull(this IndentingStringBuilder builder,
                                                   Characterisation            characterisation)
      => characterisation
        .AppendFull(builder);

   /* ------------------------------------------------------------ */
}