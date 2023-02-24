using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.RelativeDirectoryPathTests;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.RelativeDirectoryPath)]
public class Prepend
{
   /* ------------------------------------------------------------ */
   // public RelativeDirectoryPath Prepend(params DirectoryComponent[] parent)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_RelativeDirectoryPath_AND_an_Array_of_DirectoryComponents
   //WHEN
   //Prepend
   //THEN
   //a_RelativeDirectoryPath_containing_the_RelativeDirectoryPath_and_the_Array_of_DirectoryComponents_is_returned

   [TestMethod]
   public void
      GIVEN_a_RelativeDirectoryPath_and_an_Array_of_DirectoryComponents_WHEN_Prepend_THEN_a_RelativeDirectoryPath_containing_the_RelativeDirectoryPath_and_the_Array_of_DirectoryComponents_is_returned()
   {
      static Property Property(TestRelativeDirectoryPath testChild,
                               DirectoryComponent[]      parent)
      {
         //Arrange
         var expected = testChild.Prepend(parent);

         var child = testChild.ToTetra();

         //Act
         var actual = child.Prepend(parent);

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
   // public RelativeDirectoryPath Prepend(IEnumerable<DirectoryComponent> parent)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_RelativeDirectoryPath_AND_a_sequence_of_DirectoryComponents
   //WHEN
   //Prepend
   //THEN
   //a_RelativeDirectoryPath_containing_the_RelativeDirectoryPath_and_the_sequence_of_DirectoryComponents_is_returned

   [TestMethod]
   public void
      GIVEN_a_RelativeDirectoryPath_and_a_sequence_of_DirectoryComponents_WHEN_Prepend_THEN_a_RelativeDirectoryPath_containing_the_RelativeDirectoryPath_and_the_sequence_of_DirectoryComponents_is_returned()
   {
      static Property Property(TestRelativeDirectoryPath     testChild,
                               ISequence<DirectoryComponent> parent)
      {
         //Arrange
         var expected = testChild.Prepend(parent);

         var child = testChild.ToTetra();

         //Act
         var actual = child.Prepend(parent);

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
   // public RelativeDirectoryPath Prepend(RelativeDirectoryPath parent)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_RelativeDirectoryPath_AND_a_RelativeDirectoryPath
   //WHEN
   //Prepend
   //THEN
   //a_RelativeDirectoryPath_containing_the_RelativeDirectoryPath_and_the_RelativeDirectoryPath_is_returned

   [TestMethod]
   public void
      GIVEN_a_RelativeDirectoryPath_and_a_RelativeDirectoryPath_WHEN_Prepend_THEN_a_RelativeDirectoryPath_containing_the_RelativeDirectoryPath_and_the_RelativeDirectoryPath_is_returned()
   {
      static Property Property(TestRelativeDirectoryPath testChild,
                               TestRelativeDirectoryPath testParent)
      {
         //Arrange
         var expected = testChild.Prepend(testParent);

         var child  = testChild.ToTetra();
         var parent = testParent.ToTetra();

         //Act
         var actual = child.Prepend(parent);

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
   // public AbsoluteDirectoryPath Prepend(VolumeComponent parent)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_RelativeDirectoryPath_AND_a_VolumeComponent
   //WHEN
   //Prepend
   //THEN
   //an_AbsoluteDirectoryPath_containing_the_RelativeDirectoryPath_and_the_VolumeComponent_is_returned

   [TestMethod]
   public void
      GIVEN_a_RelativeDirectoryPath_and_a_VolumeComponent_WHEN_Prepend_THEN_an_AbsoluteDirectoryPath_containing_the_RelativeDirectoryPath_and_the_VolumeComponent_is_returned()
   {
      static Property Property(TestRelativeDirectoryPath testChild,
                               VolumeComponent           parent)
      {
         //Arrange
         var expected = testChild.Prepend(parent);

         var child = testChild.ToTetra();

         //Act
         var actual = child.Prepend(parent);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         expected,
                         actual);
      }

      Arb.Register<Libraries.TestRelativeDirectoryPath>();
      Arb.Register<Libraries.VolumeComponent>();

      Prop.ForAll<TestRelativeDirectoryPath, VolumeComponent>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // public AbsoluteDirectoryPath Prepend(AbsoluteDirectoryPath parent)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_RelativeDirectoryPath_AND_a_AbsoluteDirectoryPath
   //WHEN
   //Prepend
   //THEN
   //an_AbsoluteDirectoryPath_containing_the_RelativeDirectoryPath_and_the_AbsoluteDirectoryPath_is_returned

   [TestMethod]
   public void
      GIVEN_a_RelativeDirectoryPath_and_a_AbsoluteDirectoryPath_WHEN_Prepend_THEN_an_AbsoluteDirectoryPath_containing_the_RelativeDirectoryPath_and_the_AbsoluteDirectoryPath_is_returned()
   {
      static Property Property(TestRelativeDirectoryPath testChild,
                               TestAbsoluteDirectoryPath testParent)
      {
         //Arrange
         var expected = testChild.Prepend(testParent);

         var child  = testChild.ToTetra();
         var parent = testParent.ToTetra();

         //Act
         var actual = child.Prepend(parent);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         expected,
                         actual);
      }

      Arb.Register<Libraries.TestAbsoluteDirectoryPath>();
      Arb.Register<Libraries.TestRelativeDirectoryPath>();

      Prop.ForAll<TestRelativeDirectoryPath, TestAbsoluteDirectoryPath>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}