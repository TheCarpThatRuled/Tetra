using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.BindTests.ToTests;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.Bind)]
public class To
{
   /* ------------------------------------------------------------ */
   // public static ITwoWayBinding<T> To<T>(T initialValue)
   /* ------------------------------------------------------------ */

   //GIVEN
   //an_int
   //WHEN
   //To_of_int
   //THEN
   //a_ITwoWayBinding_containing_initialValue_is_returned

   [TestMethod]
   public void GIVEN_an_int_WHEN_To_of_int_THEN_a_ITwoWayBinding_containing_initialValue_is_returned()
   {
      static Property Property(int value)
      {
         //Arrange
         //Act
         var actual = Bind.To(value);

         //Assert
         return AreEqual(nameof(ITwoWayBinding<int>.Pull),
                         value,
                         actual.Pull());
      }

      Prop.ForAll<int>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //a_TestClass
   //WHEN
   //To_of_TestClass
   //THEN
   //a_ITwoWayBinding_containing_initialValue_is_returned

   [TestMethod]
   public void GIVEN_a_TestClass_WHEN_To_of_TestClass_THEN_a_ITwoWayBinding_containing_initialValue_is_returned()
   {
      static Property Property(TestClass value)
      {
         //Arrange
         //Act
         var actual = Bind.To(value);

         //Assert
         return AreEqual(nameof(ITwoWayBinding<TestClass>.Pull),
                         value,
                         actual.Pull());
      }

      Arb.Register<Libraries.TestClass>();

      Prop.ForAll<TestClass>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //a_TestStruct
   //WHEN
   //To_of_TestStruct
   //THEN
   //a_ITwoWayBinding_containing_initialValue_is_returned

   [TestMethod]
   public void GIVEN_a_TestStruct_WHEN_To_of_TestStruct_THEN_a_ITwoWayBinding_containing_initialValue_is_returned()
   {
      static Property Property(TestStruct value)
      {
         //Arrange
         //Act
         var actual = Bind.To(value);

         //Assert
         return AreEqual(nameof(ITwoWayBinding<TestStruct>.Pull),
                         value,
                         actual.Pull());
      }

      Arb.Register<Libraries.TestStruct>();

      Prop.ForAll<TestStruct>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}