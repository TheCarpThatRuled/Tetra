using System.Text;

namespace Check;

internal static partial class Messages
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static string ArgumentExceptionMessage(string message,
                                                 string parameterName)
      => $"{message} (Parameter '{parameterName}')";

   /* ------------------------------------------------------------ */

   public static string IsNotValidBecauseAnAbsoluteFilePathMayNotEndWithADirectorySeparator(string path,
                                                                                            string pathType)
      => $"'{path.ToLiteral()}' is not a valid {pathType}; an absolute file path may not end with a directory separator";

   /* ------------------------------------------------------------ */

   public static string IsNotValidBecauseAnAbsolutePathMayNotBeEmpty(string path,
                                                                     string pathType)
      => $"'{path.ToLiteral()}' is not a valid {pathType}; an absolute path may not be the empty string";

   /* ------------------------------------------------------------ */

   public static string IsNotValidBecauseAnAbsolutePathMayNotContainTheCharacters(string path,
                                                                                  string pathType)
      => $"'{path.ToLiteral()}' is not a valid {pathType}; an absolute path may not contain a component that contains any of the following characters: {InvalidPathComponentCharacters}";

   /* ------------------------------------------------------------ */

   public static string IsNotValidBecauseAnAbsolutePathMustStartWithAVolumeLabel(string path,
                                                                                 string pathType)
      => $"'{path.ToLiteral()}' is not a valid {pathType}; an absolute path must start with a volume label";

   /* ------------------------------------------------------------ */

   public static string IsNotValidBecauseAComponentMayNotContainTheCharacters(string component,
                                                                              string componentType)
      => $"'{component.ToLiteral()}' is not a valid {componentType}; a component may not contain any of the following characters: {InvalidPathComponentCharacters}";

   /* ------------------------------------------------------------ */

   public static string IsNotValidBecauseARelativeFilePathMayNotEndWithADirectorySeparator(string path,
                                                                                            string pathType)
      => $"'{path.ToLiteral()}' is not a valid {pathType}; a relative file path may not end with a directory separator";

   /* ------------------------------------------------------------ */

   public static string IsNotValidBecauseARelativePathMayNotBeEmpty(string path,
                                                                     string pathType)
      => $"'{path.ToLiteral()}' is not a valid {pathType}; a relative path may not be the empty string";

   /* ------------------------------------------------------------ */

   public static string IsNotValidBecauseARelativePathMayNotContainTheCharacters(string path,
                                                                                  string pathType)
      => $"'{path.ToLiteral()}' is not a valid {pathType}; a relative path may not contain a component that contains any of the following characters: {InvalidPathComponentCharacters}";

   /* ------------------------------------------------------------ */

   public static string IsNotValidBecauseAVolumeLabelMustBeAnASCIILetter(char   volume,
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