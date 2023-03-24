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

   public static readonly AbsoluteDirectoryPath Path_to_the_test_sandbox
      = PathToTheTestExecutionDirectory
        .Append(DirectoryComponent.Create("Sandbox"));

   /* ------------------------------------------------------------ */
}