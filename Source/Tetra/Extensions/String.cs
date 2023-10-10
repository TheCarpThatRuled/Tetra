using System.Text;

namespace Tetra;

// ReSharper disable once InconsistentNaming
public static class String_Extensions
{
   /* ------------------------------------------------------------ */
   // Extensions
   /* ------------------------------------------------------------ */

   public static bool IsAValidPathComponent
   (
      this string value
   )
      => !value.IsNotAValidPathComponent();

   /* ------------------------------------------------------------ */

   public static bool IsAValidVolumeLabel
   (
      this string value
   )
      => !value.IsNotAValidVolumeLabel();

   /* ------------------------------------------------------------ */

   public static bool IsNotAValidPathComponent
   (
      this string value
   )
      => value
        .Any(character => Path
                         .GetInvalidFileNameChars()
                         .Contains(character));

   /* ------------------------------------------------------------ */

   public static bool IsNotAValidVolumeLabel
   (
      this string value
   )
      => string.IsNullOrEmpty(value)
      || value.Length != 2
      || value[0]
           .IsNotAnAsciiLetter()
      || value[1] != ':';

   /* ------------------------------------------------------------ */

   public static string ToLiteral
   (
      this string value
   )
   {
      var literal = new StringBuilder();

      foreach (var character in value)
      {
         literal.Append(character.ToLiteral());
      }

      return literal.ToString();
   }

   /* ------------------------------------------------------------ */
}