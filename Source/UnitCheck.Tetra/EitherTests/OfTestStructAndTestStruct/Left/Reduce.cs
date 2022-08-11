using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.EitherTests.OfTestStructAndTestStruct;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.Either)]
// ReSharper disable once InconsistentNaming
public class Left_Reduce
{
   /* ------------------------------------------------------------ */
   // public T Reduce<T>(Func<Left<TLeft>,T>    whenLeft,
   //                    Func<Right<TRight>, T> whenRight)
   /* ------------------------------------------------------------ */

   //GIVEN
   //Left_of_TestStruct
   //WHEN
   //Reduce_AND_whenLeft_is_a_Func_of_Left_of_TestStruct_to_int_AND_whenRight_is_a_Func_of_Right_of_TestStruct_to_int
   //THEN
   //whenLeft_was_invoked_once_with_the_content_AND_whenRight_was_not_invoked_AND_the_return_value_of_whenLeft_is_returned

   [TestMethod]
   public void
      GIVEN_Left_of_TestStruct_WHEN_Reduce_AND_whenLeft_is_a_Func_of_Left_of_TestStruct_to_int_AND_whenRight_is_a_Func_of_Right_of_TestStruct_to_int_THEN_whenLeft_was_invoked_once_with_the_content_AND_whenRight_was_not_invoked_AND_the_return_value_of_whenLeft_is_returned()
   {
      static Property Property(TestStruct                    content,
                               (int whenLeft, int whenRight) args)
      {
         //Arrange
         var whenLeft  = FakeFunction<Left<TestStruct>, int>.Create(args.whenLeft);
         var whenRight = FakeFunction<Right<TestStruct>, int>.Create(args.whenRight);

         var result = Either<TestStruct, TestStruct>.Left(content);

         //Act
         var actual = result.Reduce(whenLeft.Func,
                                    whenRight.Func);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         args.whenLeft,
                         actual)
               .And(WasInvokedOnce(nameof(whenLeft),
                                   content,
                                   whenLeft))
               .And(WasNotInvoked(nameof(whenRight),
                                  whenRight));
      }

      Arb.Register<Libraries.TestStruct>();
      Arb.Register<Libraries.TwoUniqueInt32s>();

      Prop.ForAll<TestStruct, (int, int)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Left_of_TestStruct
   //WHEN
   //Reduce_AND_whenLeft_is_a_Func_of_Left_of_TestStruct_to_TestClass_AND_whenRight_is_a_Func_of_Right_of_TestStruct_to_TestClass
   //THEN
   //whenLeft_was_invoked_once_with_the_content_AND_whenRight_was_not_invoked_AND_the_return_value_of_whenLeft_is_returned

   [TestMethod]
   public void
      GIVEN_Left_of_TestStruct_WHEN_Reduce_AND_whenLeft_is_a_Func_of_Left_of_TestStruct_to_TestClass_AND_whenRight_is_a_Func_of_Right_of_TestStruct_to_TestClass_THEN_whenLeft_was_invoked_once_with_the_content_AND_whenRight_was_not_invoked_AND_the_return_value_of_whenLeft_is_returned()
   {
      static Property Property(TestStruct                                content,
                               (TestClass whenLeft, TestClass whenRight) args)
      {
         //Arrange
         var whenLeft  = FakeFunction<Left<TestStruct>, TestClass>.Create(args.whenLeft);
         var whenRight = FakeFunction<Right<TestStruct>, TestClass>.Create(args.whenRight);

         var result = Either<TestStruct, TestStruct>.Left(content);

         //Act
         var actual = result.Reduce(whenLeft.Func,
                                    whenRight.Func);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         args.whenLeft,
                         actual)
               .And(WasInvokedOnce(nameof(whenLeft),
                                   content,
                                   whenLeft))
               .And(WasNotInvoked(nameof(whenRight),
                                  whenRight));
      }

      Arb.Register<Libraries.TestStruct>();
      Arb.Register<Libraries.TwoUniqueTestClasses>();

      Prop.ForAll<TestStruct, (TestClass, TestClass)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Left_of_TestStruct
   //WHEN
   //Reduce_AND_whenLeft_is_a_Func_of_Left_of_TestStruct_to_TestStruct_AND_whenRight_is_a_Func_of_Right_of_TestStruct_to_TestStruct
   //THEN
   //whenLeft_was_invoked_once_with_the_content_AND_whenRight_was_not_invoked_AND_the_return_value_of_whenLeft_is_returned

   [TestMethod]
   public void
      GIVEN_Left_of_TestStruct_WHEN_Reduce_AND_whenLeft_is_a_Func_of_Left_of_TestStruct_to_TestStruct_AND_whenRight_is_a_Func_of_Right_of_TestStruct_to_TestStruct_THEN_whenLeft_was_invoked_once_with_the_content_AND_whenRight_was_not_invoked_AND_the_return_value_of_whenLeft_is_returned()
   {
      static Property Property((TestStruct content, TestStruct whenLeft, TestStruct whenRight) args)
      {
         //Arrange
         var whenLeft  = FakeFunction<Left<TestStruct>, TestStruct>.Create(args.whenLeft);
         var whenRight = FakeFunction<Right<TestStruct>, TestStruct>.Create(args.whenRight);

         var result = Either<TestStruct, TestStruct>.Left(args.content);

         //Act
         var actual = result.Reduce(whenLeft.Func,
                                    whenRight.Func);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         args.whenLeft,
                         actual)
               .And(WasInvokedOnce(nameof(whenLeft),
                                   args.content,
                                   whenLeft))
               .And(WasNotInvoked(nameof(whenRight),
                                  whenRight));
      }

      Arb.Register<Libraries.ThreeUniqueTestStructs>();

      Prop.ForAll<(TestStruct, TestStruct, TestStruct)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}