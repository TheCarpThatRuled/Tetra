namespace Check;

internal class SetTheCurrentDirectory : IDisposable
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static SetTheCurrentDirectory Create(string directory)
      => new(directory);

   /* ------------------------------------------------------------ */
   // IDisposable Methods
   /* ------------------------------------------------------------ */

   public void Dispose()
      => ExternalFileSystem
        .SetCurrentDirectory(_directory);

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly string _directory;

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private SetTheCurrentDirectory(string directory)
      => _directory = directory;

   /* ------------------------------------------------------------ */
}