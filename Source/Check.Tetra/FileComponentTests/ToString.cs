﻿using FsCheck;
using static Tetra.Testing.Properties;

namespace Check.FileComponentTests;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.FileComponent)]
// ReSharper disable once InconsistentNaming
public class ToString
{
   /* ------------------------------------------------------------ */
   // public string ToString()
   /* ------------------------------------------------------------ */

   //GIVEN
   //FileComponent
   //WHEN
   //ToString
   //THEN
   //the_value_bounded_by_angle_brackets_is_returned

   [TestMethod]
   public void GIVEN_FileComponent_WHEN_ToString_THEN_the_value_bounded_by_angle_brackets_is_returned()
   {
      static Property Property
      (
         string value
      )
      {
         //Arrange
         var fileComponent = FileComponent.Create(value);

         //Act
         var actual = fileComponent.ToString();

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         $"<{value}>",
                         actual);
      }

      Arb.Register<Libraries.ValidPathComponent>();

      Prop.ForAll<string>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}