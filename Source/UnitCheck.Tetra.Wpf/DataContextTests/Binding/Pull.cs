using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.DataContextTests.Binding;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.DataContext)]
public class Pull
{
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_Binding_of_int_has_been_created
   //WHEN
   //Pull
   //THEN
   //initialValue_is_returned

   [TestMethod]
   public void GIVEN_a_Binding_of_int_has_been_created_WHEN_Pull_THEN_initialValue_is_returned()
   {
      static Property Property(string propertyName,
                               int    initialValue)
      {
         //Arrange
         var dataContext = TestableDataContext.Create();

         dataContext.CreateBinding(propertyName,
                                   initialValue);

         //Act
         var actual = dataContext.Pull<int>(propertyName);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         initialValue,
                         actual);
      }

      Arb.Register<Libraries.NonNullString>();

      Prop.ForAll<string, int>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //a_Binding_of_TestClass_has_been_created
   //WHEN
   //Pull
   //THEN
   //initialValue_is_returned

   [TestMethod]
   public void GIVEN_a_Binding_of_TestClass_has_been_created_WHEN_Pull_THEN_initialValue_is_returned()
   {
      static Property Property(string    propertyName,
                               TestClass initialValue)
      {
         //Arrange
         var dataContext = TestableDataContext.Create();

         dataContext.CreateBinding(propertyName,
                                   initialValue);

         //Act
         var actual = dataContext.Pull<TestClass>(propertyName);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         initialValue,
                         actual);
      }

      Arb.Register<Libraries.NonNullString>();
      Arb.Register<Libraries.TestClass>();

      Prop.ForAll<string, TestClass>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //a_Binding_of_TestStruct_has_been_created
   //WHEN
   //Pull
   //THEN
   //initialValue_is_returned

   [TestMethod]
   public void GIVEN_a_Binding_of_TestStruct_has_been_created_WHEN_Pull_THEN_initialValue_is_returned()
   {
      static Property Property(string    propertyName,
                               TestStruct initialValue)
      {
         //Arrange
         var dataContext = TestableDataContext.Create();

         dataContext.CreateBinding(propertyName,
                                   initialValue);

         //Act
         var actual = dataContext.Pull<TestStruct>(propertyName);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         initialValue,
                         actual);
      }

      Arb.Register<Libraries.NonNullString>();
      Arb.Register<Libraries.TestStruct>();

      Prop.ForAll<string, TestStruct>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}