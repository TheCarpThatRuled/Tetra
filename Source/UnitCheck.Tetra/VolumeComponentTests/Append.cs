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
      static Property Property(VolumeComponent      parent,
                               DirectoryComponent[] child)
      {
         //Arrange
         var expected = TestAbsoluteDirectoryPath.Create(parent,
                                                         child);

         //Act
         var actual = parent.Append(child);

         //Assert
         return AreEqual(expected,
                         actual,
                         "Append");
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
      static Property Property(VolumeComponent          parent,
                               List<DirectoryComponent> child)
      {
         //Arrange
         var expected = TestAbsoluteDirectoryPath.Create(parent,
                                                         child);

         //Act
         var actual = parent.Append(child);

         //Assert
         return AreEqual(expected,
                         actual,
                         "Append");
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
      static Property Property(VolumeComponent           parent,
                               TestRelativeDirectoryPath testChild)
      {
         //Arrange
         var expected = TestAbsoluteDirectoryPath.Create(parent,
                                                         testChild.Directories());

         var child = testChild.ToTetra();

         //Act
         var actual = parent.Append(child);

         //Assert
         return AreEqual(expected,
                         actual,
                         "Append");
      }

      Arb.Register<Libraries.TestRelativeDirectoryPath>();
      Arb.Register<Libraries.VolumeComponent>();

      Prop.ForAll<VolumeComponent, TestRelativeDirectoryPath>(Property)
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
      static Property Property(VolumeComponent parent,
                               FileComponent   child)
      {
         //Arrange
         var expected = TestAbsoluteFilePath.Create(parent,
                                                    Array.Empty<DirectoryComponent>(),
                                                    child);

         //Act
         var actual = parent.Append(child);

         //Assert
         return AreEqual(expected,
                         actual,
                         "Append");
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
      static Property Property(VolumeComponent      parent,
                               TestRelativeFilePath testChild)
      {
         //Arrange
         var expected = TestAbsoluteFilePath.Create(parent,
                                                    testChild.Directories(),
                                                    testChild.File());

         var child = testChild.ToTetra();

         //Act
         var actual = parent.Append(child);

         //Assert
         return AreEqual(expected,
                         actual,
                         "Append");
      }

      Arb.Register<Libraries.TestRelativeFilePath>();
      Arb.Register<Libraries.VolumeComponent>();

      Prop.ForAll<VolumeComponent, TestRelativeFilePath>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}