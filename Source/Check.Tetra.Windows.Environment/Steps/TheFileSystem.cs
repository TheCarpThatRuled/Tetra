// ReSharper disable InconsistentNaming
using static Tetra.Testing.AAA_test<Check.Actions, Check.Asserts>;

namespace Check;

partial class Steps
{
   public sealed class TheFileSystem
   {
      /* ------------------------------------------------------------ */
      // Internal Constructors
      /* ------------------------------------------------------------ */

      internal TheFileSystem() { }

      /* ------------------------------------------------------------ */
      // Actions
      /* ------------------------------------------------------------ */

      public IAction Creates_a_sandbox
      (
         string directory
      )
         => AtomicAction
           .Create($"{nameof(the_file_system)}.{nameof(Creates_a_sandbox)}: <{directory}>",
                   environment => environment
                                 .ExternalFileSystem
                                 .CreateSandbox(directory)
                                 .ReturnToParent());

      /* ------------------------------------------------------------ */
      // Asserts
      /* ------------------------------------------------------------ */

      public IAssert Contains_a_directory
      (
         string expected
      )
         => AtomicAssert
           .Create($"{nameof(the_file_system)}.{nameof(Contains_a_directory)}: <{expected}>",
                   environment => environment.ADirectoryExists(expected));

      /* ------------------------------------------------------------ */

      public IAssert Contains_a_file
      (
         string expected
      )
         => AtomicAssert
           .Create($"{nameof(the_file_system)}.{nameof(Contains_a_file)}: <{expected}>",
                   environment => environment.AFileExists(expected));

      /* ------------------------------------------------------------ */

      public IAssert Does_not_contains_a_directory
      (
         string expected
      )
         => AtomicAssert
           .Create($"{nameof(the_file_system)}.{nameof(Does_not_contains_a_directory)}: <{expected}>",
                   environment => environment.ADirectoryDoesNotExist(expected));

      /* ------------------------------------------------------------ */

      public IAssert Does_not_contains_a_file
      (
         string expected
      )
         => AtomicAssert
           .Create($"{nameof(the_file_system)}.{nameof(Does_not_contains_a_file)}: <{expected}>",
                   environment => environment.AFileDoesNotExist(expected));

      /* ------------------------------------------------------------ */

      public IAssert Has_a_current_directory_of
      (
         string expected
      )
         => AtomicAssert
           .Create($"{nameof(the_file_system)}.{nameof(Has_a_current_directory_of)}: <{expected}>",
                   environment => environment.TheCurrentDirectoryIs(expected));

      /* ------------------------------------------------------------ */
   }
}