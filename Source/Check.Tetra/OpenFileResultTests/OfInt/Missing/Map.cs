using FsCheck;
using static Tetra.Testing.Properties;

namespace Check.OpenFileResultTests.OfInt;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.OpenFileResult)]
// ReSharper disable once InconsistentNaming
public class Missing_Map
{
   /* ------------------------------------------------------------ */
   // IOpenFileResult<TNew> Map<TNew>(Func<T, TNew> whenOpen);
   /* ------------------------------------------------------------ */

   //GIVEN
   //Missing_of_int
   //WHEN
   //Map_AND_whenOpen_is_a_Func_of_int_to_int
   //THEN
   //whenOpen_was_not_invoked_AND_a_Missing_containing_the_content_is_returned

   [TestMethod]
   public void
      GIVEN_Missing_of_int_WHEN_Map_AND_whenOpen_is_a_Func_of_int_to_int_THEN_whenOpen_was_not_invoked_AND_a_Missing_containing_the_content_is_returned()
   {
      static Property Property
      (
         AbsoluteFilePath path,
         Message          message,
         int              whenOpen
      )
      {
         //Arrange
         var whenOpenFunc = FakeFunction<int, int>.Create(whenOpen);

         var result = MissingResult<int>.Create(message,
                                                path);

         //Act
         var actual = result.Map(whenOpenFunc.Func);

         //Assert
         return IsAMissing(AssertMessages.ReturnValue,
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
   //Missing_of_int
   //WHEN
   //Map_AND_whenOpen_is_a_Func_of_int_to_TestClass
   //THEN
   //whenOpen_was_not_invoked_AND_a_Missing_containing_the_content_is_returned

   [TestMethod]
   public void
      GIVEN_Missing_of_int_WHEN_Map_AND_whenOpen_is_a_Func_of_int_to_TestClass_THEN_whenOpen_was_not_invoked_AND_a_Missing_containing_the_content_is_returned()
   {
      static Property Property
      (
         AbsoluteFilePath path,
         Message          message,
         TestClass        whenOpen
      )
      {
         //Arrange
         var whenOpenFunc = FakeFunction<int, TestClass>.Create(whenOpen);

         var result = MissingResult<int>.Create(message,
                                                path);

         //Act
         var actual = result.Map(whenOpenFunc.Func);

         //Assert
         return IsAMissing(AssertMessages.ReturnValue,
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
   //Missing_of_int
   //WHEN
   //Map_AND_whenOpen_is_a_Func_of_int_to_TestStruct
   //THEN
   //whenOpen_was_not_invoked_AND_a_Missing_containing_the_content_is_returned

   [TestMethod]
   public void
      GIVEN_Missing_of_int_WHEN_Map_AND_whenOpen_is_a_Func_of_int_to_TestStruct_THEN_whenOpen_was_not_invoked_AND_a_Missing_containing_the_content_is_returned()
   {
      static Property Property
      (
         AbsoluteFilePath path,
         Message          message,
         TestStruct       whenOpen
      )
      {
         //Arrange
         var whenOpenFunc = FakeFunction<int, TestStruct>.Create(whenOpen);

         var result = MissingResult<int>.Create(message,
                                                path);

         //Act
         var actual = result.Map(whenOpenFunc.Func);

         //Assert
         return IsAMissing(AssertMessages.ReturnValue,
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