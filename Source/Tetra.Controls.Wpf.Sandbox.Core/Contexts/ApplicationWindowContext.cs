namespace Tetra;

public sealed class ApplicationWindowContext : DataContext
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static ApplicationWindowContext Start()
      => new();

   /* ------------------------------------------------------------ */
   // Bindings
   /* ------------------------------------------------------------ */

   public SelectSandboxScreenContext CurrentScreen { get; } = SelectSandboxScreenContext.Create();

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private ApplicationWindowContext() { }

   /* ------------------------------------------------------------ */
}