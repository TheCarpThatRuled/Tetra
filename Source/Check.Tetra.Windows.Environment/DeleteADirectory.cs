namespace Check;

internal class DeleteADirectory : IDisposable
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static DeleteADirectory Create(string directory)
      => new(directory);

   /* ------------------------------------------------------------ */
   // IDisposable Methods
   /* ------------------------------------------------------------ */

   public void Dispose()
      => ExternalFileSystem
        .EnsureADirectoryDoesNotExists(_directory);

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly string _directory;

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private DeleteADirectory(string directory)
      => _directory = directory;

   /* ------------------------------------------------------------ */
}