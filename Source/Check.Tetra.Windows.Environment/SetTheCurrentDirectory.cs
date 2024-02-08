namespace Check;

internal class SetTheCurrentDirectory : IDisposable
{
   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly string _directory;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private SetTheCurrentDirectory
   (
      string directory
   )
      => _directory = directory;

   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static SetTheCurrentDirectory Create
   (
      string directory
   )
      => new(directory);

   /* ------------------------------------------------------------ */
   // IDisposable Methods
   /* ------------------------------------------------------------ */

   public void Dispose()
      => ExternalFileSystem
        .SetCurrentDirectory(_directory);

   /* ------------------------------------------------------------ */
}