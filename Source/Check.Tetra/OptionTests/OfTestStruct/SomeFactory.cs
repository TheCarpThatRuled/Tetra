using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.OptionTests.OfTestStruct;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.Option)]
// ReSharper disable once InconsistentNaming
public class SomeFactory
{
   /* ------------------------------------------------------------ */
   // public static Option<T> Some(T content)
   /* ------------------------------------------------------------ */

   //GIVEN
   //Option_of_TestStruct
   //WHEN
   //Some
   //THEN
   //a_some_containing_content_is_returned

   [TestMethod]
   public void GIVEN_Option_of_TestStruct_WHEN_Some_THEN_a_some_containing_content_is_returned()
   {
      static Property Property(TestStruct value)
      {
         //Act
         var actual = Option<TestStruct>.Some(value);

         //Assert
         return IsASome(AssertMessages.ReturnValue,
                        value,
                        actual);
      }

      Arb.Register<Libraries.TestStruct>();

      Prop.ForAll<TestStruct>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // public static Option<T> Some<T>(T content)
   /* ------------------------------------------------------------ */

   //GIVEN
   //Option
   //WHEN
   //Some_of_TestStruct
   //THEN
   //a_some_containing_content_is_returned

   [TestMethod]
   public void GIVEN_Option_WHEN_Some_of_TestStruct_THEN_a_some_containing_content_is_returned()
   {
      static Property Property(TestStruct value)
      {
         //Act
         var actual = Option.Some(value);

         //Assert
         return IsASome(AssertMessages.ReturnValue,
                        value,
                        actual);
      }

      Arb.Register<Libraries.TestStruct>();

      Prop.ForAll<TestStruct>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}