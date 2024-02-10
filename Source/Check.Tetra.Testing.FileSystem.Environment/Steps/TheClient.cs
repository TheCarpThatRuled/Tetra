// ReSharper disable InconsistentNaming

using Tetra;
using Tetra.Testing;
using static Tetra.Testing.AAA_property_test<Check.Actions, Check.Asserts>;
using static Tetra.Testing.AAA_property_test;

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
      // Givens
      /* ------------------------------------------------------------ */

      public IInitialAction has_not_created_the_file_system()
         => AtomicInitialAction
           .Create($"{nameof(the_client)}.{nameof(has_not_created_the_file_system)}",
                   (
                      _,
                      disposables
                   ) => Actions.Create(disposables));

      /* ------------------------------------------------------------ */

      public IInitialAction has_created_the_file_system
      (
         Parameter<AbsoluteDirectoryPath> currentDirectory
      )
         => has_not_created_the_file_system()
           .And(creates_the_file_system(currentDirectory))
           .Recharacterise($"{nameof(the_client)}.{nameof(has_created_the_file_system)}: {currentDirectory}");

      /* ------------------------------------------------------------ */

      public IInitialAction has_created_the_directory
      (
         Parameter<AbsoluteDirectoryPath> currentDirectory,
         Parameter<AbsoluteDirectoryPath> path
      )
         => has_created_the_file_system(currentDirectory)
           .And(creates_a_directory(path))
           .Recharacterise($"{nameof(the_client)}.{nameof(has_created_the_directory)}: {path}");

      /* ------------------------------------------------------------ */

      public IInitialAction has_configured_setting_the_current_directory_to_fail
      (
         Parameter<AbsoluteDirectoryPath> currentDirectory,
         Parameter<Message> error
      )
         => has_created_the_file_system(currentDirectory)
           .And(configures_setting_the_current_directory_to_fail(error))
           .Recharacterise($"{nameof(the_client)}.{nameof(has_configured_setting_the_current_directory_to_fail)}: {error}");

      /* ------------------------------------------------------------ */

      public IInitialAction has_configured_setting_the_current_directory_to_succeed
      (
         Parameter<AbsoluteDirectoryPath> currentDirectory
      )
         => has_created_the_file_system(currentDirectory)
           .And(configures_setting_the_current_directory_to_succeed())
           .Recharacterise($"{nameof(the_client)}.{nameof(has_configured_setting_the_current_directory_to_succeed)}");

      /* ------------------------------------------------------------ */
      // Actions
      /* ------------------------------------------------------------ */

      public IAction creates_the_file_system
      (
         Parameter<AbsoluteDirectoryPath> currentDirectory
      )
         => AtomicAction
           .Create($"{nameof(the_client)}.{nameof(creates_the_file_system)}: {currentDirectory}",
                   (
                      parameters,
                      environment
                   ) => environment.CreateFileSystem(parameters.Retrieve(currentDirectory)));

      /* ------------------------------------------------------------ * /

      public IAction Checks_that_a_directory_does_not_exist
      (
         AbsoluteDirectoryPath path
      )
         => AtomicAction
           .Create($"{nameof(the_client)}.{nameof(Checks_that_a_directory_does_not_exist)}: {path}",
                   (_, environment) => environment.DoesNotExist(path));

      /* ------------------------------------------------------------ */

      public IAction checks_that_a_directory_exists
      (
         Parameter<AbsoluteDirectoryPath> path
      )
         => AtomicAction
           .Create($"{nameof(the_client)}.{nameof(checks_that_a_directory_exists)}: {path}",
                   (
                      parameters,
                      environment
                   ) => environment.Exists(parameters.Retrieve(path)));

      /* ------------------------------------------------------------ * /

      public IAction Checks_that_a_file_does_not_exist
      (
         AbsoluteFilePath path
      )
         => AtomicAction
           .Create($"{nameof(the_client)}.{nameof(Checks_that_a_file_does_not_exist)}: {path}",
                   (_, environment) => environment.DoesNotExist(path));

      /* ------------------------------------------------------------ * /

      public IAction Checks_that_a_file_exists
      (
         AbsoluteFilePath path
      )
         => AtomicAction
           .Create($"{nameof(the_client)}.{nameof(Checks_that_a_file_exists)}: {path}",
                   (_, environment) => environment.Exists(path));

      /* ------------------------------------------------------------ */

      public IAction configures_setting_the_current_directory_to_fail
      (
         Parameter<Message> errorMessage
      )
         => AtomicAction
           .Create($"{nameof(the_client)}.{nameof(configures_setting_the_current_directory_to_fail)}: {errorMessage}",
                   (
                      parameters,
                      environment
                   ) => environment
                       .TestFileSystem
                       .SettingTheCurrentDirectoryShallFail(parameters.Retrieve(errorMessage))
                       .Next());

      /* ------------------------------------------------------------ */

      public IAction configures_setting_the_current_directory_to_succeed
      (
      )
         => AtomicAction
           .Create($"{nameof(the_client)}.{nameof(configures_setting_the_current_directory_to_succeed)}",
                   (
                      _,
                      environment
                   ) => environment
                       .TestFileSystem
                       .SettingTheCurrentDirectoryShallSucceed()
                       .Next());

      /* ------------------------------------------------------------ */

      public IAction creates_a_directory
      (
         Parameter<AbsoluteDirectoryPath> path
      )
         => AtomicAction
           .Create($"{nameof(the_client)}.{nameof(creates_a_directory)}: {path}",
                   (
                      parameters,
                      environment
                   ) => environment.Create(parameters.Retrieve(path)));

      /* ------------------------------------------------------------ * /

      public IAction Gets_the_current_directory()
         => AtomicAction
           .Create($"{nameof(the_client)}.{nameof(Gets_the_current_directory)}",
                   (_, environment) => environment.GetCurrentDirectory());

      /* ------------------------------------------------------------ */

      public IAction sets_the_current_directory
      (
         Parameter<AbsoluteDirectoryPath> path
      )
         => AtomicAction
           .Create($"{nameof(the_client)}.{nameof(sets_the_current_directory)}: {path}",
                   (
                      parameters,
                      environment
                   ) => environment.SetCurrentDirectory(parameters.Retrieve(path)));

      /* ------------------------------------------------------------ */
   }
}