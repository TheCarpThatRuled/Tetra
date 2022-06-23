using System.Text;
using Tetra;

namespace Check;

internal static class Messages
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Message CastFailed<TFrom, TTo>()
      => Message
        .Create($"Could not cast an instance of {typeof(TFrom).FullName} to {typeof(TTo).FullName}");

   /* ------------------------------------------------------------ */

   public static string IsNotAValidComponent(string component,
                                                 string componentType)
      => $"'{component.ToLiteral()}' is not a valid {componentType}; a component may not contain any of the following characters: {InvalidPathComponentCharacters}";

   /* ------------------------------------------------------------ */

   public static string IsNotAValidVolumeLabel(char   volume,
                                               string volumeType)
      => $"'{volume.ToLiteral()}' is not a valid {volumeType}; a volume label must be an ASCII letter";

   /* ------------------------------------------------------------ */
   // Constants
   /* ------------------------------------------------------------ */

   private static readonly string InvalidPathComponentCharacters;

   /* ------------------------------------------------------------ */
   // Static Constructor
   /* ------------------------------------------------------------ */

   static Messages()
   {
      var invalidPathComponentCharacters = new StringBuilder();
      var invalidFileNameChars = Path
                                .GetInvalidFileNameChars()
                                .Select( x=> x.ToLiteralControlCharacters())
                                .ToArray();

      invalidPathComponentCharacters.Append($"'{invalidFileNameChars[0]}'");

      foreach (var invalidChar in invalidFileNameChars)
      {
         invalidPathComponentCharacters.Append($", '{invalidChar}'");
      }

      InvalidPathComponentCharacters = invalidPathComponentCharacters.ToString();
   }

   /* ------------------------------------------------------------ */
}