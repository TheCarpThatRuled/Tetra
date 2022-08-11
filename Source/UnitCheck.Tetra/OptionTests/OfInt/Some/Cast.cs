﻿using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.OptionTests.OfInt;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.Option)]
// ReSharper disable once InconsistentNaming
public class Some_Cast
{
   /* ------------------------------------------------------------ */
   // public Option<TNew> Cast<TNew>()
   /* ------------------------------------------------------------ */

   //GIVEN
   //Some_of_int
   //WHEN
   //Cast_to_int
   //THEN
   //a_some_containing_the_content_is_returned

   [TestMethod]
   public void GIVEN_Some_of_int_WHEN_Cast_to_int_THEN_a_some_containing_the_content_is_returned()
   {
      static Property Property(int content)
      {
         //Arrange
         var option = Option.Some(content);

         //Act
         var actual = option.Cast<int>();

         //Assert
         return IsASome(AssertMessages.ReturnValue,
                        content,
                        actual);
      }

      Prop.ForAll<int>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Some_of_int
   //WHEN
   //Cast_to_TestClass
   //THEN
   //a_none_is_returned

   [TestMethod]
   public void GIVEN_Some_of_int_WHEN_Cast_to_TestClass_THEN_a_none_is_returned()
   {
      static Property Property(int content)
      {
         //Arrange
         var option = Option.Some(content);

         //Act
         var actual = option.Cast<TestClass>();

         //Assert
         return IsANone(AssertMessages.ReturnValue,
                        actual);
      }

      Prop.ForAll<int>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Some_of_int
   //WHEN
   //Cast_to_TestStruct
   //THEN
   //a_none_is_returned

   [TestMethod]
   public void GIVEN_Some_of_int_WHEN_Cast_to_TestStruct_THEN_a_none_is_returned()
   {
      static Property Property(int content)
      {
         //Arrange
         var option = Option.Some(content);

         //Act
         var actual = option.Cast<TestStruct>();

         //Assert
         return IsANone(AssertMessages.ReturnValue,
                        actual);
      }

      Prop.ForAll<int>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Some_of_int
   //WHEN
   //Cast_to_TestSubClass
   //THEN
   //a_none_is_returned

   [TestMethod]
   public void GIVEN_Some_of_int_WHEN_Cast_to_TestSubClass_THEN_a_none_is_returned()
   {
      static Property Property(int content)
      {
         //Arrange
         var option = Option.Some(content);

         //Act
         var actual = option.Cast<TestSubClass>();

         //Assert
         return IsANone(AssertMessages.ReturnValue,
                        actual);
      }

      Prop.ForAll<int>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Some_of_int
   //WHEN
   //Cast_to_uint
   //THEN
   //a_none_is_returned

   [TestMethod]
   public void GIVEN_Some_of_int_WHEN_Cast_to_uint_THEN_a_none_is_returned()
   {
      static Property Property(int content)
      {
         //Arrange
         var option = Option.Some(content);

         //Act
         var actual = option.Cast<uint>();

         //Assert
         return IsANone(AssertMessages.ReturnValue,
                        actual);
      }

      Prop.ForAll<int>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}