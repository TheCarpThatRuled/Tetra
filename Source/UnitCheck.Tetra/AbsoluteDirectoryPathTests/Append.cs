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
                               DirectoryComponent[]      directories)
      {
         //Arrange
         var expected = testPath.Append(directories);

         var path = testPath.ToTetra();

         //Act
         var actual = path.Append(directories);

         //Assert
         return AreEqual("Append",
                         expected,
                         actual);
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
         return AreEqual("Append",
                         expected,
                         actual);
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
      static Property Property(TestAbsoluteDirectoryPath testParentPath,
                               TestRelativeDirectoryPath testChildPath)
      {
         //Arrange
         var expected = testParentPath.Append(testChildPath);

         var parentPath = testParentPath.ToTetra();
         var childPath  = testChildPath.ToTetra();

         //Act
         var actual = parentPath.Append(childPath);

         //Assert
         return AreEqual("Append",
                         expected,
                         actual);
      }

      Arb.Register<Libraries.TestAbsoluteDirectoryPath>();
      Arb.Register<Libraries.TestRelativeDirectoryPath>();

      Prop.ForAll<TestAbsoluteDirectoryPath, TestRelativeDirectoryPath>(Property)
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
      static Property Property(TestAbsoluteDirectoryPath testPath,
                               FileComponent             file)
      {
         //Arrange
         var expected = testPath.Append(file);

         var path = testPath.ToTetra();

         //Act
         var actual = path.Append(file);

         //Assert
         return AreEqual("Append",
                         expected,
                         actual);
      }

      Arb.Register<Libraries.FileComponent>();
      Arb.Register<Libraries.TestAbsoluteDirectoryPath>();

      Prop.ForAll<TestAbsoluteDirectoryPath, FileComponent>(Property)
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
      static Property Property(TestAbsoluteDirectoryPath testParentPath,
                               TestRelativeFilePath      testChildPath)
      {
         //Arrange
         var expected = testParentPath.Append(testChildPath);

         var parentPath = testParentPath.ToTetra();
         var childPath  = testChildPath.ToTetra();

         //Act
         var actual = parentPath.Append(childPath);

         //Assert
         return AreEqual("Append",
                         expected,
                         actual);
      }

      Arb.Register<Libraries.TestAbsoluteDirectoryPath>();
      Arb.Register<Libraries.TestRelativeFilePath>();

      Prop.ForAll<TestAbsoluteDirectoryPath, TestRelativeFilePath>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}