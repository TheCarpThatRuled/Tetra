using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.VolumeRootedFilePathTests;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.VolumeRootedFilePath)]
public class Create
{
   /* ------------------------------------------------------------ */
   // VolumeRootedFilePath Create(Volume volume,
   //                                  IReadOnlyCollection<DirectoryComponent> directories)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_Volume_and_a_sequence_of_DirectoryComponents
   //WHEN
   //Create
   //THEN
   //a_VolumeRootedFilePath_with_a_value_of_the_combine_path_is_returned

   [TestMethod]
   public void GIVEN_a_Volume_and_a_sequence_of_DirectoryComponents_WHEN_Create_THEN_a_VolumeRootedFilePath_with_a_value_of_the_combine_path_is_returned()
   {
      static Property Property(Volume                   volume,
                               List<DirectoryComponent> directories,
                               FileComponent file)
      {
         //Arrange
         var expected = volume.Value()
                      + Path.DirectorySeparatorChar
                      + directories.Aggregate(string.Empty,
                                              (total,
                                               next) => $"{total}{next.Value()}{Path.DirectorySeparatorChar}")
                      + file.Value();

         //Act
         var actual = VolumeRootedFilePath.Create(volume,
                                                  directories,
                                                  file);

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