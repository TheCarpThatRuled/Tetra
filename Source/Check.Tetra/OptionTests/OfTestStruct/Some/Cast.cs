using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.OptionTests.OfTestStruct;

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
   //Some_of_TestStruct
   //WHEN
   //Cast_to_DateTime
   //THEN
   //a_none_is_returned

   [TestMethod]
   public void GIVEN_Some_of_TestStruct_WHEN_Cast_to_DateTime_THEN_a_none_is_returned()
   {
      static Property Property(TestStruct content)
      {
         //Arrange
         var option = Option.Some(content);

         //Act
         var actual = option.Cast<DateTime>();

         //Assert
         return IsANone(AssertMessages.ReturnValue,
                        actual);
      }

      Arb.Register<Libraries.TestStruct>();

      Prop.ForAll<TestStruct>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Some_of_TestStruct
   //WHEN
   //Cast_to_int
   //THEN
   //a_none_is_returned

   [TestMethod]
   public void GIVEN_Some_of_TestStruct_WHEN_Cast_to_int_THEN_a_none_is_returned()
   {
      static Property Property(TestStruct content)
      {
         //Arrange
         var option = Option.Some(content);

         //Act
         var actual = option.Cast<int>();

         //Assert
         return IsANone(AssertMessages.ReturnValue,
                        actual);
      }

      Arb.Register<Libraries.TestStruct>();

      Prop.ForAll<TestStruct>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Some_of_TestStruct
   //WHEN
   //Cast_to_TestClass
   //THEN
   //a_none_is_returned

   [TestMethod]
   public void GIVEN_Some_of_TestStruct_WHEN_Cast_to_TestClass_THEN_a_nne_is_returned()
   {
      static Property Property(TestStruct content)
      {
         //Arrange
         var option = Option.Some(content);

         //Act
         var actual = option.Cast<TestClass>();

         //Assert
         return IsANone(AssertMessages.ReturnValue,
                        actual);
      }

      Arb.Register<Libraries.TestStruct>();

      Prop.ForAll<TestStruct>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Some_of_TestStruct
   //WHEN
   //Cast_to_TestStruct
   //THEN
   //a_some_containing_the_content_is_returned

   [TestMethod]
   public void GIVEN_Some_of_TestStruct_WHEN_Cast_to_TestStruct_THEN_a_some_containing_the_content_is_returned()
   {
      static Property Property(TestStruct content)
      {
         //Arrange
         var option = Option.Some(content);

         //Act
         var actual = option.Cast<TestStruct>();

         //Assert
         return IsASome(AssertMessages.ReturnValue,
                        content,
                        actual);
      }

      Arb.Register<Libraries.TestStruct>();

      Prop.ForAll<TestStruct>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Some_of_TestStruct
   //WHEN
   //Cast_to_TestSubClass
   //THEN
   //a_none_is_returned

   [TestMethod]
   public void GIVEN_Some_of_TestStruct_WHEN_Cast_to_TestSubClass_THEN_a_none_is_returned()
   {
      static Property Property(TestStruct content)
      {
         //Arrange
         var option = Option.Some(content);

         //Act
         var actual = option.Cast<TestSubClass>();

         //Assert
         return IsANone(AssertMessages.ReturnValue,
                        actual);
      }

      Arb.Register<Libraries.TestStruct>();

      Prop.ForAll<TestStruct>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}