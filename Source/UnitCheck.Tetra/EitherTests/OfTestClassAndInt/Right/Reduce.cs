using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.EitherTests.OfTestClassAndInt;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.Either)]
// ReSharper disable once InconsistentNaming
public class Right_Reduce
{
   /* ------------------------------------------------------------ */
   // T Reduce<T>(Func<Left<TLeft>,T> whenLeft,
   //             Func<Right<TRight>, T> whenRight)
   /* ------------------------------------------------------------ */

   //GIVEN
   //Right_of_int
   //WHEN
   //Reduce_AND_whenLeft_is_a_Func_of_Left_of_TestClass_to_int_AND_whenRight_is_a_Func_of_Right_of_int_to_int
   //THEN
   //whenLeft_was_invoked_once_with_the_content_was_not_invoked_AND_whenRight_was_invoked_once_with_the_content_AND_the_return_value_of_whenRight_is_returned

   [TestMethod]
   public void GIVEN_Right_of_int_WHEN_Reduce_AND_whenLeft_is_a_Func_of_Left_of_TestClass_to_int_AND_whenRight_is_a_Func_of_Right_of_int_to_int_THEN_whenLeft_was_invoked_once_with_the_content_was_not_invoked_AND_whenRight_was_invoked_once_with_the_content_AND_the_return_value_of_whenRight_is_returned()
   {
      static Property Property((int content, int whenLeft, int whenRight) args)
      {
         //Arrange
         var whenLeft  = FakeFunction<Left<TestClass>, int>.Create(args.whenLeft);
         var whenRight = FakeFunction<Right<int>, int>.Create(args.whenRight);

         var result = Either<TestClass, int>.Right(args.content);

         //Act
         var actual = result.Reduce(whenLeft.Func,
                                    whenRight.Func);

         //Assert
         return AreEqual(args.whenRight,
                         actual)
               .And(WasNotInvoked(whenLeft))
               .And(WasInvokedOnce(args.content,
                                   whenRight));
      }

      Arb.Register<Libraries.ThreeUniqueInt32s>();

      Prop.ForAll<(int, int, int)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Right_of_int
   //WHEN
   //Reduce_AND_whenLeft_is_a_Func_of_Left_of_TestClass_to_TestClass_AND_whenRight_is_a_Func_of_Right_of_int_to_TestClass
   //THEN
   //whenLeft_was_invoked_once_with_the_content_was_not_invoked_AND_whenRight_was_invoked_once_with_the_content_AND_the_return_value_of_whenRight_is_returned

   [TestMethod]
   public void GIVEN_Right_of_int_WHEN_Reduce_AND_whenLeft_is_a_Func_of_Left_of_TestClass_to_TestClass_AND_whenRight_is_a_Func_of_Right_of_int_to_TestClass_THEN_whenLeft_was_invoked_once_with_the_content_was_not_invoked_AND_whenRight_was_invoked_once_with_the_content_AND_the_return_value_of_whenRight_is_returned()
   {
      static Property Property(int content, (TestClass whenLeft, TestClass whenRight) args)
      {
         //Arrange
         var whenLeft  = FakeFunction<Left<TestClass>, TestClass>.Create(args.whenLeft);
         var whenRight = FakeFunction<Right<int>, TestClass>.Create(args.whenRight);

         var result = Either<TestClass, int>.Right(content);

         //Act
         var actual = result.Reduce(whenLeft.Func,
                                    whenRight.Func);

         //Assert
         return AreEqual(args.whenRight,
                         actual)
               .And(WasNotInvoked(whenLeft))
               .And(WasInvokedOnce(content,
                                   whenRight));
      }

      Arb.Register<Libraries.TwoUniqueTestClasses>();

      Prop.ForAll<int, (TestClass, TestClass)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Right_of_int
   //WHEN
   //Reduce_AND_whenLeft_is_a_Func_of_Left_of_TestClass_to_TestStruct_AND_whenRight_is_a_Func_of_Right_of_int_to_TestStruct
   //THEN
   //whenLeft_was_invoked_once_with_the_content_was_not_invoked_AND_whenRight_was_invoked_once_with_the_content_AND_the_return_value_of_whenRight_is_returned

   [TestMethod]
   public void GIVEN_Right_of_int_WHEN_Reduce_AND_whenLeft_is_a_Func_of_Left_of_TestClass_to_TestStruct_AND_whenRight_is_a_Func_of_Right_of_int_to_TestStruct_THEN_whenLeft_was_invoked_once_with_the_content_was_not_invoked_AND_whenRight_was_invoked_once_with_the_content_AND_the_return_value_of_whenRight_is_returned()
   {
      static Property Property(int content, (TestStruct whenLeft, TestStruct whenRight) args)
      {
         //Arrange
         var whenLeft  = FakeFunction<Left<TestClass>, TestStruct>.Create(args.whenLeft);
         var whenRight = FakeFunction<Right<int>, TestStruct>.Create(args.whenRight);

         var result = Either<TestClass, int>.Right(content);

         //Act
         var actual = result.Reduce(whenLeft.Func,
                                    whenRight.Func);

         //Assert
         return AreEqual(args.whenRight,
                         actual)
               .And(WasNotInvoked(whenLeft))
               .And(WasInvokedOnce(content,
                                   whenRight));
      }

      Arb.Register<Libraries.TwoUniqueTestStructs>();

      Prop.ForAll<int, (TestStruct, TestStruct)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}