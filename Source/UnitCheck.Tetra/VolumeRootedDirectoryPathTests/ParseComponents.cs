using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Check.Messages;
using static Tetra.Testing.Properties;

namespace Check.VolumeRootedDirectoryPathTests;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.VolumeRootedDirectoryPath)]
public class ParseComponents
{
   /* ------------------------------------------------------------ */

   private sealed class TestPath : VolumeRootedDirectoryPath
   {
      /* ------------------------------------------------------------ */
      // Functions
      /* ------------------------------------------------------------ */

      public static Result<(Volume volume, IReadOnlyCollection<DirectoryComponent> directories)> TestParseComponents(string potentialPath,
                                                                                                                     string pathType)
         => ParseComponents(potentialPath,
                            pathType);

      /* ------------------------------------------------------------ */
      // Constructor
      /* ------------------------------------------------------------ */

      private TestPath(IReadOnlyCollection<DirectoryComponent> directories,
                       Volume                                  volume) : base(directories,
                                                                              volume) { }

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */
   // protected Result(Volume volume, IReadOnlyCollection<DirectoryComponent> directories) ParseComponents(string potentialPath,
   //                                                                                                      string pathType)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_valid_volume_rooted_path_with_a_trailing_directory_separator
   //WHEN
   //ParseComponents
   //THEN
   //a_success_containing_VolumeRootedDirectoryPath_with_a_value_of_the_combine_path_is_returned

   [TestMethod]
   public void
      GIVEN_a_valid_volume_rooted_path_with_a_trailing_directory_separator_WHEN_Parse_THEN_a_success_containing_VolumeRootedDirectoryPath_with_a_value_of_the_combine_path_is_returned()
   {
      static Property Property(Volume               volume,
                               DirectoryComponent[] directories)
      {
         //Arrange
         var path = directories
                   .Select(x => x.Value())
                   .Prepend(volume.Value())
                   .ToArray()
                   .ToDelimitedString(Path.DirectorySeparatorChar);

         //Act
         var actual = TestPath.TestParseComponents(path,
                                                   nameof(TestPath));

         //Assert
         return IsASuccessAnd(actualComponents => volume.Equals(actualComponents.Content()
                                                                                .volume)
                                               && directories.SequenceEqual(actualComponents
                                                                           .Content()
                                                                           .directories),
                              actual);
      }

      Arb.Register<Libraries.Volume>();
      Arb.Register<Libraries.ArrayOfDirectoryComponents>();

      Prop.ForAll<Volume, DirectoryComponent[]>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //a_valid_volume_rooted_path_without_a_trailing_directory_separator
   //WHEN
   //ParseComponents
   //THEN
   //a_success_containing_VolumeRootedDirectoryPath_with_a_value_of_the_combine_path_is_returned

   [TestMethod]
   public void
      GIVEN_a_valid_volume_rooted_path_without_a_trailing_directory_separator_WHEN_Parse_THEN_a_success_containing_VolumeRootedDirectoryPath_with_a_value_of_the_combine_path_is_returned()
   {
      static Property Property(Volume               volume,
                               DirectoryComponent[] directories)
      {
         //Arrange
         var path = directories
                   .Select(x => x.Value())
                   .Prepend(volume.Value())
                   .ToArray()
                   .ToDelimitedStringWithTrailingDelimiter(Path.DirectorySeparatorChar);

         //Act
         var actual = TestPath.TestParseComponents(path,
                                                   nameof(TestPath));

         //Assert
         return IsASuccessAnd(actualComponents => volume.Equals(actualComponents.Content()
                                                                                .volume)
                                               && directories.SequenceEqual(actualComponents
                                                                           .Content()
                                                                           .directories),
                              actual);
      }


      Arb.Register<Libraries.Volume>();
      Arb.Register<Libraries.ArrayOfDirectoryComponents>();

      Prop.ForAll<Volume, DirectoryComponent[]>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //the_empty_string
   //WHEN
   //ParseComponents
   //THEN
   //a_failure_is_returned

   [TestMethod]
   public void GIVEN_the_empty_string_WHEN_ParseComponents_THEN_a_failure_is_returned()
   {
      //Arrange
      //Act
      var actual = TestPath.TestParseComponents(string.Empty,
                                                nameof(TestPath));

      //Assert
      Assert.That
            .IsAFailure(Message.Create(IsNotAValidVolumeRootedPathBecauseMayNotBeEmpty(string.Empty,
                                                                                       nameof(TestPath))),
                        actual);
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //a_valid_path_without_a_volume
   //WHEN
   //ParseComponents
   //THEN
   //a_failure_is_returned

   [TestMethod]
   public void GIVEN_a_valid_path_without_a_volume_WHEN_Parse_THEN_a_failure_is_returned()
   {
      static Property Property(string path)
      {
         //Arrange
         //Act
         var actual = TestPath.TestParseComponents(path,
                                                   nameof(TestPath));

         //Assert
         return IsAFailure(Message.Create(IsNotAValidVolumeRootedPathBecauseMustStartWithAVolumeLabel(path,
                                                                                                      nameof(TestPath))),
                           actual);
      }

      Arb.Register<Libraries.ValidPathWithoutRoot>();

      Prop.ForAll<string>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //a_path_with_an_invalid_volume_root
   //WHEN
   //ParseComponents
   //THEN
   //a_failure_is_returned

   [TestMethod]
   public void GIVEN_a_path_with_an_invalid_volume_root_WHEN_Parse_THEN_a_failure_is_returned()
   {
      static Property Property(string path)
      {
         //Arrange
         var exception = Option<Exception>.None();

         //Act
         var actual = TestPath.TestParseComponents(path,
                                                   nameof(TestPath));

         //Assert
         return IsAFailure(Message.Create(IsNotAValidVolumeRootedPathBecauseMustStartWithAVolumeLabel(path,
                                                                                                      nameof(TestPath))),
                           actual);
      }

      Arb.Register<Libraries.PathWithInvalidVolumeRoot>();

      Prop.ForAll<string>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //a_path_with_a_volume_root_and_an_invalid_component
   //WHEN
   //ParseComponents
   //THEN
   //a_failure_is_returned

   [TestMethod]
   public void GIVEN_a_path_with_a_volume_root_and_an_invalid_component_WHEN_Parse_THEN_a_failure_is_returned()
   {
      static Property Property(string path)
      {
         //Arrange
         var exception = Option<Exception>.None();

         //Act
         var actual = TestPath.TestParseComponents(path,
                                                   nameof(TestPath));

         //Assert
         return IsAFailure(Message.Create(IsNotAValidVolumeRootedPathBecauseMayNotContainTheCharacters(path,
                                                                                                       nameof(TestPath))),
                           actual);
      }

      Arb.Register<Libraries.PathWithAVolumeRootAndAnInvalidComponent>();

      Prop.ForAll<string>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}