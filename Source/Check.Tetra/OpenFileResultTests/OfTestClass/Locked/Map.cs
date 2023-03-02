using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.OpenFileResultTests.OfTestClass;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.OpenFileResult)]
// ReSharper disable once InconsistentNaming
public class Locked_Map
{
   /* ------------------------------------------------------------ */
   // IOpenFileResult<TNew> Map<TNew>(Func<T, TNew> whenOpen);
   /* ------------------------------------------------------------ */

   //GIVEN
   //Locked_of_TestClass
   //WHEN
   //Map_AND_whenOpen_is_a_Func_of_TestClass_to_int
   //THEN
   //whenOpen_was_not_invoked_AND_a_Locked_containing_the_content_is_returned

   [TestMethod]
   public void
      GIVEN_Locked_of_TestClass_WHEN_Map_AND_whenOpen_is_a_Func_of_TestClass_to_int_THEN_whenOpen_was_not_invoked_AND_a_Locked_containing_the_content_is_returned()
   {
      static Property Property(AbsoluteFilePath path,
                               Message          message,
                               int              whenOpen)
      {
         //Arrange
         var whenOpenFunc = FakeFunction<TestClass, int>.Create(whenOpen);

         var result = LockedResult<TestClass>.Create(message,
                                                             path);

         //Act
         var actual = result.Map(whenOpenFunc.Func);

         //Assert
         return IsALocked(AssertMessages.ReturnValue,
                          path,
                          message,
                          actual)
           .And(WasNotInvoked(nameof(whenOpen),
                              whenOpenFunc));
      }

      Arb.Register<Libraries.AbsoluteFilePath>();
      Arb.Register<Libraries.Message>();

      Prop.ForAll<AbsoluteFilePath, Message, int>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Locked_of_TestClass
   //WHEN
   //Map_AND_whenOpen_is_a_Func_of_TestClass_to_TestClass
   //THEN
   //whenOpen_was_not_invoked_AND_a_Locked_containing_the_content_is_returned

   [TestMethod]
   public void
      GIVEN_Locked_of_TestClass_WHEN_Map_AND_whenOpen_is_a_Func_of_TestClass_to_TestClass_THEN_whenOpen_was_not_invoked_AND_a_Locked_containing_the_content_is_returned()
   {
      static Property Property(AbsoluteFilePath path,
                               Message          message,
                               TestClass        whenOpen)
      {
         //Arrange
         var whenOpenFunc = FakeFunction<TestClass, TestClass>.Create(whenOpen);

         var result = LockedResult<TestClass>.Create(message,
                                                             path);

         //Act
         var actual = result.Map(whenOpenFunc.Func);

         //Assert
         return IsALocked(AssertMessages.ReturnValue,
                          path,
                          message,
                          actual)
           .And(WasNotInvoked(nameof(whenOpen),
                              whenOpenFunc));
      }

      Arb.Register<Libraries.AbsoluteFilePath>();
      Arb.Register<Libraries.Message>();
      Arb.Register<Libraries.TestClass>();

      Prop.ForAll<AbsoluteFilePath, Message, TestClass>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Locked_of_TestClass
   //WHEN
   //Map_AND_whenOpen_is_a_Func_of_TestClass_to_TestStruct
   //THEN
   //whenOpen_was_not_invoked_AND_a_Locked_containing_the_content_is_returned

   [TestMethod]
   public void
      GIVEN_Locked_of_TestClass_WHEN_Map_AND_whenOpen_is_a_Func_of_TestClass_to_TestStruct_THEN_whenOpen_was_not_invoked_AND_a_Locked_containing_the_content_is_returned()
   {
      static Property Property(AbsoluteFilePath path,
                               Message          message,
                               TestStruct       whenOpen)
      {
         //Arrange
         var whenOpenFunc = FakeFunction<TestClass, TestStruct>.Create(whenOpen);

         var result = LockedResult<TestClass>.Create(message,
                                                             path);

         //Act
         var actual = result.Map(whenOpenFunc.Func);

         //Assert
         return IsALocked(AssertMessages.ReturnValue,
                          path,
                          message,
                          actual)
           .And(WasNotInvoked(nameof(whenOpen),
                              whenOpenFunc));
      }

      Arb.Register<Libraries.AbsoluteFilePath>();
      Arb.Register<Libraries.Message>();
      Arb.Register<Libraries.TestStruct>();

      Prop.ForAll<AbsoluteFilePath, Message, TestStruct>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}