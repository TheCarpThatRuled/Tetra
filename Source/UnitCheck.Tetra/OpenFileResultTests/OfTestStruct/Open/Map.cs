using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.OpenFileResultTests.OfTestStruct;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.OpenFileResult)]
// ReSharper disable once InconsistentNaming
public class Open_Map
{
   /* ------------------------------------------------------------ */
   // IOpenFileResult<TNew> Map<TNew>(Func<T, TNew> whenOpen);
   /* ------------------------------------------------------------ */

   //GIVEN
   //Open_of_TestStruct
   //WHEN
   //Map_AND_whenOpen_is_a_Func_of_TestStruct_to_int
   //THEN
   //whenOpen_was_invoked_with_the_content_AND_an_Open_containing_the_return_value_of_whenOpen_is_returned

   [TestMethod]
   public void
      GIVEN_Open_of_TestStruct_WHEN_Map_AND_whenOpen_is_a_Func_of_TestStruct_to_int_THEN_whenOpen_was_invoked_with_the_content_AND_an_Open_containing_the_return_value_of_whenOpen_is_returned()
   {
      static Property Property(TestStruct content,
                               int        whenOpen)
      {
         //Arrange
         var whenOpenFunc = FakeFunction<TestStruct, int>.Create(whenOpen);

         var result = new OpenResult<TestStruct>(content);

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

      Arb.Register<Libraries.ThreeUniqueInt32s>();

      Prop.ForAll<TestStruct, int>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Open_of_TestStruct
   //WHEN
   //Map_AND_whenOpen_is_a_Func_of_TestStruct_to_TestClass
   //THEN
   //whenOpen_was_invoked_with_the_content_AND_an_Open_containing_the_return_value_of_whenOpen_is_returned

   [TestMethod]
   public void
      GIVEN_Open_of_TestStruct_WHEN_Map_AND_whenOpen_is_a_Func_of_TestStruct_to_TestClass_THEN_whenOpen_was_invoked_with_the_content_AND_an_Open_containing_the_return_value_of_whenOpen_is_returned()
   {
      static Property Property(TestStruct content,
                               TestClass  whenOpen)
      {
         //Arrange
         var whenOpenFunc = FakeFunction<TestStruct, TestClass>.Create(whenOpen);

         var result = new OpenResult<TestStruct>(content);

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
      Arb.Register<Libraries.TestStruct>();

      Prop.ForAll<TestStruct, TestClass>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Open_of_TestStruct
   //WHEN
   //Map_AND_whenOpen_is_a_Func_of_TestStruct_to_TestStruct
   //THEN
   //whenOpen_was_invoked_with_the_content_AND_an_Open_containing_the_return_value_of_whenOpen_is_returned

   [TestMethod]
   public void
      GIVEN_Open_of_TestStruct_WHEN_Map_AND_whenOpen_is_a_Func_of_TestStruct_to_TestStruct_THEN_whenOpen_was_invoked_with_the_content_AND_an_Open_containing_the_return_value_of_whenOpen_is_returned()
   {
      static Property Property((TestStruct content, TestStruct whenOpen) args)
      {
         //Arrange
         var whenOpen = FakeFunction<TestStruct, TestStruct>.Create(args.whenOpen);

         var result = new OpenResult<TestStruct>(args.content);

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

      Arb.Register<Libraries.TwoUniqueTestStructs>();

      Prop.ForAll<(TestStruct, TestStruct)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}