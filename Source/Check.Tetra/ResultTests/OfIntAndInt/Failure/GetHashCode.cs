﻿using FsCheck;
using static Tetra.Testing.Properties;

namespace Check.ResultTests.OfIntAndInt;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.Result)]
// ReSharper disable once InconsistentNaming
public class Failure_GetHashCode
{
   /* ------------------------------------------------------------ */
   // int GetHashCode();
   /* ------------------------------------------------------------ */

   //GIVEN
   //Failure_of_int
   //WHEN
   //GetHashCode
   //THEN
   //the_hash_code_of_the_content_is_returned

   [TestMethod]
   public void GIVEN_Failure_of_int_WHEN_GetHashCode_THEN_the_hash_code_of_the_content_is_returned()
   {
      static Property Property(int content)
      {
         //Arrange
         var result = Result<int, int>.Failure(content);

         //Act
         var actual = result.GetHashCode();

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         content.GetHashCode(),
                         actual);
      }

      Prop.ForAll<int>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}