using FsCheck;
using static Tetra.Testing.Properties;

namespace Check.RelativeFilePathTests;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.RelativeFilePath)]
public class Parent
{
   /* ------------------------------------------------------------ */
   // public Option<RelativeDirectoryPath> Parent()
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_RelativeFilePath_containing_no_directories
   //WHEN
   //Parent
   //THEN
   //a_none_is_returned

   [TestMethod]
   public void GIVEN_a_RelativeFilePath_containing_no_directories_WHEN_Parent_THEN_a_none_is_returned()
   {
      static Property Property(FileComponent file)
      {
         //Arrange
         var path = RelativeFilePath.Create(Sequence<DirectoryComponent>.Empty(),
                                            file);

         //Act
         var actual = path.Parent();

         //Assert
         return IsANone(AssertMessages.ReturnValue,
                        actual);
      }

      Arb.Register<Libraries.FileComponent>();

      Prop.ForAll<FileComponent>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //a_RelativeFilePath_containing_more_than_one_directory
   //WHEN
   //Parent
   //THEN
   //a_RelativeDirectoryPath_containing_the_parent_directory_is_returned

   [TestMethod]
   public void GIVEN_a_RelativeFilePath_containing_more_than_one_directory_WHEN_Parent_THEN_a_RelativeDirectoryPath_containing_the_parent_directory_is_returned()
   {
      static Property Property(ISequence<DirectoryComponent> directories,
                               FileComponent                 file)
      {
         //Arrange
         var expected = TestRelativeDirectoryPath.Create(directories);

         var path = RelativeFilePath.Create(directories,
                                            file);

         //Act
         var actual = path.Parent();

         //Assert
         return IsASomeAnd(AssertMessages.ReturnValue,
                           (description,
                            actualParent) => AreEqual(description,
                                                      expected,
                                                      actualParent),
                           actual);
      }

      Arb.Register<Libraries.NonEmptySequenceOfDirectoryComponents>();
      Arb.Register<Libraries.FileComponent>();

      Prop.ForAll<ISequence<DirectoryComponent>, FileComponent>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}