using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.OptionTests.OfTestClass;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.Option)]
// ReSharper disable once InconsistentNaming
public class SomeFactory
{
   /* ------------------------------------------------------------ */
   // Option<T> Some(T content)
   /* ------------------------------------------------------------ */

   //GIVEN
   //Option_of_TestClass
   //WHEN
   //Some
   //THEN
   //a_some_containing_content_is_returned

   [TestMethod]
   public void GIVEN_Option_of_TestClass_WHEN_Some_THEN_a_some_containing_content_is_returned()
   {
      static Property Property(TestClass value)
      {
         //Act
         var actual = Option<TestClass>.Some(value);

         //Assert
         return IsASome(AssertMessages.ReturnValue,
                        value,
                        actual);
      }

      Arb.Register<Libraries.TestClass>();

      Prop.ForAll<TestClass>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // Option<T> Some<T>(T content)
   /* ------------------------------------------------------------ */

   //GIVEN
   //Option
   //WHEN
   //Some_of_TestClass
   //THEN
   //a_some_containing_content_is_returned

   [TestMethod]
   public void GIVEN_Option_WHEN_Some_of_TestClass_THEN_a_some_containing_content_is_returned()
   {
      static Property Property(TestClass value)
      {
         //Act
         var actual = Option.Some(value);

         //Assert
         return IsASome(AssertMessages.ReturnValue,
                        value,
                        actual);
      }

      Arb.Register<Libraries.TestClass>();

      Prop.ForAll<TestClass>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}