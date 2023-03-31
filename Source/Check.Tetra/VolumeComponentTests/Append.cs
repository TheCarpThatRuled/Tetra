using FsCheck;
using static Tetra.Testing.Properties;

namespace Check.VolumeComponentTests;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.VolumeComponent)]
public class Append
{
   /* ------------------------------------------------------------ */
   // public AbsoluteDirectoryPath Append(params DirectoryComponent[] child)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_VolumeComponent_AND_an_Array_of_DirectoryComponents
   //WHEN
   //Append
   //THEN
   //an_AbsoluteDirectoryPath_containing_the_VolumeComponent_and_the_Array_of_DirectoryComponents_is_returned

   [TestMethod]
   public void
      GIVEN_a_VolumeComponent_and_an_Array_of_DirectoryComponents_WHEN_Append_THEN_an_AbsoluteDirectoryPath_containing_the_VolumeComponent_and_the_Array_of_DirectoryComponents_is_returned()
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
         return AreEqual(AssertMessages.ReturnValue,
                         expected,
                         actual);
      }

      Arb.Register<Libraries.DirectoryComponent>();
      Arb.Register<Libraries.VolumeComponent>();

      Prop.ForAll<VolumeComponent, DirectoryComponent[]>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // public static AbsoluteDirectoryPath Append(this VolumeComponent parent,
   //                                            ISequence<DirectoryComponent> child)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_VolumeComponent_AND_a_sequence_of_DirectoryComponents
   //WHEN
   //Append
   //THEN
   //an_AbsoluteDirectoryPath_containing_the_VolumeComponent_and_the_sequence_of_DirectoryComponents_is_returned

   [TestMethod]
   public void
      GIVEN_a_VolumeComponent_and_a_sequence_of_DirectoryComponents_WHEN_Append_THEN_an_AbsoluteDirectoryPath_containing_the_VolumeComponent_and_the_sequence_of_DirectoryComponents_is_returned()
   {
      static Property Property(VolumeComponent               parent,
                               ISequence<DirectoryComponent> child)
      {
         //Arrange
         var expected = TestAbsoluteDirectoryPath.Create(parent,
                                                         child);

         //Act
         var actual = parent.Append(child);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         expected,
                         actual);
      }

      Arb.Register<Libraries.SequenceOfDirectoryComponents>();
      Arb.Register<Libraries.VolumeComponent>();

      Prop.ForAll<VolumeComponent, ISequence<DirectoryComponent>>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // public AbsoluteDirectoryPath Append(RelativeDirectoryPath child)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_VolumeComponent_AND_a_RelativeDirectoryPath
   //WHEN
   //Append
   //THEN
   //an_AbsoluteDirectoryPath_containing_the_VolumeComponent_and_the_RelativeDirectoryPath_is_returned

   [TestMethod]
   public void
      GIVEN_a_VolumeComponent_and_a_RelativeDirectoryPath_WHEN_Append_THEN_an_AbsoluteDirectoryPath_containing_the_VolumeComponent_and_the_RelativeDirectoryPath_is_returned()
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
         return AreEqual(AssertMessages.ReturnValue,
                         expected,
                         actual);
      }

      Arb.Register<Libraries.TestRelativeDirectoryPath>();
      Arb.Register<Libraries.VolumeComponent>();

      Prop.ForAll<VolumeComponent, TestRelativeDirectoryPath>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // public AbsoluteFilePath Append(FileComponent child)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_VolumeComponent_AND_a_FileComponent
   //WHEN
   //Append
   //THEN
   //an_AbsoluteFilePath_containing_the_VolumeComponent_and_the_FileComponent_is_returned

   [TestMethod]
   public void GIVEN_a_VolumeComponent_and_a_FileComponent_WHEN_Append_THEN_an_AbsoluteFilePath_containing_the_VolumeComponent_and_the_FileComponent_is_returned()
   {
      static Property Property(VolumeComponent parent,
                               FileComponent   child)
      {
         //Arrange
         var expected = TestAbsoluteFilePath.Create(parent,
                                                    Sequence<DirectoryComponent>.Empty(),
                                                    child);

         //Act
         var actual = parent.Append(child);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         expected,
                         actual);
      }

      Arb.Register<Libraries.VolumeComponent>();
      Arb.Register<Libraries.FileComponent>();

      Prop.ForAll<VolumeComponent, FileComponent>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // public AbsoluteFilePath Append(RelativeFilePath child)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_VolumeComponent_AND_a_RelativeFilePath
   //WHEN
   //Append
   //THEN
   //an_AbsoluteFilePath_containing_the_VolumeComponent_and_the_RelativeFilePath_is_returned

   [TestMethod]
   public void GIVEN_a_VolumeComponent_and_a_RelativeFilePath_WHEN_Append_THEN_an_AbsoluteFilePath_containing_the_VolumeComponent_and_the_RelativeFilePath_is_returned()
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
         return AreEqual(AssertMessages.ReturnValue,
                         expected,
                         actual);
      }

      Arb.Register<Libraries.TestRelativeFilePath>();
      Arb.Register<Libraries.VolumeComponent>();

      Prop.ForAll<VolumeComponent, TestRelativeFilePath>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}