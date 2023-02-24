namespace Tetra;

// ReSharper disable once InconsistentNaming
public static class Characterisation_Extension
{
   /* ------------------------------------------------------------ */
   // Extensions
   /* ------------------------------------------------------------ */

   public static string Brief(this Characterisation characterisation)
      => IndentingStringBuilder
        .Create()
        .AppendBrief(characterisation)
        .ToString();

   /* ------------------------------------------------------------ */

   public static string Full(this Characterisation characterisation)
      => IndentingStringBuilder
        .Create()
        .AppendFull(characterisation)
        .ToString();

   /* ------------------------------------------------------------ */
}