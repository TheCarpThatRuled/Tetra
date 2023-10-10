using FsCheck;
using static Tetra.Testing.Properties;

namespace Check.FunctionTests;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.Function)]
// ReSharper disable once InconsistentNaming
public class PassThrough
{
   /* ------------------------------------------------------------ */
   // public static T PassThrough<T>(T value)
   /* ------------------------------------------------------------ */

   //GIVEN
   //Function
   //WHEN
   //PassThrough_AND_value_is_an_int
   //THEN
   //value_is_returned

   [TestMethod]
   public void GIVEN_Function_WHEN_PassThrough_AND_value_is_an_int_THEN_value_is_returned()
   {
      static Property Property
      (
         int value
      )
      {
         //Act
         var actual = Function.PassThrough(value);

         //Assert
         return AreEqual("The same value was not returned",
                         value,
                         actual);
      }

      Prop.ForAll<int>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Function
   //WHEN
   //PassThrough_AND_value_is_a_TestClass
   //THEN
   //value_is_returned

   [TestMethod]
   public void GIVEN_Function_WHEN_PassThrough_AND_value_is_a_TestClass_THEN_value_is_returned()
   {
      static Property Property
      (
         TestClass value
      )
      {
         //Act
         var actual = Function.PassThrough(value);

         //Assert
         return AreEqual("The same value was not returned",
                         value,
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
   //PassThrough_AND_value_is_a_TestStruct
   //THEN
   //value_is_returned

   [TestMethod]
   public void GIVEN_Function_WHEN_PassThrough_AND_value_is_a_TestStruct_THEN_value_is_returned()
   {
      static Property Property
      (
         TestStruct value
      )
      {
         //Act
         var actual = Function.PassThrough(value);

         //Assert
         return AreEqual("The same value was not returned",
                         value,
                         actual);
      }

      Arb.Register<Libraries.TestStruct>();

      Prop.ForAll<TestStruct>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}