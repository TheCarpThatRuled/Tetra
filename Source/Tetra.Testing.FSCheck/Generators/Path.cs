using FsCheck;

namespace Tetra.Testing;

partial class Generators
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Gen<string> InvalidPathComponent()
      => Gen
        .Zip(ValidOrEmptyPathComponent(),
             InvalidPathComponentCharacter(),
             ValidOrEmptyPathComponent())
        .Select(x => x.Item1 + x.Item2 + x.Item3);

   /* ------------------------------------------------------------ */

   public static Gen<char> InvalidPathComponentCharacter()
      => Gen
        .Elements(Path.GetInvalidFileNameChars());

   /* ------------------------------------------------------------ */

   public static Gen<string> ValidOrEmptyPathComponent()
      => NonNullString()
        .Where(path => path.All(character => !Path
                                             .GetInvalidFileNameChars()
                                             .Contains(character)));

   /* ------------------------------------------------------------ */

   public static Gen<string> ValidPathComponent()
      => NonNullOrEmptyString()
        .Select(x => x.Get)
        .Where(path => path.All(character => !Path
                                             .GetInvalidFileNameChars()
                                             .Contains(character)));

   /* ------------------------------------------------------------ */

   public static Gen<char> ValidPathComponentCharacter()
      => Char()
        .Where(character => !Path
                            .GetInvalidFileNameChars()
                            .Contains(character));

   /* ------------------------------------------------------------ */
}