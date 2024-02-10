// ReSharper disable InconsistentNaming

using static Tetra.Testing.AAA_test<Check.Actions,Check.Asserts>;

namespace Check;

partial class Steps
{
   public sealed class ADirectory
   {
      /* ------------------------------------------------------------ */
      // Internal Constructors
      /* ------------------------------------------------------------ */

      internal ADirectory() { }

      /* ------------------------------------------------------------ */
      // Actions
      /* ------------------------------------------------------------ */

      public IAction Does_not_exists
      (
         string path
      )
         => AtomicAction
           .Create($"{nameof(a_directory)}.{nameof(Does_not_exists)}: <{path}>",
                   environment => environment
                                 .SystemIoApi
                                 .EnsureADirectoryDoesNotExists(path)
                                 .Next());

      /* ------------------------------------------------------------ */

      public IAction Exists
      (
         string path
      )
         => AtomicAction
           .Create($"{nameof(a_directory)}.{nameof(Exists)}: <{path}>",
                   environment => environment
                                 .SystemIoApi
                                 .EnsureADirectoryExists(path)
                                 .Next());

      /* ------------------------------------------------------------ */
   }
}