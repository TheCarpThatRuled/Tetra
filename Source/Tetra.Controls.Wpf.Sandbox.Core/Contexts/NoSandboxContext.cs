namespace Tetra;

public sealed class NoSandboxContext : DataContext,
                                       ISandboxContext
{
   /* ------------------------------------------------------------ */
   // Internal Factory Functions
   /* ------------------------------------------------------------ */

   internal static NoSandboxContext Create()
      => new();

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private NoSandboxContext() { }

   /* ------------------------------------------------------------ */
}