using FsCheck;
using static Tetra.Testing.Properties;

namespace Check.OpenFileResultTests.OfInt;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.OpenFileResult)]
// ReSharper disable once InconsistentNaming
public class Open_Map
{
   /* ------------------------------------------------------------ */
   // IOpenFileResult<TNew> Map<TNew>(Func<T, TNew> whenOpen);
   /* ------------------------------------------------------------ */

   //GIVEN
   //Open_of_int
   //WHEN
   //Map_AND_whenOpen_is_a_Func_of_int_to_int
   //THEN
   //whenOpen_was_invoked_with_the_content_AND_an_Open_containing_the_return_value_of_whenOpen_is_returned

   [TestMethod]
   public void
      GIVEN_Open_of_int_WHEN_Map_AND_whenOpen_is_a_Func_of_int_to_int_THEN_whenOpen_was_invoked_with_the_content_AND_an_Open_containing_the_return_value_of_whenOpen_is_returned()
   {
      static Property Property((int content, int whenOpen) args)
      {
         //Arrange
         var whenOpen = FakeFunction<int, int>.Create(args.whenOpen);

         var result = new OpenResult<int>(args.content);

         //Act
         var actual = result.Map(whenOpen.Func);

         //Assert
         return IsAnOpen(AssertMessages.ReturnValue,
                         args.whenOpen,
                         actual)
           .And(WasInvokedOnce(nameof(whenOpen),
                               args.content,
                               whenOpen));
      }

      Arb.Register<Libraries.TwoUniqueInt32s>();

      Prop.ForAll<(int, int)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Open_of_int
   //WHEN
   //Map_AND_whenOpen_is_a_Func_of_int_to_TestClass
   //THEN
   //whenOpen_was_invoked_with_the_content_AND_an_Open_containing_the_return_value_of_whenOpen_is_returned

   [TestMethod]
   public void
      GIVEN_Open_of_int_WHEN_Map_AND_whenOpen_is_a_Func_of_int_to_TestClass_THEN_whenOpen_was_invoked_with_the_content_AND_an_Open_containing_the_return_value_of_whenOpen_is_returned()
   {
      static Property Property(int       content,
                               TestClass whenOpen)
      {
         //Arrange
         var whenOpenFunc = FakeFunction<int, TestClass>.Create(whenOpen);

         var result = new OpenResult<int>(content);

         //Act
         var actual = result.Map(whenOpenFunc.Func);

         //Assert
         return IsAnOpen(AssertMessages.ReturnValue,
                         whenOpen,
                         actual)
           .And(WasInvokedOnce(nameof(whenOpen),
                               content,
                               whenOpenFunc));
      }

      Arb.Register<Libraries.TestClass>();

      Prop.ForAll<int, TestClass>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Open_of_int
   //WHEN
   //Map_AND_whenOpen_is_a_Func_of_int_to_TestStruct
   //THEN
   //whenOpen_was_invoked_with_the_content_AND_an_Open_containing_the_return_value_of_whenOpen_is_returned

   [TestMethod]
   public void
      GIVEN_Open_of_int_WHEN_Map_AND_whenOpen_is_a_Func_of_int_to_TestStruct_THEN_whenOpen_was_invoked_with_the_content_AND_an_Open_containing_the_return_value_of_whenOpen_is_returned()
   {
      static Property Property(int        content,
                               TestStruct whenOpen)
      {
         //Arrange
         var whenOpenFunc = FakeFunction<int, TestStruct>.Create(whenOpen);

         var result = new OpenResult<int>(content);

         //Act
         var actual = result.Map(whenOpenFunc.Func);

         //Assert
         return IsAnOpen(AssertMessages.ReturnValue,
                         whenOpen,
                         actual)
           .And(WasInvokedOnce(nameof(whenOpen),
                               content,
                               whenOpenFunc));
      }

      Arb.Register<Libraries.TestStruct>();

      Prop.ForAll<int, TestStruct>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}