using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.FunctionTests;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.Function)]
// ReSharper disable once InconsistentNaming
public class False
{
   /* ------------------------------------------------------------ */
   // public static bool False()
   /* ------------------------------------------------------------ */

   //GIVEN
   //Function
   //WHEN
   //False_AND_no_arguments
   //THEN
   //false_is_returned

   [TestMethod]
   public void GIVEN_Function_WHEN_False_AND_no_arguments_THEN_false_is_returned()
   {
      //Act
      var actual = Function.False();

      //Assert
      Assert.That
            .IsFalse(AssertMessages.ReturnValue,
                     actual);
   }

   /* ------------------------------------------------------------ */
   // public static bool False<T>(T _)
   /* ------------------------------------------------------------ */

   //GIVEN
   //Function
   //WHEN
   //False_AND_discard_is_an_int
   //THEN
   //false_is_returned

   [TestMethod]
   public void GIVEN_Function_WHEN_False_AND_discard_is_an_int_THEN_false_is_returned()
   {
      static Property Property(int value)
      {
         //Act
         var actual = Function.False(value);

         //Assert
         return IsFalse(AssertMessages.ReturnValue,
                        actual);
      }

      Prop.ForAll<int>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Function
   //WHEN
   //False_AND_discard_is_a_TestClass
   //THEN
   //false_is_returned

   [TestMethod]
   public void GIVEN_Function_WHEN_False_AND_discard_is_a_TestClass_THEN_false_is_returned()
   {
      static Property Property(TestClass value)
      {
         //Act
         var actual = Function.False(value);

         //Assert
         return IsFalse(AssertMessages.ReturnValue,
                        actual);
      }

      Arb.Register<Libraries.TestClass>();

      Prop.ForAll<TestClass>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Function
   //WHEN
   //False_AND_discard_is_a_TestStruct
   //THEN
   //false_is_returned

   [TestMethod]
   public void GIVEN_Function_WHEN_False_AND_discard_is_a_TestStruct_THEN_false_is_returned()
   {
      static Property Property(TestStruct value)
      {
         //Act
         var actual = Function.False(value);

         //Assert
         return IsFalse(AssertMessages.ReturnValue,
                        actual);
      }

      Arb.Register<Libraries.TestStruct>();

      Prop.ForAll<TestStruct>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}