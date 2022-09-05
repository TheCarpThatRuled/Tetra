using System.Globalization;

namespace Tetra;

// ReSharper disable once InconsistentNaming
public static class Char_Extensions
{
   /* ------------------------------------------------------------ */
   // Extensions
   /* ------------------------------------------------------------ */

   public static bool IsAnAsciiLetter(this char character)
      => char.IsAscii(character)
      && char.IsLetter(character);

   /* ------------------------------------------------------------ */

   public static bool IsNotAnAsciiLetter(this char character)
      => !character.IsAnAsciiLetter();

   /* ------------------------------------------------------------ */

   public static string ToLiteral(this char character)
      => character switch
         {
            '\"' => @"\""",
            '\\' => @"\\",
            '\0' => @"\0",
            '\a' => @"\a",
            '\b' => @"\b",
            '\f' => @"\f",
            '\n' => @"\n",
            '\r' => @"\r",
            '\t' => @"\t",
            '\v' => @"\v",
            _    => character.ToLiteralControlCharacters(),
         };

/* ------------------------------------------------------------ */

   public static string ToLiteralControlCharacters(this char character)
      => char.GetUnicodeCategory(character) == UnicodeCategory.Control
            ? $@"\u{(int) character:x4}"
            : character.ToString();

   /* ------------------------------------------------------------ */
}