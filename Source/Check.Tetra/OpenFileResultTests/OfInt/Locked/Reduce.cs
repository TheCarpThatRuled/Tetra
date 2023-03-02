using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.OpenFileResultTests.OfInt;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.OpenFileResult)]
// ReSharper disable once InconsistentNaming
public class Locked_Reduce
{
   /* ------------------------------------------------------------ */
   // TNew Reduce<TNew>(Func<Locked, TNew>  whenLocked,
   //                   Func<Missing, TNew> whenMissing,
   //                   Func<T, TNew>       whenOpen)
   /* ------------------------------------------------------------ */

   //GIVEN
   //Locked_of_int
   //WHEN
   //Reduce_AND_whenFuncs_are_a_Func_of_T_to_int
   //THEN
   //whenLocked_was_invoked_once_with_the_content_AND_whenMissing_was_not_invoked_AND_whenOpen_was_not_invoked_AND_the_return_value_of_whenLocked_is_returned

   [TestMethod]
   public void
      GIVEN_Locked_of_int_WHEN_Reduce_AND_whenFuncs_are_a_Func_of_T_to_int_THEN_whenLocked_was_invoked_once_with_the_content_AND_whenMissing_was_not_invoked_AND_whenOpen_was_not_invoked_AND_the_return_value_of_whenLocked_is_returned()
   {
      static Property Property(AbsoluteFilePath                                path,
                               Message                                         message,
                               (int whenLocked, int whenMissing, int whenOpen) args)
      {
         //Arrange
         var whenLocked  = FakeFunction<Locked, int>.Create(args.whenLocked);
         var whenMissing = FakeFunction<Missing, int>.Create(args.whenMissing);
         var whenOpen    = FakeFunction<int, int>.Create(args.whenOpen);

         var result = LockedResult<int>.Create(message,
                                               path);

         //Act
         var actual = result.Reduce(whenLocked.Func,
                                    whenMissing.Func,
                                    whenOpen.Func);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         args.whenLocked,
                         actual)
               .And(WasInvokedOnce(nameof(whenLocked),
                                   path,
                                   message,
                                   whenLocked))
               .And(WasNotInvoked(nameof(whenMissing),
                                  whenMissing))
               .And(WasNotInvoked(nameof(whenOpen),
                                  whenOpen));
      }

      Arb.Register<Libraries.AbsoluteFilePath>();
      Arb.Register<Libraries.Message>();
      Arb.Register<Libraries.ThreeUniqueInt32s>();

      Prop.ForAll<AbsoluteFilePath, Message, (int, int, int)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Locked_of_int
   //WHEN
   //Reduce_AND_whenFuncs_are_a_Func_of_T_to_TestClass
   //THEN
   //whenLocked_was_invoked_once_with_the_content_AND_whenMissing_was_not_invoked_AND_whenOpen_was_not_invoked_AND_the_return_value_of_whenLocked_is_returned

   [TestMethod]
   public void
      GIVEN_Locked_of_int_WHEN_Reduce_AND_whenFuncs_are_a_Func_of_T_to_TestClass_THEN_whenLocked_was_invoked_once_with_the_content_AND_whenMissing_was_not_invoked_AND_whenOpen_was_not_invoked_AND_the_return_value_of_whenLocked_is_returned()
   {
      static Property Property(AbsoluteFilePath                                                  path,
                               Message                                                           message,
                               (TestClass whenLocked, TestClass whenMissing, TestClass whenOpen) args)
      {
         //Arrange
         var whenLocked  = FakeFunction<Locked, TestClass>.Create(args.whenLocked);
         var whenMissing = FakeFunction<Missing, TestClass>.Create(args.whenMissing);
         var whenOpen    = FakeFunction<int, TestClass>.Create(args.whenOpen);

         var result = LockedResult<int>.Create(message,
                                               path);

         //Act
         var actual = result.Reduce(whenLocked.Func,
                                    whenMissing.Func,
                                    whenOpen.Func);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         args.whenLocked,
                         actual)
               .And(WasInvokedOnce(nameof(whenLocked),
                                   path,
                                   message,
                                   whenLocked))
               .And(WasNotInvoked(nameof(whenMissing),
                                  whenMissing))
               .And(WasNotInvoked(nameof(whenOpen),
                                  whenOpen));
      }

      Arb.Register<Libraries.AbsoluteFilePath>();
      Arb.Register<Libraries.Message>();
      Arb.Register<Libraries.ThreeUniqueTestClasses>();

      Prop.ForAll<AbsoluteFilePath, Message, (TestClass, TestClass, TestClass)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Locked_of_int
   //WHEN
   //Reduce_AND_whenFuncs_are_a_Func_of_T_to_TestClass
   //THEN
   //whenLocked_was_invoked_once_with_the_content_AND_whenMissing_was_not_invoked_AND_whenOpen_was_not_invoked_AND_the_return_value_of_whenLocked_is_returned

   [TestMethod]
   public void
      GIVEN_Locked_of_int_WHEN_Reduce_AND_whenFuncs_are_a_Func_of_T_to_TestStruct_THEN_whenLocked_was_invoked_once_with_the_content_AND_whenMissing_was_not_invoked_AND_whenOpen_was_not_invoked_AND_the_return_value_of_whenLocked_is_returned()
   {
      static Property Property(AbsoluteFilePath                                                     path,
                               Message                                                              message,
                               (TestStruct whenLocked, TestStruct whenMissing, TestStruct whenOpen) args)
      {
         //Arrange
         var whenLocked  = FakeFunction<Locked, TestStruct>.Create(args.whenLocked);
         var whenMissing = FakeFunction<Missing, TestStruct>.Create(args.whenMissing);
         var whenOpen    = FakeFunction<int, TestStruct>.Create(args.whenOpen);

         var result = LockedResult<int>.Create(message,
                                               path);

         //Act
         var actual = result.Reduce(whenLocked.Func,
                                    whenMissing.Func,
                                    whenOpen.Func);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         args.whenLocked,
                         actual)
               .And(WasInvokedOnce(nameof(whenLocked),
                                   path,
                                   message,
                                   whenLocked))
               .And(WasNotInvoked(nameof(whenMissing),
                                  whenMissing))
               .And(WasNotInvoked(nameof(whenOpen),
                                  whenOpen));
      }

      Arb.Register<Libraries.AbsoluteFilePath>();
      Arb.Register<Libraries.Message>();
      Arb.Register<Libraries.ThreeUniqueTestStructs>();

      Prop.ForAll<AbsoluteFilePath, Message, (TestStruct, TestStruct, TestStruct)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}