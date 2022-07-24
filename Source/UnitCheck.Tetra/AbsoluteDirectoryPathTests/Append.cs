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
   // public static AbsoluteDirectoryPath Append(params DirectoryComponent[] directories)
   /* ------------------------------------------------------------ */

   //GIVEN
   //an_AbsoluteDirectoryPath_AND_an_Array_of_DirectoryComponents
   //WHEN
   //Append
   //THEN
   //an_AbsoluteDirectoryPath_with_a_value_of_the_combine_path_is_returned

   [TestMethod]
   public void GIVEN_an_AbsoluteDirectoryPath_and_an_Array_of_DirectoryComponents_WHEN_Append_THEN_an_AbsoluteDirectoryPath_with_a_value_of_the_combine_path_is_returned()
   {
      static Property Property(TestAbsoluteDirectoryPath testPath,
                               DirectoryComponent[] directories)
      {
         //Arrange
         var expected = testPath.Append(directories);

         var path = testPath.ToTetra();

         //Act
         var actual = path.Append(directories);

         //Assert
         return AreEqual(expected,
                         actual,
                         "Append");
      }

      Arb.Register<Libraries.TestAbsoluteDirectoryPath>();
      Arb.Register<Libraries.ArrayOfDirectoryComponents>();

      Prop.ForAll<TestAbsoluteDirectoryPath, DirectoryComponent[]>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // public static AbsoluteDirectoryPath Append(IEnumerable<DirectoryComponent> directories)
   /* ------------------------------------------------------------ */

   //GIVEN
   //an_AbsoluteDirectoryPath_AND_a_sequence_of_DirectoryComponents
   //WHEN
   //Append
   //THEN
   //an_AbsoluteDirectoryPath_with_a_value_of_the_combine_path_is_returned

   [TestMethod]
   public void GIVEN_an_AbsoluteDirectoryPath_and_a_sequence_of_DirectoryComponents_WHEN_Append_THEN_an_AbsoluteDirectoryPath_with_a_value_of_the_combine_path_is_returned()
   {
      static Property Property(TestAbsoluteDirectoryPath testPath,
                               List<DirectoryComponent>  directories)
      {
         //Arrange
         var expected = testPath.Append(directories);

         var path = testPath.ToTetra();

         //Act
         var actual = path.Append(directories);

         //Assert
         return AreEqual(expected,
                         actual,
                         "Append");
      }

      Arb.Register<Libraries.TestAbsoluteDirectoryPath>();
      Arb.Register<Libraries.ListOfDirectoryComponents>();

      Prop.ForAll<TestAbsoluteDirectoryPath, List<DirectoryComponent>>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // public static AbsoluteDirectoryPath Append(RelativeDirectoryPath path)
   /* ------------------------------------------------------------ */

   //GIVEN
   //an_AbsoluteDirectoryPath_AND_a_RelativeDirectoryPath
   //WHEN
   //Append
   //THEN
   //an_AbsoluteDirectoryPath_with_a_value_of_the_combine_path_is_returned

   [TestMethod]
   public void GIVEN_an_AbsoluteDirectoryPath_and_a_RelativeDirectoryPath_WHEN_Append_THEN_an_AbsoluteDirectoryPath_with_a_value_of_the_combine_path_is_returned()
   {
      static Property Property(VolumeComponent          volume,
                               List<DirectoryComponent> initialDirectories,
                               List<DirectoryComponent> directories)
      {
         //Arrange
         var path = AbsoluteDirectoryPath.Create(volume,
                                                 initialDirectories);
         var childPath = RelativeDirectoryPath.Create(directories);

         var expected = ExpectedPath.Combine(volume,
                                             initialDirectories.Concat(directories));

         //Act
         var actual = path.Append(childPath);

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
   // public static AbsoluteFilePath Append(FileComponent file)
   /* ------------------------------------------------------------ */

   //GIVEN
   //an_AbsoluteDirectoryPath_AND_a_FileComponent
   //WHEN
   //Append
   //THEN
   //an_AbsoluteFilePath_with_a_value_of_the_combine_path_is_returned

   [TestMethod]
   public void GIVEN_an_AbsoluteDirectoryPath_and_a_FileComponent_WHEN_Append_THEN_an_AbsoluteFilePath_with_a_value_of_the_combine_path_is_returned()
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
   // public static AbsoluteFilePath Append(RelativeFilePath path)
   /* ------------------------------------------------------------ */

   //GIVEN
   //an_AbsoluteDirectoryPath_AND_a_RelativeFilePath
   //WHEN
   //Append
   //THEN
   //an_AbsoluteFilePath_with_a_value_of_the_combine_path_is_returned

   [TestMethod]
   public void GIVEN_an_AbsoluteDirectoryPath_and_a_RelativeFilePath_WHEN_Append_THEN_an_AbsoluteFilePath_with_a_value_of_the_combine_path_is_returned()
   {
      static Property Property(VolumeComponent                                                         volume,
                               (List<DirectoryComponent> initial, List<DirectoryComponent> additional) directories,
                               FileComponent                                                           file)
      {
         //Arrange
         var path = AbsoluteDirectoryPath.Create(volume,
                                                 directories.initial);
         var childPath = RelativeFilePath.Create(directories.additional,
                                                 file);

         var expected = ExpectedPath.Combine(volume,
                                             directories.initial.Concat(directories.additional),
                                             file);

         //Act
         var actual = path.Append(childPath);

         //Assert
         return AreEqual(expected,
                         actual.Value());
      }

      Arb.Register<Libraries.FileComponent>();
      Arb.Register<Libraries.TwoListsOfDirectoryComponents>();
      Arb.Register<Libraries.VolumeComponent>();

      Prop.ForAll<VolumeComponent, (List<DirectoryComponent>, List<DirectoryComponent>), FileComponent>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}