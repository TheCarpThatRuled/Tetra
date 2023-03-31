using FsCheck;
using static Tetra.Testing.Properties;

namespace Check.DirectoryComponentTests;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.DirectoryComponent)]
public class Append
{
   /* ------------------------------------------------------------ */
   // public RelativeDirectoryPath Append(params DirectoryComponent[] child)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_DirectoryComponent_AND_an_Array_of_DirectoryComponents
   //WHEN
   //Append
   //THEN
   //a_RelativeDirectoryPath_containing_the_DirectoryComponent_and_the_Array_of_DirectoryComponents_is_returned

   [TestMethod]
   public void
      GIVEN_a_DirectoryComponent_and_an_Array_of_DirectoryComponents_WHEN_Append_THEN_a_RelativeDirectoryPath_containing_the_DirectoryComponent_and_the_Array_of_DirectoryComponents_is_returned()
   {
      static Property Property(DirectoryComponent   parent,
                               DirectoryComponent[] child)
      {
         //Arrange
         var expected = TestRelativeDirectoryPath.Create(child
                                                        .Prepend(parent)
                                                        .ToArray());

         //Act
         var actual = parent.Append(child);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         expected,
                         actual);
      }

      Arb.Register<Libraries.DirectoryComponent>();

      Prop.ForAll<DirectoryComponent, DirectoryComponent[]>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // public RelativeDirectoryPath Append(ISequence<DirectoryComponent> child)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_DirectoryComponent_AND_a_sequence_of_DirectoryComponents
   //WHEN
   //Append
   //THEN
   //a_RelativeDirectoryPath_containing_the_DirectoryComponent_and_the_sequence_of_DirectoryComponents_is_returned

   [TestMethod]
   public void
      GIVEN_a_DirectoryComponent_and_a_sequence_of_DirectoryComponents_WHEN_Append_THEN_a_RelativeDirectoryPath_containing_the_DirectoryComponent_and_the_sequence_of_DirectoryComponents_is_returned()
   {
      static Property Property(DirectoryComponent            parent,
                               ISequence<DirectoryComponent> child)
      {
         //Arrange
         var expected = TestRelativeDirectoryPath.Create(child
                                                        .Prepend(parent)
                                                        .ToArray());

         //Act
         var actual = parent.Append(child);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         expected,
                         actual);
      }

      Arb.Register<Libraries.DirectoryComponent>();
      Arb.Register<Libraries.SequenceOfDirectoryComponents>();

      Prop.ForAll<DirectoryComponent, ISequence<DirectoryComponent>>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // public RelativeDirectoryPath Append(RelativeDirectoryPath child)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_DirectoryComponent_and_a_RelativeDirectoryPat
   //WHEN
   //Append
   //THEN
   //a_RelativeDirectoryPath_containing_the_DirectoryComponent_and_the_RelativeDirectoryPath_is_returned

   [TestMethod]
   public void
      GIVEN_a_DirectoryComponent_and_a_RelativeDirectoryPath_WHEN_Append_THEN_a_RelativeDirectoryPath_containing_the_DirectoryComponent_and_the_RelativeDirectoryPath_is_returned()
   {
      static Property Property(DirectoryComponent        parent,
                               TestRelativeDirectoryPath testChild)
      {
         //Arrange
         var expected = testChild.Prepend(parent);

         var child = testChild.ToTetra();

         //Act
         var actual = parent.Append(child);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         expected,
                         actual);
      }

      Arb.Register<Libraries.TestRelativeDirectoryPath>();
      Arb.Register<Libraries.DirectoryComponent>();

      Prop.ForAll<DirectoryComponent, TestRelativeDirectoryPath>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // public RelativeFilePath Append(FileComponent child)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_DirectoryComponent_AND_a_FileComponent
   //WHEN
   //Append
   //THEN
   //a_RelativeFilePath_containing_the_DirectoryComponent_and_the_FileComponent_is_returned

   [TestMethod]
   public void GIVEN_a_DirectoryComponent_AND_a_FileComponent_WHEN_Append_THEN_a_RelativeFilePath_containing_the_DirectoryComponent_and_the_FileComponent_is_returned()
   {
      static Property Property(DirectoryComponent parent,
                               FileComponent      child)
      {
         //Arrange
         var expected = TestRelativeFilePath.Create(Sequence.From(parent),
                                                    child);

         //Act
         var actual = parent.Append(child);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         expected,
                         actual);
      }

      Arb.Register<Libraries.DirectoryComponent>();
      Arb.Register<Libraries.FileComponent>();

      Prop.ForAll<DirectoryComponent, FileComponent>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // public RelativeFilePath Append(RelativeFilePath child)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_DirectoryComponent_AND_a_RelativeFilePath
   //WHEN
   //Append
   //THEN
   //a_RelativeFilePath_containing_the_DirectoryComponent_and_the_RelativeFilePath_is_returned

   [TestMethod]
   public void GIVEN_a_DirectoryComponent_and_a_RelativeFilePath_WHEN_Append_THEN_a_RelativeFilePath_containing_the_DirectoryComponent_and_the_RelativeFilePath_is_returned()
   {
      static Property Property(DirectoryComponent   parent,
                               TestRelativeFilePath testChild)
      {
         //Arrange
         var expected = testChild.Prepend(Sequence.From(parent));

         var child = testChild.ToTetra();

         //Act
         var actual = parent.Append(child);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         expected,
                         actual);
      }

      Arb.Register<Libraries.TestRelativeFilePath>();
      Arb.Register<Libraries.DirectoryComponent>();

      Prop.ForAll<DirectoryComponent, TestRelativeFilePath>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}