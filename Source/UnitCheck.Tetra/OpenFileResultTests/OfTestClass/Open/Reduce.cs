﻿using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.OpenFileResultTests.OfTestClass;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.OpenFileResult)]
// ReSharper disable once InconsistentNaming
public class Open_Reduce
{
   /* ------------------------------------------------------------ */
   // IOpenFileResult<TNew> Reduce<TNew>(Func<T, TNew> whenOpen);
   /* ------------------------------------------------------------ */

   //GIVEN
   //Open_of_TestClass
   //WHEN
   //Reduce_AND_whenFuncs_are_a_Func_of_T_to_int
   //THEN
   //whenOpen_was_invoked_once_with_the_content_AND_whenLocked_was_not_invoked_AND_whenMissing_was_not_invoked_AND_the_return_value_of_whenOpen_is_returned

   [TestMethod]
   public void
      GIVEN_Open_of_TestClass_WHEN_Reduce_AND_whenFuncs_are_a_Func_of_T_to_int_THEN_whenOpen_was_invoked_once_with_the_content_AND_whenLocked_was_not_invoked_AND_whenMissing_was_not_invoked_AND_the_return_value_of_whenOpen_is_returned()
   {
      static Property Property(TestClass content, (int whenLocked, int whenMissing, int whenOpen) args)
      {
         //Arrange
         var whenLocked  = FakeFunction<Locked, int>.Create(args.whenLocked);
         var whenMissing = FakeFunction<Missing, int>.Create(args.whenMissing);
         var whenOpen    = FakeFunction<TestClass, int>.Create(args.whenOpen);

         var result = new OpenResult<TestClass>(content);

         //Act
         var actual = result.Reduce(whenLocked.Func,
                                    whenMissing.Func,
                                    whenOpen.Func);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         args.whenOpen,
                         actual)
               .And(WasInvokedOnce(nameof(whenOpen),
                                   content,
                                   whenOpen))
               .And(WasNotInvoked(nameof(whenLocked),
                                  whenLocked))
               .And(WasNotInvoked(nameof(whenMissing),
                                  whenMissing));
      }

      Arb.Register<Libraries.TestClass>();
      Arb.Register<Libraries.ThreeUniqueInt32s>();

      Prop.ForAll<TestClass,(int, int, int)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Open_of_TestClass
   //WHEN
   //Reduce_AND_whenFuncs_are_a_Func_of_T_to_TestClass
   //THEN
   //whenOpen_was_invoked_once_with_the_content_AND_whenLocked_was_not_invoked_AND_whenMissing_was_not_invoked_AND_the_return_value_of_whenOpen_is_returned

   [TestMethod]
   public void
      GIVEN_Open_of_TestClass_WHEN_Reduce_AND_whenFuncs_are_a_Func_of_T_to_TestClass_THEN_whenOpen_was_invoked_once_with_the_content_AND_whenLocked_was_not_invoked_AND_whenMissing_was_not_invoked_AND_the_return_value_of_whenOpen_is_returned()
   {
      static Property Property((TestClass content, TestClass whenLocked, TestClass whenMissing, TestClass whenOpen) args)
      {
         //Arrange
         var whenLocked  = FakeFunction<Locked, TestClass>.Create(args.whenLocked);
         var whenMissing = FakeFunction<Missing, TestClass>.Create(args.whenMissing);
         var whenOpen    = FakeFunction<TestClass, TestClass>.Create(args.whenOpen);

         var result = new OpenResult<TestClass>(args.content);

         //Act
         var actual = result.Reduce(whenLocked.Func,
                                    whenMissing.Func,
                                    whenOpen.Func);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         args.whenOpen,
                         actual)
               .And(WasInvokedOnce(nameof(whenOpen),
                                   args.content,
                                   whenOpen))
               .And(WasNotInvoked(nameof(whenLocked),
                                  whenLocked))
               .And(WasNotInvoked(nameof(whenMissing),
                                  whenMissing));
      }

      Arb.Register<Libraries.FourUniqueTestClasses>();

      Prop.ForAll<(TestClass, TestClass, TestClass, TestClass)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Open_of_TestClass
   //WHEN
   //Reduce_AND_whenFuncs_are_a_Func_of_T_to_TestStruct
   //THEN
   //whenOpen_was_invoked_once_with_the_content_AND_whenLocked_was_not_invoked_AND_whenMissing_was_not_invoked_AND_the_return_value_of_whenOpen_is_returned

   [TestMethod]
   public void
      GIVEN_Open_of_TestClass_WHEN_Reduce_AND_whenFuncs_are_a_Func_of_T_to_TestStruct_THEN_whenOpen_was_invoked_once_with_the_content_AND_whenLocked_was_not_invoked_AND_whenMissing_was_not_invoked_AND_the_return_value_of_whenOpen_is_returned()
   {
      static Property Property(TestClass                                                               content,
                               (TestStruct whenLocked, TestStruct whenMissing, TestStruct whenOpen) args)
      {
         //Arrange
         var whenLocked  = FakeFunction<Locked, TestStruct>.Create(args.whenLocked);
         var whenMissing = FakeFunction<Missing, TestStruct>.Create(args.whenMissing);
         var whenOpen    = FakeFunction<TestClass, TestStruct>.Create(args.whenOpen);

         var result = new OpenResult<TestClass>(content);

         //Act
         var actual = result.Reduce(whenLocked.Func,
                                    whenMissing.Func,
                                    whenOpen.Func);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         args.whenOpen,
                         actual)
               .And(WasInvokedOnce(nameof(whenOpen),
                                   content,
                                   whenOpen))
               .And(WasNotInvoked(nameof(whenLocked),
                                  whenLocked))
               .And(WasNotInvoked(nameof(whenMissing),
                                  whenMissing));
      }

      Arb.Register<Libraries.TestClass>();
      Arb.Register<Libraries.ThreeUniqueTestStructs>();

      Prop.ForAll<TestClass, (TestStruct, TestStruct, TestStruct)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}