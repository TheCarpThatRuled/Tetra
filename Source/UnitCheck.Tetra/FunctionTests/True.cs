using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.FunctionTests;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.Function)]
// ReSharper disable once InconsistentNaming
public class True
{
   /* ------------------------------------------------------------ */
   // public static bool True()
   /* ------------------------------------------------------------ */

   //GIVEN
   //Function
   //WHEN
   //True_AND_no_arguments
   //THEN
   //true_is_returned

   [TestMethod]
   public void GIVEN_Function_WHEN_True_AND_no_arguments_THEN_true_is_returned()
   {
      //Act
      var actual = Function.True();

      //Assert
      Assert.That
            .IsTrue(AssertMessages.ReturnValue,
                    actual);
   }

   /* ------------------------------------------------------------ */
   // public static bool True<T>(T _)
   /* ------------------------------------------------------------ */

   //GIVEN
   //Function
   //WHEN
   //True_AND_discard_is_an_int
   //THEN
   //true_is_returned

   [TestMethod]
   public void GIVEN_Function_WHEN_True_AND_discard_is_an_int_THEN_true_is_returned()
   {
      static Property Property(int value)
      {
         //Act
         var actual = Function.True(value);

         //Assert
         return IsTrue(AssertMessages.ReturnValue,
                       actual);
      }

      Prop.ForAll<int>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Function
   //WHEN
   //True_AND_discard_is_a_TestClass
   //THEN
   //true_is_returned

   [TestMethod]
   public void GIVEN_Function_WHEN_True_AND_discard_is_a_TestClass_THEN_true_is_returned()
   {
      static Property Property(TestClass value)
      {
         //Act
         var actual = Function.True(value);

         //Assert
         return IsTrue(AssertMessages.ReturnValue,
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
   //True_AND_discard_is_a_TestStruct
   //THEN
   //true_is_returned

   [TestMethod]
   public void GIVEN_Function_WHEN_True_AND_discard_is_a_TestStruct_THEN_true_is_returned()
   {
      static Property Property(TestStruct value)
      {
         //Act
         var actual = Function.True(value);

         //Assert
         return IsTrue(AssertMessages.ReturnValue,
                       actual);
      }

      Arb.Register<Libraries.TestStruct>();

      Prop.ForAll<TestStruct>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}