using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.VolumeRootedDirectoryPathTests;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.VolumeRootedDirectoryPath)]
public class Append
{
   /* ------------------------------------------------------------ */
   // VolumeRootedDirectoryPath Append(params DirectoryComponent[] directories)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_VolumeRootedDirectoryPath_AND_an_Array_of_DirectoryComponents
   //WHEN
   //Append
   //THEN
   //a_VolumeRootedDirectoryPath_with_a_value_of_the_combine_path_is_returned

   [TestMethod]
   public void GIVEN_a_VolumeRootedDirectoryPath_and_an_Array_of_DirectoryComponents_WHEN_Create_THEN_a_VolumeRootedDirectoryPath_with_a_value_of_the_combine_path_is_returned()
   {
      static Property Property(Volume               volume,
                               DirectoryComponent[] initialDirectories,
                               DirectoryComponent[] directories)
      {
         //Arrange
         var volumeRootedDirectoryPath = VolumeRootedDirectoryPath.Create(volume,
                                                                          initialDirectories);

         var expected = volumeRootedDirectoryPath.Value()
                      + initialDirectories.Aggregate(string.Empty,
                                                     (total,
                                                      next) => $"{total}{next.Value()}{Path.DirectorySeparatorChar}");

         //Act
         var actual = volumeRootedDirectoryPath.Append(initialDirectories);

         //Assert
         return AreEqual(expected,
                         actual.Value());
      }

      Arb.Register<Libraries.Volume>();
      Arb.Register<Libraries.ArrayOfDirectoryComponents>();

      Prop.ForAll<Volume, DirectoryComponent[], DirectoryComponent[]>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // VolumeRootedDirectoryPath Append(IEnumerable<DirectoryComponent> directories)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_VolumeRootedDirectoryPath_AND_a_sequence_of_DirectoryComponents
   //WHEN
   //Append
   //THEN
   //a_VolumeRootedDirectoryPath_with_a_value_of_the_combine_path_is_returned

   [TestMethod]
   public void GIVEN_a_VolumeRootedDirectoryPath_and_a_sequence_of_DirectoryComponents_WHEN_Create_THEN_a_VolumeRootedDirectoryPath_with_a_value_of_the_combine_path_is_returned()
   {
      static Property Property(Volume                   volume,
                               List<DirectoryComponent> initialDirectories,
                               List<DirectoryComponent> directories)
      {
         //Arrange
         var volumeRootedDirectoryPath = VolumeRootedDirectoryPath.Create(volume,
                                                                          initialDirectories);
         var expected = volumeRootedDirectoryPath.Value()
                      + directories.Aggregate(string.Empty,
                                              (total,
                                               next) => $"{total}{next.Value()}{Path.DirectorySeparatorChar}");

         //Act
         var actual = volumeRootedDirectoryPath.Append(directories);

         //Assert
         return AreEqual(expected,
                         actual.Value());
      }

      Arb.Register<Libraries.Volume>();
      Arb.Register<Libraries.ListOfDirectoryComponents>();

      Prop.ForAll<Volume, List<DirectoryComponent>, List<DirectoryComponent>>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // VolumeRootedFilePath Append(FileComponent file)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_VolumeRootedDirectoryPath_AND_a_FileComponent
   //WHEN
   //Append
   //THEN
   //a_VolumeRootedFilePath_with_a_value_of_the_combine_path_is_returned

   [TestMethod]
   public void GIVEN_a_VolumeRootedDirectoryPath_and_a_FileComponent_WHEN_Create_THEN_a_VolumeRootedFilePath_with_a_value_of_the_combine_path_is_returned()
   {
      static Property Property(Volume                   volume,
                               List<DirectoryComponent> initialDirectories,
                               FileComponent file)
      {
         //Arrange
         var volumeRootedDirectoryPath = VolumeRootedDirectoryPath.Create(volume,
                                                                          initialDirectories);
         var expected = volumeRootedDirectoryPath.Value()
                      + file.Value();

         //Act
         var actual = volumeRootedDirectoryPath.Append(file);

         //Assert
         return AreEqual(expected,
                         actual.Value());
      }

      Arb.Register<Libraries.Volume>();
      Arb.Register<Libraries.ListOfDirectoryComponents>();
      Arb.Register<Libraries.FileComponent>();

      Prop.ForAll<Volume, List<DirectoryComponent>, FileComponent>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}