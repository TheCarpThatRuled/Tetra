using FsCheck;

namespace Tetra.Testing;

partial class Generators
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Gen<char> Char()
      => Arb
        .Default
        .Char()
        .Generator;

   /* ------------------------------------------------------------ */

   public static Gen<char> AsciiLetter()
      => Gen
        .Elements(Characters.AsciiLetters);

   /* ------------------------------------------------------------ */

   public static Gen<char> NonAsciiLetter()
      => Char()
        .Where(x => !(char.IsAscii(x)
                   && char.IsLetter(x)));

   /* ------------------------------------------------------------ */
}