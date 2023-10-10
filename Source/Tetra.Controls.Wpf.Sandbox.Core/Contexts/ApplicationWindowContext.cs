namespace Tetra;

public sealed class ApplicationWindowContext : DataContext
{
   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private ApplicationWindowContext() { }

   /* ------------------------------------------------------------ */
   // Bindings
   /* ------------------------------------------------------------ */

   public SelectSandboxScreenContext CurrentScreen { get; } = SelectSandboxScreenContext.Create();
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static ApplicationWindowContext Start()
      => new();

   /* ------------------------------------------------------------ */
}