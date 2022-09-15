namespace Tetra;

public sealed class Locked
{
   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   /// <summary>
   /// A message describing the error.
   /// </summary>
   public Message Message()
      => _message;

   /* ------------------------------------------------------------ */

   /// <summary>
   /// The path of the locked file.
   /// </summary>
   public AbsoluteFilePath Path()
      => _path;

   /* ------------------------------------------------------------ */
   // Internal Constructors
   /* ------------------------------------------------------------ */

   internal Locked(Message          message,
                   AbsoluteFilePath path)
   {
      _message = message;
      _path    = path;
   }

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly Message          _message;
   private readonly AbsoluteFilePath _path;

   /* ------------------------------------------------------------ */
}