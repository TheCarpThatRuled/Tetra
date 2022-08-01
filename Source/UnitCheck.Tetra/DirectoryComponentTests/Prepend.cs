using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.DirectoryComponentTests;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.DirectoryComponent)]
public class Prepend
{
   /* ------------------------------------------------------------ */
   // public static AbsoluteDirectoryPath Prepend(this DirectoryComponent,
   //                                             VolumeComponent volume)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_DirectoryComponent_AND_an_AbsoluteDirectoryPath
   //WHEN
   //Prepend
   //THEN
   //an_AbsoluteDirectoryPath_containing_the_AbsoluteDirectoryPath_and_the_DirectoryComponent_is_returned

   [TestMethod]
   public void GIVEN_a_DirectoryComponent_and_an_AbsoluteDirectoryPath_WHEN_Prepend_THEN_an_AbsoluteDirectoryPath_containing_the_AbsoluteDirectoryPath_and_the_DirectoryComponent_is_returned()
   {
      static Property Property(DirectoryComponent child,
                               TestAbsoluteDirectoryPath testParent)
      {
         //Arrange
         var expected = testParent.Append(new[] {child,});

         var parent = testParent.ToTetra();

         //Act
         var actual = child.Prepend(parent);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         expected,
                         actual);
      }

      Arb.Register<Libraries.DirectoryComponent>();
      Arb.Register<Libraries.TestAbsoluteDirectoryPath>();

      Prop.ForAll<DirectoryComponent, TestAbsoluteDirectoryPath>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // public static RelativeDirectoryPath Prepend(this DirectoryComponent parent,
   //                                             params DirectoryComponent[] child)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_DirectoryComponent_AND_an_Array_of_DirectoryComponents
   //WHEN
   //Prepend
   //THEN
   //a_RelativeDirectoryPath_containing_the_DirectoryComponent_and_the_Array_of_DirectoryComponents_is_returned

   [TestMethod]
   public void
      GIVEN_a_DirectoryComponent_and_an_Array_of_DirectoryComponents_WHEN_Prepend_THEN_a_RelativeDirectoryPath_containing_the_DirectoryComponent_and_the_Array_of_DirectoryComponents_is_returned()
   {
      static Property Property(DirectoryComponent parent,
                               DirectoryComponent[] child)
      {
         //Arrange
         var expected = TestRelativeDirectoryPath.Create(child
                                                        .Append(parent)
                                                        .ToArray());

         //Act
         var actual = parent.Prepend(child);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         expected,
                         actual);
      }

      Arb.Register<Libraries.ArrayOfDirectoryComponents>();
      Arb.Register<Libraries.DirectoryComponent>();

      Prop.ForAll<DirectoryComponent, DirectoryComponent[]>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // public static RelativeDirectoryPath Prepend(this DirectoryComponent parent,
   //                                             IReadOnlyCollection<DirectoryComponent> child)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_DirectoryComponent_AND_a_sequence_of_DirectoryComponents
   //WHEN
   //Prepend
   //THEN
   //a_RelativeDirectoryPath_containing_the_DirectoryComponent_and_the_sequence_of_DirectoryComponents_is_returned

   [TestMethod]
   public void
      GIVEN_a_DirectoryComponent_and_a_sequence_of_DirectoryComponents_WHEN_Prepend_THEN_a_RelativeDirectoryPath_containing_the_DirectoryComponent_and_the_sequence_of_DirectoryComponents_is_returned()
   {
      static Property Property(DirectoryComponent parent,
                               List<DirectoryComponent> child)
      {
         //Arrange
         var expected = TestRelativeDirectoryPath.Create(child
                                                        .Append(parent)
                                                        .ToArray());

         //Act
         var actual = parent.Prepend(child);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         expected,
                         actual);
      }

      Arb.Register<Libraries.DirectoryComponent>();
      Arb.Register<Libraries.ListOfDirectoryComponents>();

      Prop.ForAll<DirectoryComponent, List<DirectoryComponent>>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // public static RelativeDirectoryPath Prepend(this DirectoryComponent parent,
   //                                            RelativeDirectoryPath child)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_DirectoryComponent_and_a_RelativeDirectoryPat
   //WHEN
   //Prepend
   //THEN
   //a_RelativeDirectoryPath_containing_the_DirectoryComponent_and_the_RelativeDirectoryPath_is_returned

   [TestMethod]
   public void

      GIVEN_a_DirectoryComponent_and_a_RelativeDirectoryPath_WHEN_Prepend_THEN_a_RelativeDirectoryPath_containing_the_DirectoryComponent_and_the_RelativeDirectoryPath_is_returned()
   {
      static Property Property(DirectoryComponent child,
                               TestRelativeDirectoryPath testParent)
      {
         //Arrange
         var expected = testParent.Append(new[] {child,});

         var parent = testParent.ToTetra();

         //Act
         var actual = child.Prepend(parent);

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
   // public static AbsoluteDirectoryPath Prepend(this DirectoryComponent,
   //                                             VolumeComponent volume)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_DirectoryComponent_AND_a_VolumeComponent
   //WHEN
   //Prepend
   //THEN
   //an_AbsoluteDirectoryPath_containing_the_VolumeComponent_and_the_DirectoryComponent_is_returned

   [TestMethod]
   public void GIVEN_a_DirectoryComponent_and_a_VolumeComponent_WHEN_Prepend_THEN_an_AbsoluteDirectoryPath_containing_the_VolumeComponent_and_the_DirectoryComponent_is_returned()
   {
      static Property Property(DirectoryComponent child,
                               VolumeComponent    parent)
      {
         //Arrange
         var expected = TestAbsoluteDirectoryPath.Create(parent,
                                                         child);

         //Act
         var actual = child.Prepend(parent);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         expected,
                         actual);
      }

      Arb.Register<Libraries.DirectoryComponent>();
      Arb.Register<Libraries.VolumeComponent>();

      Prop.ForAll<DirectoryComponent, VolumeComponent>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}