using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.VolumeRootedFilePathTests;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.VolumeRootedFilePath)]
public class ParseComponents
{
   /* ------------------------------------------------------------ */
   
   private sealed class TestPath : VolumeRootedFilePath
   {
      /* ------------------------------------------------------------ */
      // Functions
      /* ------------------------------------------------------------ */

      public static Result<(Volume volume, IReadOnlyCollection<DirectoryComponent> directories, FileComponent file)> TestParseComponents(string potentialPath,
                                                                                                                     Type   callerType)
         => ParseComponents(potentialPath,
                            callerType);

      /* ------------------------------------------------------------ */
      // Constructor
      /* ------------------------------------------------------------ */

      private TestPath(IReadOnlyCollection<DirectoryComponent> directories,
                       Volume                                  volume,
                       FileComponent                           file)
         : base(directories,
                file,
                volume) { }

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */
   // protected Result(Volume volume, IReadOnlyCollection<DirectoryComponent> directories) ParseComponents(string potentialPath)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_valid_volume_rooted_path_without_a_trailing_directory_separator
   //WHEN
   //ParseComponents
   //THEN
   //a_success_containing_VolumeRootedFilePath_with_a_value_of_the_combine_path_is_returned

   [TestMethod]
   public void
      GIVEN_a_valid_volume_rooted_path_without_a_trailing_directory_separator_WHEN_Parse_THEN_a_success_containing_VolumeRootedFilePath_with_a_value_of_the_combine_path_is_returned()
   {
      static Property Property(Volume               volume,
                               DirectoryComponent[] directories,
                               FileComponent        file)
      {
         //Arrange
         var path = directories
                   .Select(x => x.Value())
                   .Prepend(volume.Value())
                   .Append(file.Value())
                   .ToArray()
                   .ToDelimitedString(Path.DirectorySeparatorChar);

         //Act
         var actual = TestPath.TestParseComponents(path,
                                                   typeof(TestPath));

         //Assert
         return IsASuccessAnd(actualComponents => volume.Equals(actualComponents
                                                               .Content()
                                                               .volume)
                                               && directories.SequenceEqual(actualComponents
                                                                           .Content()
                                                                           .directories)
                                               && file.Equals((actualComponents
                                                              .Content()
                                                              .file)),
                              actual);
      }

      Arb.Register<Libraries.ArrayOfDirectoryComponents>();
      Arb.Register<Libraries.FileComponent>();
      Arb.Register<Libraries.Volume>();

      Prop.ForAll<Volume, DirectoryComponent[], FileComponent>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //a_valid_volume_rooted_path_with_a_trailing_directory_separator
   //WHEN
   //ParseComponents
   //THEN
   //a_failure_isReturned

   [TestMethod]
   public void
      GIVEN_a_valid_volume_rooted_path_with_a_trailing_directory_separator_WHEN_Parse_THEN_a_success_containing_VolumeRootedFilePath_with_a_value_of_the_combine_path_is_returned()
   {
      static Property Property(string path)
      {
         //Arrange
         //Act
         var actual = TestPath.TestParseComponents(path,
                                                   typeof(TestPath));

         //Assert
         return IsAFailure(Message.Create("A TestPath may not end with a directory separator"),
                           actual);
      }

      Arb.Register<Libraries.ValidPathWithVolumeRootAndTrailingDirectorySeparator>();

      Prop.ForAll<string>(Property)
          .QuickCheckThrowOnFailure();
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
                                                   typeof(TestPath));

         //Assert
         return IsAFailure(Message.Create("A TestPath must start with a volume label"),
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
                                                   typeof(TestPath));

         //Assert
         return IsAFailure(Message.Create("A TestPath must start with a volume label"),
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
                                                   typeof(TestPath));

         //Assert
         return IsAFailure(Message.Create("A TestPath may not contain a component with any of the following characters:"),
                           actual);
      }

      Arb.Register<Libraries.PathWithAVolumeRootAndAnInvalidComponent>();

      Prop.ForAll<string>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}