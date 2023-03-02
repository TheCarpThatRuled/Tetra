﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;

namespace Check.OptionTests.OfTestSubClass;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.Option)]
// ReSharper disable once InconsistentNaming
public class None_Cast
{
   /* ------------------------------------------------------------ */
   // public Option<TNew> Cast<TNew>()
   /* ------------------------------------------------------------ */

   //GIVEN
   //None_of_TestSubClass
   //WHEN
   //Cast_to_int
   //THEN
   //a_none_is_returned

   [TestMethod]
   public void GIVEN_None_of_TestSubClass_WHEN_Cast_to_int_THEN_a_none_is_returned()
   {
      //Arrange
      var option = Option<TestSubClass>.None();

      //Act
      var actual = option.Cast<int>();

      //Assert
      Assert.That
            .IsANone(AssertMessages.ReturnValue,
                     actual);
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //None_of_TestSubClass
   //WHEN
   //Cast_to_TestClass
   //THEN
   //a_none_is_returned

   [TestMethod]
   public void GIVEN_None_of_TestSubClass_WHEN_Cast_to_TestClass_THEN_a_none_is_returned()
   {
      //Arrange
      var option = Option<TestSubClass>.None();

      //Act
      var actual = option.Cast<TestClass>();

      //Assert
      Assert.That
            .IsANone(AssertMessages.ReturnValue,
                     actual);
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //None_of_TestSubClass
   //WHEN
   //Cast_to_TestStruct
   //THEN
   //a_none_is_returned

   [TestMethod]
   public void GIVEN_None_of_TestSubClass_WHEN_Cast_to_TestStruct_THEN_a_none_is_returned()
   {
      //Arrange
      var option = Option<TestSubClass>.None();

      //Act
      var actual = option.Cast<TestStruct>();

      //Assert
      Assert.That
            .IsANone(AssertMessages.ReturnValue,
                     actual);
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //None_of_TestSubClass
   //WHEN
   //Cast_to_TestSubClass
   //THEN
   //a_none_is_returned

   [TestMethod]
   public void GIVEN_None_of_TestSubClass_WHEN_Cast_to_TestSubClass_THEN_a_none_is_returned()
   {
      //Arrange
      var option = Option<TestSubClass>.None();

      //Act
      var actual = option.Cast<TestSubClass>();

      //Assert
      Assert.That
            .IsANone(AssertMessages.ReturnValue,
                     actual);
   }

   /* ------------------------------------------------------------ */
}