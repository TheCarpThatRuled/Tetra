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
}