// ReSharper disable InconsistentNaming

using Tetra;
using static Tetra.Testing.AAA_test<Check.Actions, Check.Asserts>;

namespace Check;

partial class Steps
{
   public sealed class TheClient
   {
      /* ------------------------------------------------------------ */
      // Internal Constructors
      /* ------------------------------------------------------------ */

      internal TheClient() { }

      /* ------------------------------------------------------------ */
      // Actions
      /* ------------------------------------------------------------ */

      public IAction Checks_that_a_directory_does_not_exist
      (
         AbsoluteDirectoryPath path
      )
         => AtomicAction
           .Create($"{nameof(the_client)}.{nameof(Checks_that_a_directory_does_not_exist)}: {path}",
                   environment => environment.DoesNotExist(path));

      /* ------------------------------------------------------------ */

      public IAction Checks_that_a_directory_exists
      (
         AbsoluteDirectoryPath path
      )
         => AtomicAction
           .Create($"{nameof(the_client)}.{nameof(Checks_that_a_directory_exists)}: {path}",
                   environment => environment.Exists(path));

      /* ------------------------------------------------------------ */

      public IAction Checks_that_a_file_does_not_exist
      (
         AbsoluteFilePath path
      )
         => AtomicAction
           .Create($"{nameof(the_client)}.{nameof(Checks_that_a_file_does_not_exist)}: {path}",
                   environment => environment.DoesNotExist(path));

      /* ------------------------------------------------------------ */

      public IAction Checks_that_a_file_exists
      (
         AbsoluteFilePath path
      )
         => AtomicAction
           .Create($"{nameof(the_client)}.{nameof(Checks_that_a_file_exists)}: {path}",
                   environment => environment.Exists(path));

      /* ------------------------------------------------------------ */

      public IAction Creates_a_directory
      (
         AbsoluteDirectoryPath path
      )
         => AtomicAction
           .Create($"{nameof(the_client)}.{nameof(Creates_a_directory)}: {path}",
                   environment => environment.Create(path));

      /* ------------------------------------------------------------ */

      public IAction Gets_the_current_directory()
         => AtomicAction
           .Create($"{nameof(the_client)}.{nameof(Gets_the_current_directory)}",
                   environment => environment.GetCurrentDirectory());

      /* ------------------------------------------------------------ */

      public IAction Sets_the_current_directory
      (
         AbsoluteDirectoryPath path
      )
         => AtomicAction
           .Create($"{nameof(the_client)}.{nameof(Sets_the_current_directory)}: {path}",
                   environment => environment.SetCurrentDirectory(path));

      /* ------------------------------------------------------------ */
   }
}