using FsCheck;
using static Tetra.Testing.Properties;

namespace Check.AbsoluteDirectoryPathTests;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.AbsoluteDirectoryPath)]
public class Append
{
   /* ------------------------------------------------------------ */
   // AbsoluteDirectoryPath Append(params DirectoryComponent[] child);
   /* ------------------------------------------------------------ */

   //GIVEN
   //an_AbsoluteDirectoryPath_AND_an_Array_of_DirectoryComponents
   //WHEN
   //Append
   //THEN
   //an_AbsoluteDirectoryPath_containing_the_AbsoluteDirectoryPath_and_the_Array_of_DirectoryComponents_is_returned

   [TestMethod]
   public void
      GIVEN_an_AbsoluteDirectoryPath_and_an_Array_of_DirectoryComponents_WHEN_Append_THEN_an_AbsoluteDirectoryPath_containing_the_AbsoluteDirectoryPath_and_the_Array_of_DirectoryComponents_is_returned()
   {
      static Property Property(TestAbsoluteDirectoryPath testParent,
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
      Arb.Register<Libraries.TestAbsoluteDirectoryPath>();

      Prop.ForAll<TestAbsoluteDirectoryPath, DirectoryComponent[]>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // AbsoluteDirectoryPath Append(IEnumerable<DirectoryComponent> child);
   /* ------------------------------------------------------------ */

   //GIVEN
   //an_AbsoluteDirectoryPath_AND_a_sequence_of_DirectoryComponents
   //WHEN
   //Append
   //THEN
   //an_AbsoluteDirectoryPath_containing_the_AbsoluteDirectoryPath_and_the_sequence_of_DirectoryComponents_is_returned

   [TestMethod]
   public void
      GIVEN_an_AbsoluteDirectoryPath_and_a_sequence_of_DirectoryComponents_WHEN_Append_THEN_an_AbsoluteDirectoryPath_containing_the_AbsoluteDirectoryPath_and_the_sequence_of_DirectoryComponents_is_returned()
   {
      static Property Property(TestAbsoluteDirectoryPath     testParent,
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
      Arb.Register<Libraries.TestAbsoluteDirectoryPath>();

      Prop.ForAll<TestAbsoluteDirectoryPath, ISequence<DirectoryComponent>>(Property)
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
   public void
      GIVEN_an_AbsoluteDirectoryPath_and_a_RelativeDirectoryPath_WHEN_Append_THEN_an_AbsoluteDirectoryPath_containing_the_AbsoluteDirectoryPath_and_the_RelativeDirectoryPath_is_returned()
   {
      static Property Property(TestAbsoluteDirectoryPath testParent,
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
      static Property Property(TestAbsoluteDirectoryPath testParent,
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
   public void
      GIVEN_an_AbsoluteDirectoryPath_and_a_RelativeFilePath_WHEN_Append_THEN_an_AbsoluteFilePath_containing_the_AbsoluteDirectoryPath_and_the_RelativeFilePath_is_returned()
   {
      static Property Property(TestAbsoluteDirectoryPath testParent,
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

      Arb.Register<Libraries.TestAbsoluteDirectoryPath>();
      Arb.Register<Libraries.TestRelativeFilePath>();

      Prop.ForAll<TestAbsoluteDirectoryPath, TestRelativeFilePath>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}