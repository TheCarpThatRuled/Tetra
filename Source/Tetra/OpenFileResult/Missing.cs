namespace Tetra;

public sealed class Missing
{
   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly Message          _message;
   private readonly AbsoluteFilePath _path;

   /* ------------------------------------------------------------ */
   // Internal Constructors
   /* ------------------------------------------------------------ */

   internal Missing
   (
      Message          message,
      AbsoluteFilePath path
   )
   {
      _message = message;
      _path    = path;
   }
   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   /// <summary>
   ///    A message describing the error.
   /// </summary>
   public Message Message()
      => _message;

   /* ------------------------------------------------------------ */

   /// <summary>
   ///    The path of the missing file.
   /// </summary>
   public AbsoluteFilePath Path()
      => _path;

   /* ------------------------------------------------------------ */
}