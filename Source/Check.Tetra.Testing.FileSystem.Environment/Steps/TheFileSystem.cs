// ReSharper disable InconsistentNaming

using Tetra;
using static Tetra.Testing.AAA_property_test<Check.Actions, Check.Asserts>;
using static Tetra.Testing.AAA_property_test;

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
      /* ------------------------------------------------------------ * /

      public IAction Creates_a_sandbox
      (
         string directory
      )
         => AtomicAction
           .Create($"{nameof(the_file_system)}.{nameof(Creates_a_sandbox)}: <{directory}>",
                   (_, environment) => environment
                                      .ExternalFileSystem
                                      .CreateSandbox(directory)
                                      .ReturnToParent());

      /* ------------------------------------------------------------ */
      // Asserts
      /* ------------------------------------------------------------ * /

      public IAssert Contains_a_directory
      (
         string expected
      )
         => AtomicAssert
           .Create($"{nameof(the_file_system)}.{nameof(Contains_a_directory)}: <{expected}>",
                   (_, environment) => environment.ADirectoryExists(expected));

      /* ------------------------------------------------------------ */

      public IAssert contains_a_directory_and_all_its_ancestors
      (
         Parameter<AbsoluteDirectoryPath> expected
      )
         => AtomicAssert
           .Create($"{nameof(the_file_system)}.{nameof(contains_a_directory_and_all_its_ancestors)}: {expected}",
                   (
                      parameters,
                      environment
                   ) => parameters
                       .Retrieve(expected)
                       .Ancestry()
                       .Aggregate(environment,
                                  (
                                     current,
                                     path
                                  ) => current
                                      .FileSystem
                                      .ADirectoryExists(path)
                                      .ExistsAndDoesNotExistsAreInverses(path)
                                      .Next()));

      /* ------------------------------------------------------------ * /

      public IAssert Contains_a_file
      (
         string expected
      )
         => AtomicAssert
           .Create($"{nameof(the_file_system)}.{nameof(Contains_a_file)}: <{expected}>",
                   (_, environment) => environment.AFileExists(expected));

      /* ------------------------------------------------------------ * /

      public IAssert Does_not_contains_a_directory
      (
         string expected
      )
         => AtomicAssert
           .Create($"{nameof(the_file_system)}.{nameof(Does_not_contains_a_directory)}: <{expected}>",
                   (_, environment) => environment.ADirectoryDoesNotExist(expected));

      /* ------------------------------------------------------------ * /

      public IAssert Does_not_contains_a_file
      (
         string expected
      )
         => AtomicAssert
           .Create($"{nameof(the_file_system)}.{nameof(Does_not_contains_a_file)}: <{expected}>",
                   (_, environment) => environment.AFileDoesNotExist(expected));

      /* ------------------------------------------------------------ * /

      public IAssert Has_a_current_directory_of
      (
         string expected
      )
         => AtomicAssert
           .Create($"{nameof(the_file_system)}.{nameof(Has_a_current_directory_of)}: <{expected}>",
                   (_, environment) => environment.TheCurrentDirectoryIs(expected));

      /* ------------------------------------------------------------ */
   }
}