using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;
using Result = Tetra.Result;

namespace Check.ResultTests.OfTestClass;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.Result)]
// ReSharper disable once InconsistentNaming
public class Success_Map
{
   /* ------------------------------------------------------------ */
   // IResult<TNew> Map<TNew>(Func<T, TNew> whenSuccess)
   /* ------------------------------------------------------------ */

   //GIVEN
   //TestClass
   //WHEN
   //Map_AND_whenSuccess_is_a_Func_of_TestClass_to_TestClass
   //THEN
   //whenSuccess_was_invoked_with_the_content_AND_a_success_containing_the_return_value_of_whenSuccess_is_returned

   [TestMethod]
   public void
      GIVEN_TestClass_WHEN_Reduce_AND_Map_AND_whenSuccess_is_a_Func_of_TestClass_to_int_THEN_whenSuccess_was_invoked_with_the_content_AND_a_success_containing_the_return_value_of_whenSuccess_is_returned()
   {
      static Property Property(TestClass content,
                               int       whenSuccess)
      {
         //Arrange
         var whenSuccessFunc = FakeFunction<TestClass, int>.Create(whenSuccess);

         var result = Result.Success(content);

         //Act
         var actual = result.Map(whenSuccessFunc.Func);

         //Assert
         return IsASuccess(AssertMessages.ReturnValue,
                           whenSuccess,
                           actual)
           .And(WasInvokedOnce(nameof(whenSuccess),
                               content,
                               whenSuccessFunc));
      }

      Arb.Register<Libraries.TestClass>();

      Prop.ForAll<TestClass, int>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //TestClass
   //WHEN
   //Map_AND_whenSuccess_is_a_Func_of_TestClass_to_TestClass
   //THEN
   //whenSuccess_was_invoked_with_the_content_AND_a_success_containing_the_return_value_of_whenSuccess_is_returned

   [TestMethod]
   public void
      GIVEN_TestClass_WHEN_Reduce_AND_Map_AND_whenSuccess_is_a_Func_of_TestClass_to_TestClass_THEN_whenSuccess_was_invoked_with_the_content_AND_a_success_containing_the_return_value_of_whenSuccess_is_returned()
   {
      static Property Property((TestClass content, TestClass whenSuccess) args)
      {
         //Arrange
         var whenSuccess = FakeFunction<TestClass, TestClass>.Create(args.whenSuccess);

         var result = Result.Success(args.content);

         //Act
         var actual = result.Map(whenSuccess.Func);

         //Assert
         return IsASuccess(AssertMessages.ReturnValue,
                           args.whenSuccess,
                           actual)
           .And(WasInvokedOnce(nameof(whenSuccess),
                               args.content,
                               whenSuccess));
      }

      Arb.Register<Libraries.TwoUniqueTestClasses>();

      Prop.ForAll<(TestClass, TestClass)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //TestClass
   //WHEN
   //Map_AND_whenSuccess_is_a_Func_of_TestClass_to_TestStruct
   //THEN
   //whenSuccess_was_invoked_with_the_content_AND_a_success_containing_the_return_value_of_whenSuccess_is_returned

   [TestMethod]
   public void
      GIVEN_TestClass_WHEN_Reduce_AND_Map_AND_whenSuccess_is_a_Func_of_TestClass_to_TestStruct_THEN_whenSuccess_was_invoked_with_the_content_AND_a_success_containing_the_return_value_of_whenSuccess_is_returned()
   {
      static Property Property(TestClass  content,
                               TestStruct whenSuccess)
      {
         //Arrange
         var whenSuccessFunc = FakeFunction<TestClass, TestStruct>.Create(whenSuccess);

         var result = Result.Success(content);

         //Act
         var actual = result.Map(whenSuccessFunc.Func);

         //Assert
         return IsASuccess(AssertMessages.ReturnValue,
                           whenSuccess,
                           actual)
           .And(WasInvokedOnce(nameof(whenSuccess),
                               content,
                               whenSuccessFunc));
      }

      Arb.Register<Libraries.TestClass>();
      Arb.Register<Libraries.TestStruct>();

      Prop.ForAll<TestClass, TestStruct>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}