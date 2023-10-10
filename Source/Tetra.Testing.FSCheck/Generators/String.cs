using FsCheck;

namespace Tetra.Testing;

partial class Generators
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Gen<NonEmptyString> NonEmptyString()
      => Arb.Default
            .NonEmptyString()
            .Generator;

   /* ------------------------------------------------------------ */

   public static Gen<string> NonNullString()
      => NonNull(String());

   /* ------------------------------------------------------------ */

   public static Gen<NonEmptyString> NonNullOrEmptyString()
      => NonNull(NonEmptyString());

   /* ------------------------------------------------------------ */

   public static Gen<string> String()
      => Arb.Default
            .String()
            .Generator;

   /* ------------------------------------------------------------ */

   public static Gen<string> TwoOrMoreAsciiLetters()
      => ArrayOf(AsciiLetter())
        .Where(chars => chars.Length > 1)
        .Select(chars => new string(chars));

   /* ------------------------------------------------------------ */
}