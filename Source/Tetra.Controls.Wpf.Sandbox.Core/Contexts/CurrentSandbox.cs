namespace Tetra;

internal sealed class CurrentSandbox
{
   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly Action<ISandboxContext> _changeTo;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private CurrentSandbox
   (
      Action<ISandboxContext> changeTo
   )
      => _changeTo = changeTo;
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static CurrentSandbox Create
   (
      Action<ISandboxContext> changeTo
   )
      => new(changeTo);

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public void ChangeToNoSandbox()
      => _changeTo(NoSandboxContext.Create());

   /* ------------------------------------------------------------ */

   public void ChangeToTheButtonSandbox()
      => _changeTo(ButtonSandboxContext.Create(ButtonSandbox.Create()));

   /* ------------------------------------------------------------ */
}