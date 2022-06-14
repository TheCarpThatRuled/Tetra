using FsCheck;

namespace Tetra.Testing;

partial class Generators
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Gen<NonEmptyString> NonEmptyString()
      => Arb
        .Default
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
      => Arb
        .Default
        .String()
        .Generator;

   /* ------------------------------------------------------------ */
}