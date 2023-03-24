using System.Reflection;

namespace Check;

internal static class Constants
{
   /* ------------------------------------------------------------ */
   // Constants
   /* ------------------------------------------------------------ */

   public static readonly AbsoluteDirectoryPath PathToTheTestExecutionDirectory
      = AbsoluteDirectoryPath
        .Create(Directory
               .GetParent(Assembly
                         .GetEntryAssembly()
                          !.Location)
                !.ToString());

   /* ------------------------------------------------------------ */

   public static readonly AbsoluteDirectoryPath PathToTheTestSandbox
      = PathToTheTestExecutionDirectory
        .Append(DirectoryComponent.Create("Sandbox"));

   /* ------------------------------------------------------------ */
}