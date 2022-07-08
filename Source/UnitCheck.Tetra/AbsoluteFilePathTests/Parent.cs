﻿using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.AbsoluteFilePathTests;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.AbsoluteFilePath)]
public class Parent
{
   /* ------------------------------------------------------------ */
   // AbsoluteDirectoryPath Parent()
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_AbsoluteFilePath
   //WHEN
   //Parent
   //THEN
   //a_AbsoluteDirectoryPath_containing_the_parent_directory_is_returned

   [TestMethod]
   public void GIVEN_a_AbsoluteFilePath_WHEN_Parent_THEN_a_AbsoluteDirectoryPath_containing_the_parent_directory_is_returned()
   {
      static Property Property(Volume               volume,
                               DirectoryComponent[] directories,
                               FileComponent        file)
      {
         //Arrange
         var path = AbsoluteFilePath.Create(volume,
                                            directories,
                                            file);
         var expected = directories
                       .Select(x => x.Value())
                       .Prepend(volume.Value())
                       .Aggregate(string.Empty,
                                  (total,
                                   next) => $"{total}{next}{Path.DirectorySeparatorChar}");

         //Act
         var actual = path.Parent();

         //Assert
         return AreEqual(expected,
                         actual.Value());
      }

      Arb.Register<Libraries.Volume>();
      Arb.Register<Libraries.ArrayOfDirectoryComponents>();
      Arb.Register<Libraries.FileComponent>();

      Prop.ForAll<Volume, DirectoryComponent[], FileComponent>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}