using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.RelativeDirectoryPathTests;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.RelativeDirectoryPath)]
public class Append
{
   /* ------------------------------------------------------------ */
   // public RelativeDirectoryPath Append(params DirectoryComponent[] directories)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_RelativeDirectoryPath_AND_an_Array_of_DirectoryComponents
   //WHEN
   //Append
   //THEN
   //a_RelativeDirectoryPath_containing_the_RelativeDirectoryPath_and_the_Array_of_DirectoryComponents_is_returned

   [TestMethod]
   public void
      GIVEN_a_RelativeDirectoryPath_and_an_Array_of_DirectoryComponents_WHEN_Append_THEN_a_RelativeDirectoryPath_containing_the_RelativeDirectoryPath_and_the_Array_of_DirectoryComponents_is_returned()
   {
      static Property Property(TestRelativeDirectoryPath testChild,
                               DirectoryComponent[]      parent)
      {
         //Arrange
         var expected = testChild.Append(parent);

         var child = testChild.ToTetra();

         //Act
         var actual = child.Append(parent);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         expected,
                         actual);
      }

      Arb.Register<Libraries.ArrayOfDirectoryComponents>();
      Arb.Register<Libraries.TestRelativeDirectoryPath>();

      Prop.ForAll<TestRelativeDirectoryPath, DirectoryComponent[]>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // public RelativeDirectoryPath Append(IReadOnlyCollection<DirectoryComponent> directories)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_RelativeDirectoryPath_AND_a_sequence_of_DirectoryComponents
   //WHEN
   //Append
   //THEN
   //a_RelativeDirectoryPath_containing_the_RelativeDirectoryPath_and_the_sequence_of_DirectoryComponents_is_returned

   [TestMethod]
   public void
      GIVEN_a_RelativeDirectoryPath_and_a_sequence_of_DirectoryComponents_WHEN_Append_THEN_a_RelativeDirectoryPath_containing_the_RelativeDirectoryPath_and_the_sequence_of_DirectoryComponents_is_returned()
   {
      static Property Property(TestRelativeDirectoryPath testChild,
                               List<DirectoryComponent>  parent)
      {
         //Arrange
         var expected = testChild.Append(parent);

         var child = testChild.ToTetra();

         //Act
         var actual = child.Append(parent);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         expected,
                         actual);
      }

      Arb.Register<Libraries.ListOfDirectoryComponents>();
      Arb.Register<Libraries.TestRelativeDirectoryPath>();

      Prop.ForAll<TestRelativeDirectoryPath, List<DirectoryComponent>>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // public RelativeDirectoryPath Append(RelativeDirectoryPath path)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_RelativeDirectoryPath_AND_a_RelativeDirectoryPath
   //WHEN
   //Append
   //THEN
   //a_RelativeDirectoryPath_containing_the_RelativeDirectoryPath_and_the_RelativeDirectoryPath_is_returned

   [TestMethod]
   public void
      GIVEN_a_RelativeDirectoryPath_and_a_RelativeDirectoryPath_WHEN_Append_THEN_a_RelativeDirectoryPath_containing_the_RelativeDirectoryPath_and_the_RelativeDirectoryPath_is_returned()
   {
      static Property Property(TestRelativeDirectoryPath testChild,
                               TestRelativeDirectoryPath testParent)
      {
         //Arrange
         var expected = testChild.Append(testParent);

         var child  = testChild.ToTetra();
         var parent = testParent.ToTetra();

         //Act
         var actual = child.Append(parent);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         expected,
                         actual);
      }

      Arb.Register<Libraries.TestRelativeDirectoryPath>();
      Arb.Register<Libraries.TestRelativeDirectoryPath>();

      Prop.ForAll<TestRelativeDirectoryPath, TestRelativeDirectoryPath>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // public RelativeFilePath Append(FileComponent path)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_RelativeDirectoryPath_AND_a_FileComponent
   //WHEN
   //Append
   //THEN
   //an_RelativeFilePath_containing_the_RelativeDirectoryPath_and_the_FileComponent_is_returned

   [TestMethod]
   public void
      GIVEN_a_RelativeDirectoryPath_and_a_FileComponent_WHEN_Append_THEN_an_RelativeFilePath_containing_the_RelativeDirectoryPath_and_the_FileComponent_is_returned()
   {
      static Property Property(TestRelativeDirectoryPath testChild,
                               FileComponent parent)
      {
         //Arrange
         var expected = testChild.Append(parent);

         var child = testChild.ToTetra();

         //Act
         var actual = child.Append(parent);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         expected,
                         actual);
      }

      Arb.Register<Libraries.TestRelativeDirectoryPath>();
      Arb.Register<Libraries.FileComponent>();

      Prop.ForAll<TestRelativeDirectoryPath, FileComponent>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // public RelativeFilePath Append(RelativeFilePath path)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_RelativeDirectoryPath_AND_a_RelativeFilePath
   //WHEN
   //Append
   //THEN
   //a_RelativeFilePath_containing_the_RelativeDirectoryPath_and_the_RelativeFilePath_is_returned

   [TestMethod]
   public void
      GIVEN_a_RelativeDirectoryPath_and_a_RelativeFilePath_WHEN_Append_THEN_an_RelativeFilePath_containing_the_RelativeDirectoryPath_and_the_RelativeFilePath_is_returned()
   {
      static Property Property(TestRelativeDirectoryPath testChild,
                               TestRelativeFilePath testParent)
      {
         //Arrange
         var expected = testChild.Append(testParent);

         var child  = testChild.ToTetra();
         var parent = testParent.ToTetra();

         //Act
         var actual = child.Append(parent);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         expected,
                         actual);
      }

      Arb.Register<Libraries.TestRelativeFilePath>();
      Arb.Register<Libraries.TestRelativeDirectoryPath>();

      Prop.ForAll<TestRelativeDirectoryPath, TestRelativeFilePath>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}