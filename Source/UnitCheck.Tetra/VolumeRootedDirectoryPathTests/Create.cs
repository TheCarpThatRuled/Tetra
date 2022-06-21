using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.VolumeRootedDirectoryPathTests;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.VolumeRootedDirectoryPath)]
public class Create
{
   /* ------------------------------------------------------------ */
   // VolumeRootedDirectoryPath Create(Volume volume,
   //                                  IReadOnlyCollection<DirectoryComponent> directories)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_valid_volume_rooted_path_with_a_trailing_directory_separator
   //WHEN
   //Create
   //THEN
   //a_VolumeRootedDirectoryPath_with_a_value_of_the_combine_path_is_returned

   [TestMethod]
   public void GIVEN_a_valid_volume_rooted_path_with_a_trailing_directory_separator_WHEN_Create_THEN_a_VolumeRootedDirectoryPath_with_a_value_of_the_combine_path_is_returned()
   {
      static Property Property(string path)
      {
         //Arrange
         //Act
         var actual = VolumeRootedDirectoryPath.Create(path);

         //Assert
         return AreEqual(path,
                         actual.Value());
      }

      Arb.Register<Libraries.ValidPathWithVolumeRootAndTrailingDirectorySeparator>();

      Prop.ForAll<string>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //a_valid_volume_rooted_path_without_a_trailing_directory_separator
   //WHEN
   //Create
   //THEN
   //a_VolumeRootedDirectoryPath_with_a_value_of_the_combine_path_is_returned

   [TestMethod]
   public void GIVEN_a_valid_volume_rooted_path_without_a_trailing_directory_separator_WHEN_Create_THEN_a_VolumeRootedDirectoryPath_with_a_value_of_the_combine_path_is_returned()
   {
      static Property Property(string path)
      {
         //Arrange
         //Act
         var actual = VolumeRootedDirectoryPath.Create(path);

         //Assert
         return AreEqual($"{path}{Path.DirectorySeparatorChar}",
                         actual.Value());
      }

      Arb.Register<Libraries.ValidPathWithVolumeRootButWithoutTrailingDirectorySeparator>();

      Prop.ForAll<string>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //a_valid_path_without_a_volume
   //WHEN
   //Create
   //THEN
   //an_argument_exception_is_thrown

   [TestMethod]
   public void GIVEN_a_valid_path_without_a_volume_WHEN_Create_THEN_a_failure_is_returned()
   {
      static Property Property(string path)
      {
         //Arrange
         var exception = Option<Exception>.None();

         //Act
         try
         {
            VolumeRootedDirectoryPath.Create(path);
         }
         catch (Exception e)
         {
            exception = e;
         }

         //Assert
         return AnArgumentExceptionWasThrown(exception,
                                             "A VolumeRootedDirectoryPath must start with a volume label" + " (Parameter 'potentialPath')");
      }

      Arb.Register<Libraries.ValidPathWithoutRoot>();

      Prop.ForAll<string>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // VolumeRootedDirectoryPath Create(Volume volume,
   //                                  IReadOnlyCollection<DirectoryComponent> directories)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_Volume_and_a_sequence_of_DirectoryComponents
   //WHEN
   //Create
   //THEN
   //a_VolumeRootedDirectoryPath_with_a_value_of_the_combine_path_is_returned

   [TestMethod]
   public void GIVEN_a_Volume_and_a_sequence_of_DirectoryComponents_WHEN_Create_THEN_a_VolumeRootedDirectoryPath_with_a_value_of_the_combine_path_is_returned()
   {
      static Property Property(Volume                   volume,
                               List<DirectoryComponent> directories)
      {
         //Arrange
         var expected = directories
                       .Select(x => x.Value())
                       .Prepend(volume.Value())
                       .ToArray()
                       .ToDelimitedStringWithTrailingDelimiter(Path.DirectorySeparatorChar);

         //Act
         var actual = VolumeRootedDirectoryPath.Create(volume,
                                                       directories);

         //Assert
         return AreEqual(expected,
                         actual.Value());
      }

      Arb.Register<Libraries.Volume>();
      Arb.Register<Libraries.ListOfDirectoryComponents>();

      Prop.ForAll<Volume, List<DirectoryComponent>>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}