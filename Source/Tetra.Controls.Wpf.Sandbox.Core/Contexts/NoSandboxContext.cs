namespace Tetra;

public sealed class NoSandboxContext : DataContext,
                                       ISandboxContext
{
   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private NoSandboxContext() { }
   /* ------------------------------------------------------------ */
   // Internal Factory Functions
   /* ------------------------------------------------------------ */

   internal static NoSandboxContext Create()
      => new();

   /* ------------------------------------------------------------ */
}