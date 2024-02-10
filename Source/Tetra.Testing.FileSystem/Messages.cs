namespace Tetra.Testing;

internal static class Messages
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Message DirectoryNotFound
   (
      AbsoluteDirectoryPath path
   )
      => Message
        .Create($@"System.IO.DirectoryNotFoundException: Could not find a part of the path '{path.Value()}'");

   /* ------------------------------------------------------------ */
}