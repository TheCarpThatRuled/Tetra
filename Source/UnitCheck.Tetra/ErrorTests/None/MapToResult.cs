using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.ErrorTests;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.Error)]
// ReSharper disable once InconsistentNaming
public class None_MapToResult
{
   /* ------------------------------------------------------------ */
   // Result<T> MapToResult<T>(T whenNone);
   /* ------------------------------------------------------------ */

   //GIVEN
   //None
   //WHEN
   //MapToResult_AND_whenNone_is_an_int
   //THEN
   //a_success_containing_whenNone_is_returned

   [TestMethod]
   public void
      GIVEN_None_WHEN_MapToResult_AND_whenNone_is_an_int_THEN_a_success_containing_whenNone_is_returned()
   {
      static Property Property(int whenNone)
      {
         //Arrange
         var error = Error.None();

         //Act
         var actual = error.MapToResult(whenNone);

         //Assert
         return IsASuccess(whenNone,
                           actual);
      }

      Prop.ForAll<int>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //None
   //WHEN
   //MapToResult_AND_whenNone_is_a_TestClass
   //THEN
   //a_success_containing_whenNone_is_returned

   [TestMethod]
   public void
      GIVEN_None_WHEN_MapToResult_AND_whenNone_is_a_TestClass_THEN_a_success_containing_whenNone_is_returned()
   {
      static Property Property(TestClass whenNone)
      {
         //Arrange
         var error = Error.None();

         //Act
         var actual = error.MapToResult(whenNone);

         //Assert
         return IsASuccess(whenNone,
                           actual);
      }

      Arb.Register<Libraries.TestClass>();

      Prop.ForAll<TestClass>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //None
   //WHEN
   //MapToResult_AND_whenNone_is_a_TestStruct
   //THEN
   //a_success_containing_whenNone_is_returned

   [TestMethod]
   public void
      GIVEN_None_WHEN_MapToResult_AND_whenNone_is_a_TestStruct_THEN_a_success_containing_whenNone_is_returned()
   {
      static Property Property(TestStruct whenNone)
      {
         //Arrange

         var error = Error.None();

         //Act
         var actual = error.MapToResult(whenNone);

         //Assert
         return IsASuccess(whenNone,
                           actual);
      }

      Arb.Register<Libraries.TestStruct>();

      Prop.ForAll<TestStruct>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // Result<T> MapToResult<T>(Func<T> whenNone);
   /* ------------------------------------------------------------ */

   //GIVEN
   //None
   //WHEN
   //MapToResult_AND_whenNone_is_a_Func_of_int
   //THEN
   //whenNone_was_invoked_once_AND_a_success_containing_the_return_value_of_whenNone_is_returned

   [TestMethod]
   public void
      GIVEN_None_WHEN_MapToResult_AND_whenNone_is_a_Func_of_int_THEN_whenNone_was_invoked_once_AND_a_success_containing_the_return_value_of_whenNone_is_returned()
   {
      static Property Property(int value)
      {
         //Arrange
         var whenNone = FakeFunction<int>.Create(value);

         var error = Error.None();

         //Act
         var actual = error.MapToResult(whenNone.Func);

         //Assert
         return IsASuccess(value,
                           actual)
           .And(WasInvokedOnce(whenNone));
      }

      Prop.ForAll<int>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //None
   //WHEN
   //MapToResult_AND_whenNone_is_a_Func_of_TestClass
   //THEN
   //whenNone_was_invoked_once_AND_a_success_containing_the_return_value_of_whenNone_is_returned

   [TestMethod]
   public void
      GIVEN_None_WHEN_MapToResult_AND_whenNone_is_a_Func_of_TestClass_THEN_whenNone_was_invoked_once_AND_a_success_containing_the_return_value_of_whenNone_is_returned()
   {
      static Property Property(TestClass value)
      {
         //Arrange
         var whenNone = FakeFunction<TestClass>.Create(value);

         var error = Error.None();

         //Act
         var actual = error.MapToResult(whenNone.Func);

         //Assert
         return IsASuccess(value,
                           actual)
           .And(WasInvokedOnce(whenNone));
      }

      Arb.Register<Libraries.TestClass>();

      Prop.ForAll<TestClass>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //None
   //WHEN
   //MapToResult_AND_whenNone_is_a_Func_of_TestStruct
   //THEN
   //whenNone_was_invoked_once_AND_a_success_containing_the_return_value_of_whenNone_is_returned

   [TestMethod]
   public void
      GIVEN_None_WHEN_MapToResult_AND_whenNone_is_a_Func_of_TestStruct_THEN_whenNone_was_invoked_once_AND_a_success_containing_the_return_value_of_whenNone_is_returned()
   {
      static Property Property(TestStruct value)
      {
         //Arrange
         var whenNone = FakeFunction<TestStruct>.Create(value);

         var error = Error.None();

         //Act
         var actual = error.MapToResult(whenNone.Func);

         //Assert
         return IsASuccess(value,
                           actual)
           .And(WasInvokedOnce(whenNone));
      }

      Arb.Register<Libraries.TestStruct>();

      Prop.ForAll<TestStruct>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}