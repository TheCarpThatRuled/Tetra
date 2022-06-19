using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.VolumeTests;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.Volume)]
public class Append
{
   /* ------------------------------------------------------------ */
   // VolumeRootedDirectoryPath Append(this Volume volume,
   //                                  params DirectoryComponent[] directories)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_Volume_AND_an_Array_of_DirectoryComponents
   //WHEN
   //Append
   //THEN
   //a_VolumeRootedDirectoryPath_with_a_value_of_the_combine_path_is_returned

   [TestMethod]
   public void GIVEN_a_Volume_and_an_Array_of_DirectoryComponents_WHEN_Create_THEN_a_VolumeRootedDirectoryPath_with_a_value_of_the_combine_path_is_returned()
   {
      static Property Property(Volume               volume,
                               DirectoryComponent[] directories)
      {
         //Arrange
         var expected = volume.Value()
                      + Path.DirectorySeparatorChar
                      + directories.Aggregate(string.Empty,
                                              (total,
                                               next) => $"{total}{next.Value()}{Path.DirectorySeparatorChar}");

         //Act
         var actual = volume.Append(directories);

         //Assert
         return AreEqual(expected,
                         actual.Value());
      }

      Arb.Register<Libraries.Volume>();
      Arb.Register<Libraries.ArrayOfDirectoryComponents>();

      Prop.ForAll<Volume, DirectoryComponent[]>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // VolumeRootedDirectoryPath Append(this Volume volume,
   //                                  IReadOnlyCollection<DirectoryComponent> directories)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_Volume_AND_a_sequence_of_DirectoryComponents
   //WHEN
   //Append
   //THEN
   //a_VolumeRootedDirectoryPath_with_a_value_of_the_combine_path_is_returned

   [TestMethod]
   public void GIVEN_a_Volume_and_a_sequence_of_DirectoryComponents_WHEN_Create_THEN_a_VolumeRootedDirectoryPath_with_a_value_of_the_combine_path_is_returned()
   {
      static Property Property(Volume                   volume,
                               List<DirectoryComponent> directories)
      {
         //Arrange
         var expected = volume.Value()
                      + Path.DirectorySeparatorChar
                      + directories.Aggregate(string.Empty,
                                              (total,
                                               next) => $"{total}{next.Value()}{Path.DirectorySeparatorChar}");

         //Act
         var actual = volume.Append(directories);

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
   // VolumeRootedFilePath Append(this Volume volume,
   //                             FileComponent file)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_Volume_AND_a_FileComponent
   //WHEN
   //Append
   //THEN
   //a_VolumeRootedFilePath_with_a_value_of_the_combine_path_is_returned

   [TestMethod]
   public void GIVEN_a_Volume_and_a_FileComponent_WHEN_Create_THEN_a_VolumeRootedFilePath_with_a_value_of_the_combine_path_is_returned()
   {
      static Property Property(Volume        volume,
                               FileComponent file)
      {
         //Arrange
         var expected = volume.Value()
                      + Path.DirectorySeparatorChar
                      + file.Value();

         //Act
         var actual = volume.Append(file);

         //Assert
         return AreEqual(expected,
                         actual.Value());
      }

      Arb.Register<Libraries.Volume>();
      Arb.Register<Libraries.FileComponent>();

      Prop.ForAll<Volume, FileComponent>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}