﻿using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.EitherTests.OfIntAndTestClass;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.Either)]
// ReSharper disable once InconsistentNaming
public class Right_ToString
{
   /* ------------------------------------------------------------ */
   // public string ToString()
   /* ------------------------------------------------------------ */

   //GIVEN
   //Right_of_TestClass
   //WHEN
   //ToString
   //THEN
   //Right_brackets_the_content_to_string_is_returned

   [TestMethod]
   public void GIVEN_Right_of_TestClass_WHEN_ToString_THEN_Right_brackets_the_content_to_string_is_returned()
   {
      static Property Property(TestClass content)
      {
         //Arrange
         var result = Either<TestClass, TestClass>.Right(content);

         //Act
         var actual = result.ToString();

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         $"Right ({content})",
                         actual);
      }

      Arb.Register<Libraries.TestClass>();

      Prop.ForAll<TestClass>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}