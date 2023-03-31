﻿using FsCheck;
using static Tetra.Testing.Properties;

namespace Check.ResultTests.OfTestStruct;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.Result)]
// ReSharper disable once InconsistentNaming
public class Failure_IsASuccess
{
   /* ------------------------------------------------------------ */
   // bool IsASuccess();
   /* ------------------------------------------------------------ */

   //GIVEN
   //Failure_of_TestStruct
   //WHEN
   //IsASuccess
   //THEN
   //false_is_returned

   [TestMethod]
   public void GIVEN_Failure_of_TestStruct_WHEN_IsASuccess_THEN_false_is_returned()
   {
      static Property Property(TestStruct value)
      {
         //Arrange
         var result = Tetra.Result.Failure(value);

         //Act
         var actual = result.IsASuccess();

         //Assert
         return IsFalse(AssertMessages.ReturnValue,
                        actual);
      }

      Arb.Register<Libraries.TestStruct>();

      Prop.ForAll<TestStruct>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}