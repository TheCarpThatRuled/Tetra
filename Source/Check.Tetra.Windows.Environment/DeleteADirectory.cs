namespace Check;

internal class DeleteADirectory : IDisposable
{
   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly string _directory;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private DeleteADirectory
   (
      string directory
   )
      => _directory = directory;

   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static DeleteADirectory Create
   (
      string directory
   )
      => new(directory);

   /* ------------------------------------------------------------ */
   // IDisposable Methods
   /* ------------------------------------------------------------ */

   public void Dispose()
      => ExternalFileSystem
        .EnsureADirectoryDoesNotExists(_directory);

   /* ------------------------------------------------------------ */
}