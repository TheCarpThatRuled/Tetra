using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.RelativeFilePathTests;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.RelativeFilePath)]
public class Prepend
{
   /* ------------------------------------------------------------ */
   // public RelativeFilePath Prepend(params DirectoryComponent[] directories)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_RelativeFilePath_AND_an_Array_of_DirectoryComponents
   //WHEN
   //Prepend
   //THEN
   //a_RelativeFilePath_with_a_value_of_the_combine_path_is_returned

   [TestMethod]
   public void GIVEN_a_RelativeFilePath_and_an_Array_of_DirectoryComponents_WHEN_Prepend_THEN_a_RelativeFilePath_with_a_value_of_the_combine_path_is_returned()
   {
      static Property Property(TestRelativeFilePath testChild,
                               DirectoryComponent[] parent)
      {
         //Arrange
         var expected = testChild.Prepend(parent);

         var child = testChild.ToTetra();

         //Act
         var actual = child.Prepend(parent);

         //Assert
         return AreEqual("Prepend",
                         expected,
                         actual);
      }

      Arb.Register<Libraries.ArrayOfDirectoryComponents>();
      Arb.Register<Libraries.TestRelativeFilePath>();

      Prop.ForAll<TestRelativeFilePath, DirectoryComponent[]>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // public RelativeFilePath Prepend(IReadOnlyCollection<DirectoryComponent> directories)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_RelativeFilePath_AND_a_sequence_of_DirectoryComponents
   //WHEN
   //Prepend
   //THEN
   //a_RelativeFilePath_with_a_value_of_the_combine_path_is_returned

   [TestMethod]
   public void GIVEN_a_RelativeFilePath_and_a_sequence_of_DirectoryComponents_WHEN_Prepend_THEN_a_RelativeFilePath_with_a_value_of_the_combine_path_is_returned()
   {
      static Property Property(TestRelativeFilePath     testChild,
                               List<DirectoryComponent> parent)
      {
         //Arrange
         var expected = testChild.Prepend(parent);

         var child = testChild.ToTetra();

         //Act
         var actual = child.Prepend(parent);

         //Assert
         return AreEqual("Prepend",
                         expected,
                         actual);
      }

      Arb.Register<Libraries.ListOfDirectoryComponents>();
      Arb.Register<Libraries.TestRelativeFilePath>();

      Prop.ForAll<TestRelativeFilePath, List<DirectoryComponent>>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // public RelativeFilePath Prepend(RelativeDirectoryPath path)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_RelativeFilePath_AND_a_RelativeDirectoryPath
   //WHEN
   //Prepend
   //THEN
   //a_RelativeFilePath_with_a_value_of_the_combine_path_is_returned

   [TestMethod]
   public void GIVEN_a_RelativeFilePath_and_a_RelativeDirectoryPath_WHEN_Prepend_THEN_a_RelativeFilePath_with_a_value_of_the_combine_path_is_returned()
   {
      static Property Property(TestRelativeFilePath      testChild,
                               TestRelativeDirectoryPath testParent)
      {
         //Arrange
         var expected = testChild.Prepend(testParent);

         var child  = testChild.ToTetra();
         var parent = testParent.ToTetra();

         //Act
         var actual = child.Prepend(parent);

         //Assert
         return AreEqual("Prepend",
                         expected,
                         actual);
      }

      Arb.Register<Libraries.TestRelativeDirectoryPath>();
      Arb.Register<Libraries.TestRelativeFilePath>();

      Prop.ForAll<TestRelativeFilePath, TestRelativeDirectoryPath>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // public AbsoluteFilePath Prepend(VolumeComponent path)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_RelativeFilePath_AND_a_VolumeComponent
   //WHEN
   //Prepend
   //THEN
   //a_AbsoluteFilePath_with_a_value_of_the_combine_path_is_returned

   [TestMethod]
   public void GIVEN_a_RelativeFilePath_and_a_VolumeComponent_WHEN_Prepend_THEN_an_AbsoluteFilePath_with_a_value_of_the_combine_path_is_returned()
   {
      static Property Property(TestRelativeFilePath testChild,
                               VolumeComponent      parent)
      {
         //Arrange
         var expected = testChild.Prepend(parent);

         var child = testChild.ToTetra();

         //Act
         var actual = child.Prepend(parent);

         //Assert
         return AreEqual("Parse",
                         expected,
                         actual);
      }

      Arb.Register<Libraries.TestRelativeFilePath>();
      Arb.Register<Libraries.VolumeComponent>();

      Prop.ForAll<TestRelativeFilePath, VolumeComponent>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // public AbsoluteFilePath Prepend(AbsoluteDirectoryPath path)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_RelativeFilePath_AND_a_AbsoluteDirectoryPath
   //WHEN
   //Prepend
   //THEN
   //a_AbsoluteFilePath_with_a_value_of_the_combine_path_is_returned

   [TestMethod]
   public void GIVEN_a_RelativeFilePath_and_a_AbsoluteDirectoryPath_WHEN_Prepend_THEN_an_AbsoluteFilePath_with_a_value_of_the_combine_path_is_returned()
   {
      static Property Property(TestRelativeFilePath      testChild,
                               TestAbsoluteDirectoryPath testParent)
      {
         //Arrange
         var expected = testChild.Prepend(testParent);

         var child  = testChild.ToTetra();
         var parent = testParent.ToTetra();

         //Act
         var actual = child.Prepend(parent);

         //Assert
         return AreEqual("Parse",
                         expected,
                         actual);
      }

      Arb.Register<Libraries.TestAbsoluteDirectoryPath>();
      Arb.Register<Libraries.TestRelativeFilePath>();

      Prop.ForAll<TestRelativeFilePath, TestAbsoluteDirectoryPath>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}