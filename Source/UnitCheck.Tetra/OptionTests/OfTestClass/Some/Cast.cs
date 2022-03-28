using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.OptionTests.OfTestClass;

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
   //Some_of_TestClass
   //WHEN
   //Cast_to_int
   //THEN
   //a_none_is_returned

   [TestMethod]
   public void GIVEN_Some_of_TestClass_WHEN_Cast_to_int_THEN_a_none_is_returned()
   {
      static Property Property(TestClass value)
      {
         //Arrange
         var option = Option.Some(value);

         //Act
         var actual = option.Cast<int>();

         //Assert
         return IsANone(actual);
      }

      Arb.Register<Libraries.TestClass>();

      Prop.ForAll<TestClass>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Some_of_TestClass_AND_the_content_is_a_TestClass
   //WHEN
   //Cast_to_TestClass
   //THEN
   //a_none_is_returned

   [TestMethod]
   public void GIVEN_Some_of_TestClass_AND_the_content_is_a_TestClass_WHEN_Cast_to_TestClass_THEN_a_none_is_returned()
   {
      static Property Property(TestClass value)
      {
         //Arrange
         var option = Option.Some(value);

         //Act
         var actual = option.Cast<TestClass>();

         //Assert
         return IsASome(value,
                        actual);
      }

      Arb.Register<Libraries.TestClass>();

      Prop.ForAll<TestClass>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Some_of_TestClass_AND_the_content_is_a_TestSubClass
   //WHEN
   //Cast_to_TestClass
   //THEN
   //a_some_containing_the_content_is_returned

   [TestMethod]
   public void GIVEN_Some_of_TestClass_AND_the_content_is_a_TestSubClass_WHEN_Cast_to_TestClass_THEN_a_some_containing_the_content_is_returned()
   {
      static Property Property(TestSubClass value)
      {
         //Arrange
         var option = Option<TestClass>.Some(value);

         //Act
         var actual = option.Cast<TestClass>();

         //Assert
         return IsASome(actual);
      }

      Arb.Register<Libraries.TestSubClass>();

      Prop.ForAll<TestSubClass>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Some_of_TestClass
   //WHEN
   //Cast_to_TestStruct
   //THEN
   //a_none_is_returned

   [TestMethod]
   public void GIVEN_Some_of_TestClass_WHEN_Cast_to_TestStruct_THEN_a_none_is_returned()
   {
      static Property Property(TestClass value)
      {
         //Arrange
         var option = Option.Some(value);

         //Act
         var actual = option.Cast<TestStruct>();

         //Assert
         return IsANone(actual);
      }

      Arb.Register<Libraries.TestClass>();

      Prop.ForAll<TestClass>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Some_of_TestClass
   //WHEN
   //Cast_to_TestSubClass
   //THEN
   //a_none_is_returned

   [TestMethod]
   public void GIVEN_Some_of_TestClass_WHEN_Cast_to_TestSubClass_THEN_a_none_is_returned()
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