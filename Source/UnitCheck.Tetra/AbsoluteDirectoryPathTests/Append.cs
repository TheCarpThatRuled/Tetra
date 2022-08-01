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
   // public AbsoluteDirectoryPath Append(params DirectoryComponent[] child)
   /* ------------------------------------------------------------ */

   //GIVEN
   //an_AbsoluteDirectoryPath_AND_an_Array_of_DirectoryComponents
   //WHEN
   //Append
   //THEN
   //an_AbsoluteDirectoryPath_containing_the_AbsoluteDirectoryPath_and_the_Array_of_DirectoryComponents_is_returned

   [TestMethod]
   public void GIVEN_an_AbsoluteDirectoryPath_and_an_Array_of_DirectoryComponents_WHEN_Append_THEN_an_AbsoluteDirectoryPath_containing_the_AbsoluteDirectoryPath_and_the_Array_of_DirectoryComponents_is_returned()
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
         return AreEqual(AssertMessages.ReturnValue,
                         expected,
                         actual);
      }

      Arb.Register<Libraries.TestAbsoluteDirectoryPath>();
      Arb.Register<Libraries.ArrayOfDirectoryComponents>();

      Prop.ForAll<TestAbsoluteDirectoryPath, DirectoryComponent[]>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // public AbsoluteDirectoryPath Append(IEnumerable<DirectoryComponent> child)
   /* ------------------------------------------------------------ */

   //GIVEN
   //an_AbsoluteDirectoryPath_AND_a_sequence_of_DirectoryComponents
   //WHEN
   //Append
   //THEN
   //an_AbsoluteDirectoryPath_containing_the_AbsoluteDirectoryPath_and_the_sequence_of_DirectoryComponents_is_returned

   [TestMethod]
   public void GIVEN_an_AbsoluteDirectoryPath_and_a_sequence_of_DirectoryComponents_WHEN_Append_THEN_an_AbsoluteDirectoryPath_containing_the_AbsoluteDirectoryPath_and_the_sequence_of_DirectoryComponents_is_returned()
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
         return AreEqual(AssertMessages.ReturnValue,
                         expected,
                         actual);
      }

      Arb.Register<Libraries.TestAbsoluteDirectoryPath>();
      Arb.Register<Libraries.ListOfDirectoryComponents>();

      Prop.ForAll<TestAbsoluteDirectoryPath, List<DirectoryComponent>>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // public AbsoluteDirectoryPath Append(RelativeDirectoryPath child)
   /* ------------------------------------------------------------ */

   //GIVEN
   //an_AbsoluteDirectoryPath_AND_a_RelativeDirectoryPath
   //WHEN
   //Append
   //THEN
   //an_AbsoluteDirectoryPath_containing_the_AbsoluteDirectoryPath_and_the_RelativeDirectoryPath_is_returned

   [TestMethod]
   public void GIVEN_an_AbsoluteDirectoryPath_and_a_RelativeDirectoryPath_WHEN_Append_THEN_an_AbsoluteDirectoryPath_containing_the_AbsoluteDirectoryPath_and_the_RelativeDirectoryPath_is_returned()
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
         return AreEqual(AssertMessages.ReturnValue,
                         expected,
                         actual);
      }

      Arb.Register<Libraries.TestAbsoluteDirectoryPath>();
      Arb.Register<Libraries.TestRelativeDirectoryPath>();

      Prop.ForAll<TestAbsoluteDirectoryPath, TestRelativeDirectoryPath>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // public AbsoluteFilePath Append(FileComponent child)
   /* ------------------------------------------------------------ */

   //GIVEN
   //an_AbsoluteDirectoryPath_AND_a_FileComponent
   //WHEN
   //Append
   //THEN
   //an_AbsoluteFilePath_containing_the_AbsoluteDirectoryPath_and_the_FileComponent_is_returned

   [TestMethod]
   public void GIVEN_an_AbsoluteDirectoryPath_and_a_FileComponent_WHEN_Append_THEN_an_AbsoluteFilePath_containing_the_AbsoluteDirectoryPath_and_the_FileComponent_is_returned()
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
         return AreEqual(AssertMessages.ReturnValue,
                         expected,
                         actual);
      }

      Arb.Register<Libraries.FileComponent>();
      Arb.Register<Libraries.TestAbsoluteDirectoryPath>();

      Prop.ForAll<TestAbsoluteDirectoryPath, FileComponent>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // public AbsoluteFilePath Append(RelativeFilePath child)
   /* ------------------------------------------------------------ */

   //GIVEN
   //an_AbsoluteDirectoryPath_AND_a_RelativeFilePath
   //WHEN
   //Append
   //THEN
   //an_AbsoluteFilePath_containing_the_AbsoluteDirectoryPath_and_the_RelativeFilePath_is_returned

   [TestMethod]
   public void GIVEN_an_AbsoluteDirectoryPath_and_a_RelativeFilePath_WHEN_Append_THEN_an_AbsoluteFilePath_containing_the_AbsoluteDirectoryPath_and_the_RelativeFilePath_is_returned()
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
         return AreEqual(AssertMessages.ReturnValue,
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