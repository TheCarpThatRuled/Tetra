using FsCheck;
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
   // Option<TNew> Cast<TNew>()
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
      static Property Property(int value)
      {
         //Arrange
         var option = Option.Some(value);

         //Act
         var actual = option.Cast<uint>();

         //Assert
         return IsANone(actual);
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
      static Property Property(int value)
      {
         //Arrange
         var option = Option.Some(value);

         //Act
         var actual = option.Cast<TestClass>();

         //Assert
         return IsANone(actual);
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
      static Property Property(int value)
      {
         //Arrange
         var option = Option.Some(value);

         //Act
         var actual = option.Cast<TestStruct>();

         //Assert
         return IsANone(actual);
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
      static Property Property(int value)
      {
         //Arrange
         var option = Option.Some(value);

         //Act
         var actual = option.Cast<TestSubClass>();

         //Assert
         return IsANone(actual);
      }

      Prop.ForAll<int>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}