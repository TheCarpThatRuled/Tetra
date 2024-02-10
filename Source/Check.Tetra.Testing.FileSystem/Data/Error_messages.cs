// ReSharper disable InconsistentNaming

using Tetra;
using static Tetra.Testing.AAA_property_test;

namespace Check;

internal static class Error_messages
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static string Partial_cannot_create_exception
   (
      string path
   )
      => $@"System.IO.IOException: Cannot create '{path}' because a file or directory with the same name already exists.";

   /* ------------------------------------------------------------ */

   public static string Partial_directory_name_is_invalid_exception
   (
      string path
   )
      => $@"System.IO.IOException: The directory name is invalid. : '{path}'";

   /* ------------------------------------------------------------ */

   public static string Partial_DirectoryNotFound_exception
   (
      AbsoluteDirectoryPath path
   )
      => $@"System.IO.DirectoryNotFoundException: Could not find a part of the path '{path.Value()}'";

   /* ------------------------------------------------------------ */

   public static Func<Parameters, string> Partial_DirectoryNotFound_exception
   (
      Parameter<AbsoluteDirectoryPath> path
   )
      => parameters => Partial_DirectoryNotFound_exception(parameters.Retrieve(path));

   /* ------------------------------------------------------------ */
}