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

   public static string IsNotAValidComponent(string component,
                                             string componentType)
      => $"'{component.ToLiteral()}' is not a valid {componentType}; a component may not contain any of the following characters: {InvalidPathComponentCharacters}";

   /* ------------------------------------------------------------ */

   public static string IsNotAValidVolumeLabel(char   volume,
                                               string volumeType)
      => $"'{volume.ToLiteral()}' is not a valid {volumeType}; a volume label must be an ASCII letter";

   /* ------------------------------------------------------------ */

   public static string IsNotAValidVolumeRootedPathBecauseMayNotBeEmpty(string path,
                                                                        string pathType)
      => $"'{path.ToLiteral()}' is not a valid {pathType}; a volume-rooted path may not be the empty string";

   /* ------------------------------------------------------------ */

   public static string IsNotAValidVolumeRootedPathBecauseMayNotContainTheCharacters(string path,
                                                                                     string pathType)
      => $"'{path.ToLiteral()}' is not a valid {pathType}; a volume-rooted path may not contain a component that contains any of the following characters: {InvalidPathComponentCharacters}";

   /* ------------------------------------------------------------ */

   public static string IsNotAValidVolumeRootedPathBecauseMayNotEndWithADirectorySeparator(string path,
                                                                                           string pathType)
      => $"'{path.ToLiteral()}' is not a valid {pathType}; a volume-rooted path may not end with a directory separator";

   /* ------------------------------------------------------------ */

   public static string IsNotAValidVolumeRootedPathBecauseMustStartWithAVolumeLabel(string path,
                                                                                    string pathType)
      => $"'{path.ToLiteral()}' is not a valid {pathType}; a volume-rooted path must start with a volume label";

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
}