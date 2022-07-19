using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.VolumeComponentTests;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.VolumeComponent)]
public class Append
{
   /* ------------------------------------------------------------ */
   // public static AbsoluteDirectoryPath Append(this VolumeComponent volume,
   //                                            params DirectoryComponent[] directories)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_VolumeComponent_AND_an_Array_of_DirectoryComponents
   //WHEN
   //Append
   //THEN
   //an_AbsoluteDirectoryPath_with_a_value_of_the_combine_path_is_returned

   [TestMethod]
   public void GIVEN_a_VolumeComponent_and_an_Array_of_DirectoryComponents_WHEN_Append_THEN_an_AbsoluteDirectoryPath_with_a_value_of_the_combine_path_is_returned()
   {
      static Property Property(VolumeComponent      volume,
                               DirectoryComponent[] directories)
      {
         //Arrange
         var expected = ExpectedPath.Combine(volume,
                                             directories);

         //Act
         var actual = volume.Append(directories);

         //Assert
         return AreEqual(expected,
                         actual.Value());
      }

      Arb.Register<Libraries.VolumeComponent>();
      Arb.Register<Libraries.ArrayOfDirectoryComponents>();

      Prop.ForAll<VolumeComponent, DirectoryComponent[]>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // public static AbsoluteDirectoryPath Append(this VolumeComponent volume,
   //                                            IReadOnlyCollection<DirectoryComponent> directories)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_VolumeComponent_AND_a_sequence_of_DirectoryComponents
   //WHEN
   //Append
   //THEN
   //an_AbsoluteDirectoryPath_with_a_value_of_the_combine_path_is_returned

   [TestMethod]
   public void GIVEN_a_VolumeComponent_and_a_sequence_of_DirectoryComponents_WHEN_Append_THEN_an_AbsoluteDirectoryPath_with_a_value_of_the_combine_path_is_returned()
   {
      static Property Property(VolumeComponent          volume,
                               List<DirectoryComponent> directories)
      {
         //Arrange
         var expected = ExpectedPath.Combine(volume,
                                             directories);

         //Act
         var actual = volume.Append(directories);

         //Assert
         return AreEqual(expected,
                         actual.Value());
      }

      Arb.Register<Libraries.VolumeComponent>();
      Arb.Register<Libraries.ListOfDirectoryComponents>();

      Prop.ForAll<VolumeComponent, List<DirectoryComponent>>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // public static AbsoluteDirectoryPath Append(this VolumeComponent volume,
   //                                            RelativeDirectoryPath path)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_VolumeComponent_AND_a_RelativeDirectoryPath
   //WHEN
   //Append
   //THEN
   //an_AbsoluteDirectoryPath_with_a_value_of_the_combine_path_is_returned

   [TestMethod]
   public void GIVEN_a_VolumeComponent_and_a_RelativeDirectoryPath_WHEN_Append_THEN_an_AbsoluteDirectoryPath_with_a_value_of_the_combine_path_is_returned()
   {
      static Property Property(VolumeComponent          volume,
                               List<DirectoryComponent> directories)
      {
         //Arrange
         var path = RelativeDirectoryPath.Create(directories);

         var expected = ExpectedPath.Combine(volume,
                                             directories);

         //Act
         var actual = volume.Append(path);

         //Assert
         return AreEqual(expected,
                         actual.Value());
      }

      Arb.Register<Libraries.VolumeComponent>();
      Arb.Register<Libraries.ListOfDirectoryComponents>();

      Prop.ForAll<VolumeComponent, List<DirectoryComponent>>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // public static AbsoluteFilePath Append(this VolumeComponent volume,
   //                                       FileComponent file)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_VolumeComponent_AND_a_FileComponent
   //WHEN
   //Append
   //THEN
   //an_AbsoluteFilePath_with_a_value_of_the_combine_path_is_returned

   [TestMethod]
   public void GIVEN_a_VolumeComponent_and_a_FileComponent_WHEN_Append_THEN_an_AbsoluteFilePath_with_a_value_of_the_combine_path_is_returned()
   {
      static Property Property(VolumeComponent volume,
                               FileComponent   file)
      {
         //Arrange
         var expected = ExpectedPath.Combine(volume,
                                             Array.Empty<DirectoryComponent>(),
                                             file);

         //Act
         var actual = volume.Append(file);

         //Assert
         return AreEqual(expected,
                         actual.Value());
      }

      Arb.Register<Libraries.VolumeComponent>();
      Arb.Register<Libraries.FileComponent>();

      Prop.ForAll<VolumeComponent, FileComponent>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // public static AbsoluteFilePath Append(this VolumeComponent volume,
   //                                       RelativeFilePath path)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_VolumeComponent_AND_a_RelativeFilePath
   //WHEN
   //Append
   //THEN
   //an_AbsoluteFilePath_with_a_value_of_the_combine_path_is_returned

   [TestMethod]
   public void GIVEN_a_VolumeComponent_and_a_RelativeFilePath_WHEN_Append_THEN_an_AbsoluteFilePath_with_a_value_of_the_combine_path_is_returned()
   {
      static Property Property(VolumeComponent          volume,
                               List<DirectoryComponent> directories,
                               FileComponent            file)
      {
         //Arrange
         var path = RelativeFilePath.Create(directories,
                                            file);

         var expected = ExpectedPath.Combine(volume,
                                             directories,
                                             file);

         //Act
         var actual = volume.Append(path);

         //Assert
         return AreEqual(expected,
                         actual.Value());
      }

      Arb.Register<Libraries.FileComponent>();
      Arb.Register<Libraries.ListOfDirectoryComponents>();
      Arb.Register<Libraries.VolumeComponent>();

      Prop.ForAll<VolumeComponent, List<DirectoryComponent>, FileComponent>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}