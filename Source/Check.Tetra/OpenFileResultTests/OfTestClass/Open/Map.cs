using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.OpenFileResultTests.OfTestClass;

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
   //Open_of_TestClass
   //WHEN
   //Map_AND_whenOpen_is_a_Func_of_TestClass_to_int
   //THEN
   //whenOpen_was_invoked_with_the_content_AND_an_Open_containing_the_return_value_of_whenOpen_is_returned

   [TestMethod]
   public void
      GIVEN_Open_of_TestClass_WHEN_Map_AND_whenOpen_is_a_Func_of_TestClass_to_int_THEN_whenOpen_was_invoked_with_the_content_AND_an_Open_containing_the_return_value_of_whenOpen_is_returned()
   {
      static Property Property(TestClass content,
                               int       whenOpen)
      {
         //Arrange
         var whenOpenFunc = FakeFunction<TestClass, int>.Create(whenOpen);

         var result = new OpenResult<TestClass>(content);

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

      Prop.ForAll<TestClass, int>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Open_of_TestClass
   //WHEN
   //Map_AND_whenOpen_is_a_Func_of_TestClass_to_TestClass
   //THEN
   //whenOpen_was_invoked_with_the_content_AND_an_Open_containing_the_return_value_of_whenOpen_is_returned

   [TestMethod]
   public void
      GIVEN_Open_of_TestClass_WHEN_Map_AND_whenOpen_is_a_Func_of_TestClass_to_TestClass_THEN_whenOpen_was_invoked_with_the_content_AND_an_Open_containing_the_return_value_of_whenOpen_is_returned()
   {
      static Property Property((TestClass content, TestClass whenOpen) args)
      {
         //Arrange
         var whenOpen = FakeFunction<TestClass, TestClass>.Create(args.whenOpen);

         var result = new OpenResult<TestClass>(args.content);

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

      Arb.Register<Libraries.TwoUniqueTestClasses>();

      Prop.ForAll<(TestClass, TestClass)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Open_of_TestClass
   //WHEN
   //Map_AND_whenOpen_is_a_Func_of_TestClass_to_TestStruct
   //THEN
   //whenOpen_was_invoked_with_the_content_AND_an_Open_containing_the_return_value_of_whenOpen_is_returned

   [TestMethod]
   public void
      GIVEN_Open_of_TestClass_WHEN_Map_AND_whenOpen_is_a_Func_of_TestClass_to_TestStruct_THEN_whenOpen_was_invoked_with_the_content_AND_an_Open_containing_the_return_value_of_whenOpen_is_returned()
   {
      static Property Property(TestClass  content,
                               TestStruct whenOpen)
      {
         //Arrange
         var whenOpenFunc = FakeFunction<TestClass, TestStruct>.Create(whenOpen);

         var result = new OpenResult<TestClass>(content);

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

      Prop.ForAll<TestClass, TestStruct>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}