using FsCheck;
using static Tetra.Testing.Properties;

namespace Check.FileComponentTests;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.FileComponent)]
public class Prepend
{
   /* ------------------------------------------------------------ */
   // public AbsoluteDirectoryPath Prepend(VolumeComponent parent)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_FileComponent_AND_an_AbsoluteDirectoryPath
   //WHEN
   //Prepend
   //THEN
   //an_AbsoluteFilePath_containing_the_AbsoluteDirectoryPath_and_the_FileComponent_is_returned

   [TestMethod]
   public void GIVEN_a_FileComponent_and_an_AbsoluteDirectoryPath_WHEN_Prepend_THEN_an_AbsoluteFilePath_containing_the_AbsoluteDirectoryPath_and_the_FileComponent_is_returned()
   {
      static Property Property
      (
         FileComponent             child,
         TestAbsoluteDirectoryPath testParent
      )
      {
         //Arrange
         var expected = testParent.Append(child);

         var parent = testParent.ToTetra();

         //Act
         var actual = child.Prepend(parent);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         expected,
                         actual);
      }

      Arb.Register<Libraries.FileComponent>();
      Arb.Register<Libraries.TestAbsoluteDirectoryPath>();

      Prop.ForAll<FileComponent, TestAbsoluteDirectoryPath>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // public RelativeDirectoryPath Prepend(params DirectoryComponent[] child)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_FileComponent_AND_an_Array_of_DirectoryComponents
   //WHEN
   //Prepend
   //THEN
   //a_RelativeFilePath_containing_the_FileComponent_and_the_Array_of_DirectoryComponents_is_returned

   [TestMethod]
   public void
      GIVEN_a_FileComponent_and_an_Array_of_DirectoryComponents_WHEN_Prepend_THEN_a_RelativeFilePath_containing_the_FileComponent_and_the_Array_of_DirectoryComponents_is_returned()
   {
      static Property Property
      (
         FileComponent        child,
         DirectoryComponent[] parent
      )
      {
         //Arrange
         var expected = TestRelativeFilePath.Create(parent.Materialise(),
                                                    child);

         //Act
         var actual = child.Prepend(parent);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         expected,
                         actual);
      }

      Arb.Register<Libraries.DirectoryComponent>();
      Arb.Register<Libraries.FileComponent>();

      Prop.ForAll<FileComponent, DirectoryComponent[]>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // public RelativeDirectoryPath Prepend(IReadOnlyCollection<DirectoryComponent> child)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_FileComponent_AND_a_sequence_of_DirectoryComponents
   //WHEN
   //Prepend
   //THEN
   //a_RelativeFilePath_containing_the_FileComponent_and_the_sequence_of_DirectoryComponents_is_returned

   [TestMethod]
   public void
      GIVEN_a_FileComponent_and_a_sequence_of_DirectoryComponents_WHEN_Prepend_THEN_a_RelativeFilePath_containing_the_FileComponent_and_the_sequence_of_DirectoryComponents_is_returned()
   {
      static Property Property
      (
         FileComponent                 child,
         ISequence<DirectoryComponent> parent
      )
      {
         //Arrange
         var expected = TestRelativeFilePath.Create(parent,
                                                    child);

         //Act
         var actual = child.Prepend(parent);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         expected,
                         actual);
      }

      Arb.Register<Libraries.FileComponent>();
      Arb.Register<Libraries.SequenceOfDirectoryComponents>();

      Prop.ForAll<FileComponent, ISequence<DirectoryComponent>>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // public RelativeDirectoryPath Prepend(RelativeDirectoryPath child)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_FileComponent_and_a_RelativeDirectoryPath
   //WHEN
   //Prepend
   //THEN
   //a_RelativeFilePath_containing_the_FileComponent_and_the_RelativeDirectoryPath_is_returned

   [TestMethod]
   public void
      GIVEN_a_FileComponent_and_a_RelativeDirectoryPath_WHEN_Prepend_THEN_a_RelativeFilePath_containing_the_FileComponent_and_the_RelativeDirectoryPath_is_returned()
   {
      static Property Property
      (
         FileComponent             child,
         TestRelativeDirectoryPath testParent
      )
      {
         //Arrange
         var expected = testParent.Append(child);

         var parent = testParent.ToTetra();

         //Act
         var actual = child.Prepend(parent);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         expected,
                         actual);
      }

      Arb.Register<Libraries.TestRelativeDirectoryPath>();
      Arb.Register<Libraries.FileComponent>();

      Prop.ForAll<FileComponent, TestRelativeDirectoryPath>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // public AbsoluteFilePath Append(VolumeComponent volume)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_FileComponent_AND_a_VolumeComponent
   //WHEN
   //Prepend
   //THEN
   //an_AbsoluteFilePath_Containing_the_VolumeComponent_and_the_FileComponent_is_returned

   [TestMethod]
   public void GIVEN_a_FileComponent_AND_a_VolumeComponent_WHEN_Prepend_THEN_an_AbsoluteFilePath_Containing_the_VolumeComponent_and_the_FileComponent_is_returned()
   {
      static Property Property
      (
         FileComponent   child,
         VolumeComponent parent
      )
      {
         //Arrange
         var expected = TestAbsoluteFilePath.Create(parent,
                                                    Sequence<DirectoryComponent>.Empty(),
                                                    child);

         //Act
         var actual = child.Prepend(parent);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         expected,
                         actual);
      }

      Arb.Register<Libraries.FileComponent>();
      Arb.Register<Libraries.VolumeComponent>();

      Prop.ForAll<FileComponent, VolumeComponent>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}