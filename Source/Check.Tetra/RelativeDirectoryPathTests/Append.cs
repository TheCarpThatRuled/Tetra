using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.RelativeDirectoryPathTests;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.RelativeDirectoryPath)]
public class Append
{
   /* ------------------------------------------------------------ */
   // public RelativeDirectoryPath Append(params DirectoryComponent[] child)
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
      static Property Property(TestRelativeDirectoryPath testParent,
                               DirectoryComponent[]      child)
      {
         //Arrange
         var expected = testParent.Append(child);

         var parent = testParent.ToTetra();

         //Act
         var actual = parent.Append(child);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         expected,
                         actual);
      }

      Arb.Register<Libraries.DirectoryComponent>();
      Arb.Register<Libraries.TestRelativeDirectoryPath>();

      Prop.ForAll<TestRelativeDirectoryPath, DirectoryComponent[]>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // public RelativeDirectoryPath Append(IEnumerable<DirectoryComponent> child)
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
      static Property Property(TestRelativeDirectoryPath     testParent,
                               ISequence<DirectoryComponent> child)
      {
         //Arrange
         var expected = testParent.Append(child);

         var parent = testParent.ToTetra();

         //Act
         var actual = parent.Append(child);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         expected,
                         actual);
      }

      Arb.Register<Libraries.SequenceOfDirectoryComponents>();
      Arb.Register<Libraries.TestRelativeDirectoryPath>();

      Prop.ForAll<TestRelativeDirectoryPath, ISequence<DirectoryComponent>>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // public RelativeDirectoryPath Append(RelativeDirectoryPath child)
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
      static Property Property(TestRelativeDirectoryPath testParent,
                               TestRelativeDirectoryPath testChild)
      {
         //Arrange
         var expected = testParent.Append(testChild);

         var parent = testParent.ToTetra();
         var child  = testChild.ToTetra();

         //Act
         var actual = parent.Append(child);

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
   // public RelativeFilePath Append(FileComponent child)
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
      static Property Property(TestRelativeDirectoryPath testParent,
                               FileComponent             child)
      {
         //Arrange
         var expected = testParent.Append(child);

         var parent = testParent.ToTetra();

         //Act
         var actual = parent.Append(child);

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
   // public RelativeFilePath Append(RelativeFilePath child)
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
      static Property Property(TestRelativeDirectoryPath testParent,
                               TestRelativeFilePath      testChild)
      {
         //Arrange
         var expected = testParent.Append(testChild);

         var parent = testParent.ToTetra();
         var child  = testChild.ToTetra();

         //Act
         var actual = parent.Append(child);

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