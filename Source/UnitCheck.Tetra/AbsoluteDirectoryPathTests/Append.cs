using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.AbsoluteDirectoryPathTests;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.AbsoluteDirectoryPath)]
public class Append
{
   /* ------------------------------------------------------------ */
   // AbsoluteDirectoryPath Append(params DirectoryComponent[] directories)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_AbsoluteDirectoryPath_AND_an_Array_of_DirectoryComponents
   //WHEN
   //Append
   //THEN
   //a_AbsoluteDirectoryPath_with_a_value_of_the_combine_path_is_returned

   [TestMethod]
   public void GIVEN_a_AbsoluteDirectoryPath_and_an_Array_of_DirectoryComponents_WHEN_Append_THEN_a_AbsoluteDirectoryPath_with_a_value_of_the_combine_path_is_returned()
   {
      static Property Property(VolumeComponent      volume,
                               DirectoryComponent[] initialDirectories,
                               DirectoryComponent[] directories)
      {
         //Arrange
         var expected = ExpectedPath.Combine(volume,
                                             initialDirectories.Concat(directories));

         var path = AbsoluteDirectoryPath.Create(volume,
                                                 initialDirectories);

         //Act
         var actual = path.Append(initialDirectories);

         //Assert
         return AreEqual(expected,
                         actual.Value());
      }

      Arb.Register<Libraries.VolumeComponent>();
      Arb.Register<Libraries.ArrayOfDirectoryComponents>();

      Prop.ForAll<VolumeComponent, DirectoryComponent[], DirectoryComponent[]>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // AbsoluteDirectoryPath Append(IEnumerable<DirectoryComponent> directories)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_AbsoluteDirectoryPath_AND_a_sequence_of_DirectoryComponents
   //WHEN
   //Append
   //THEN
   //a_AbsoluteDirectoryPath_with_a_value_of_the_combine_path_is_returned

   [TestMethod]
   public void GIVEN_a_AbsoluteDirectoryPath_and_a_sequence_of_DirectoryComponents_WHEN_Append_THEN_a_AbsoluteDirectoryPath_with_a_value_of_the_combine_path_is_returned()
   {
      static Property Property(VolumeComponent          volume,
                               List<DirectoryComponent> initialDirectories,
                               List<DirectoryComponent> directories)
      {
         //Arrange
         var path = AbsoluteDirectoryPath.Create(volume,
                                                 initialDirectories);

         var expected = ExpectedPath.Combine(volume,
                                             initialDirectories.Concat(directories));

         //Act
         var actual = path.Append(directories);

         //Assert
         return AreEqual(expected,
                         actual.Value());
      }

      Arb.Register<Libraries.VolumeComponent>();
      Arb.Register<Libraries.ListOfDirectoryComponents>();

      Prop.ForAll<VolumeComponent, List<DirectoryComponent>, List<DirectoryComponent>>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // AbsoluteFilePath Append(FileComponent file)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_AbsoluteDirectoryPath_AND_a_FileComponent
   //WHEN
   //Append
   //THEN
   //a_AbsoluteFilePath_with_a_value_of_the_combine_path_is_returned

   [TestMethod]
   public void GIVEN_a_AbsoluteDirectoryPath_and_a_FileComponent_WHEN_Append_THEN_a_AbsoluteFilePath_with_a_value_of_the_combine_path_is_returned()
   {
      static Property Property(VolumeComponent          volume,
                               List<DirectoryComponent> directories,
                               FileComponent            file)
      {
         //Arrange
         var path = AbsoluteDirectoryPath.Create(volume,
                                                 directories);

         var expected = ExpectedPath.Combine(volume,
                                             directories,
                                             file);

         //Act
         var actual = path.Append(file);

         //Assert
         return AreEqual(expected,
                         actual.Value());
      }

      Arb.Register<Libraries.VolumeComponent>();
      Arb.Register<Libraries.ListOfDirectoryComponents>();
      Arb.Register<Libraries.FileComponent>();

      Prop.ForAll<VolumeComponent, List<DirectoryComponent>, FileComponent>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}