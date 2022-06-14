using System.Text;

namespace Tetra;

public static class TetraMessages
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Message CastFailed<TFrom, TTo>()
      => Message
        .Create($"Could not cast an instance of {typeof(TFrom).FullName} to {typeof(TTo).FullName}");

   /* ------------------------------------------------------------ */

   public static string IsNotAValidDirectoryComponent(string component)
      => $"'{component.ToLiteral()}' is not a valid directory component; a directory component may not contain any of the following characters: {InvalidPathComponentCharacters}";

   /* ------------------------------------------------------------ */

   public static string IsNotAValidFileComponent(string component)
      => $"'{component.ToLiteral()}' is not a valid file component; a file component may not contain any of the following characters: {InvalidPathComponentCharacters}";

   /* ------------------------------------------------------------ */

   public static string IsNotAValidVolumeLabel(char volume)
      => $"'{volume.ToLiteral()}' is not a valid volume label; a volume label must be an ASCII letter";

   /* ------------------------------------------------------------ */
   // Constants
   /* ------------------------------------------------------------ */

   private static readonly string InvalidPathComponentCharacters;

   /* ------------------------------------------------------------ */
   // Static Constructor
   /* ------------------------------------------------------------ */

   static TetraMessages()
   {
      var invalidPathComponentCharacters = new StringBuilder();
      var invalidFileNameChars = Path
                                .GetInvalidFileNameChars()
                                .Select(x => x.ToLiteralControlCharacters())
                                .ToArray();

      invalidPathComponentCharacters.Append($"'{invalidFileNameChars[0]}'");

      foreach (var invalidChar in invalidFileNameChars)
      {
         invalidPathComponentCharacters.Append($", '{invalidChar}'");
      }

      InvalidPathComponentCharacters = invalidPathComponentCharacters.ToString();
   }

   /* ------------------------------------------------------------ */

   /* ------------------------------------------------------------ */
}