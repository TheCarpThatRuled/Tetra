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
public class Some_MapToResult
{
   /* ------------------------------------------------------------ */
   // Result<T> MapToResult<T>(T whenNone);
   /* ------------------------------------------------------------ */

   //GIVEN
   //Some
   //WHEN
   //MapToResult_AND_whenNone_is_an_int
   //THEN
   //a_failure_containing_the_content_is_returned

   [TestMethod]
   public void
      GIVEN_Some_WHEN_MapToResult_AND_whenNone_is_an_int_THEN_a_failure_containing_the_content_is_returned()
   {
      static Property Property(Message content, int whenNone)
      {
         //Arrange
         var error = Error.Some(content);

         //Act
         var actual = error.MapToResult(whenNone);

         //Assert
         return IsAFailure(AssertMessages.ReturnValue,
                           content,
                           actual);
      }

      Arb.Register<Libraries.Message>();

      Prop.ForAll<Message, int>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Some
   //WHEN
   //MapToResult_AND_whenNone_is_a_TestClass
   //THEN
   //a_failure_containing_the_content_is_returned

   [TestMethod]
   public void
      GIVEN_Some_WHEN_MapToResult_AND_whenNone_is_a_TestClass_THEN_a_failure_containing_the_content_is_returned()
   {
      static Property Property(Message content, TestClass whenNone)
      {
         //Arrange
         var error = Error.Some(content);

         //Act
         var actual = error.MapToResult(whenNone);

         //Assert
         return IsAFailure(AssertMessages.ReturnValue,
                           content,
                           actual);
      }

      Arb.Register<Libraries.Message>();
      Arb.Register<Libraries.TestClass>();

      Prop.ForAll<Message, TestClass>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Some
   //WHEN
   //MapToResult_AND_whenNone_is_a_TestStruct
   //THEN
   //a_failure_containing_the_content_is_returned

   [TestMethod]
   public void
      GIVEN_Some_WHEN_MapToResult_AND_whenNone_is_a_TestStruct_THEN_a_failure_containing_the_content_is_returned()
   {
      static Property Property(Message content, TestStruct whenNone)
      {
         //Arrange
         var error = Error.Some(content);

         //Act
         var actual = error.MapToResult(whenNone);

         //Assert
         return IsAFailure(AssertMessages.ReturnValue,
                           content,
                           actual);
      }

      Arb.Register<Libraries.Message>();
      Arb.Register<Libraries.TestStruct>();

      Prop.ForAll<Message, TestStruct>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // Result<T> MapToResult<T>(Func<T> whenNone);
   /* ------------------------------------------------------------ */

   //GIVEN
   //Some
   //WHEN
   //MapToResult_AND_whenNone_is_a_Func_of_int
   //THEN
   //whenNone_was_not_invoked_AND_a_failure_containing_the_content_is_returned

   [TestMethod]
   public void
      GIVEN_Some_WHEN_MapToResult_AND_whenNone_is_a_Func_of_int_THEN_whenNone_was_not_invoked_AND_a_failure_containing_the_content_is_returned()
   {
      static Property Property(Message content, int value)
      {
         //Arrange
         var whenNone = FakeFunction<int>.Create(value);

         var error = Error.Some(content);

         //Act
         var actual = error.MapToResult(whenNone.Func);

         //Assert
         return IsAFailure(AssertMessages.ReturnValue,
                           content,
                           actual)
           .And(WasNotInvoked(nameof(whenNone),
                              whenNone));
      }

      Arb.Register<Libraries.Message>();

      Prop.ForAll<Message, int>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Some
   //WHEN
   //MapToResult_AND_whenNone_is_a_Func_of_TestClass
   //THEN
   //whenNone_was_not_invoked_AND_a_failure_containing_the_content_is_returned

   [TestMethod]
   public void
      GIVEN_Some_WHEN_MapToResult_AND_whenNone_is_a_Func_of_TestClass_THEN_whenNone_was_not_invoked_AND_a_failure_containing_the_content_is_returned()
   {
      static Property Property(Message content, TestClass value)
      {
         //Arrange
         var whenNone = FakeFunction<TestClass>.Create(value);

         var error = Error.Some(content);

         //Act
         var actual = error.MapToResult(whenNone.Func);

         //Assert
         return IsAFailure(AssertMessages.ReturnValue,
                           content,
                           actual)
           .And(WasNotInvoked(nameof(whenNone),
                              whenNone));
      }

      Arb.Register<Libraries.Message>();
      Arb.Register<Libraries.TestClass>();

      Prop.ForAll<Message, TestClass>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Some
   //WHEN
   //MapToResult_AND_whenNone_is_a_Func_of_TestStruct
   //THEN
   //whenNone_was_not_invoked_AND_a_failure_containing_the_content_is_returned

   [TestMethod]
   public void
      GIVEN_Some_WHEN_MapToResult_AND_whenNone_is_a_Func_of_TestStruct_THEN_whenNone_was_not_invoked_AND_a_failure_containing_the_content_is_returned()
   {
      static Property Property(Message content, TestStruct value)
      {
         //Arrange
         var whenNone = FakeFunction<TestStruct>.Create(value);

         var error = Error.Some(content);

         //Act
         var actual = error.MapToResult(whenNone.Func);

         //Assert
         return IsAFailure(AssertMessages.ReturnValue,
                           content,
                           actual)
           .And(WasNotInvoked(nameof(whenNone),
                              whenNone));
      }

      Arb.Register<Libraries.Message>();
      Arb.Register<Libraries.TestStruct>();

      Prop.ForAll<Message, TestStruct>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}