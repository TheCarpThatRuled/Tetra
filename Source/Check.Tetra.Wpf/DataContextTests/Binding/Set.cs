using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.DataContextTests.Binding;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.DataContext)]
public class Set
{
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_Binding_of_int_has_been_created
   //WHEN
   //Set
   //THEN
   //OnPropertyChanged_was_not_fired_AND_Pull_returns_newValue

   [TestMethod]
   public void GIVEN_a_Binding_of_int_has_been_created_WHEN_Set_THEN_OnPropertyChanged_was_not_fired_AND_Pull_returns_newValue()
   {
      static Property Property(string                           propertyName,
                               (int initialValue, int newValue) args)
      {
         //Arrange

         var dataContext       = TestableDataContext.Create();
         var onPropertyChanged = FakePropertyChangedEventHandler.Create(handler => dataContext.PropertyChanged += handler);

         dataContext.CreateBinding(propertyName,
                                   args.initialValue);

         //Act
         dataContext.Set(propertyName,
                         args.newValue);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         args.newValue,
                         dataContext.Pull<int>(propertyName))
           .And(WasNotFired(nameof(DataContext),
                            onPropertyChanged));
         ;
      }

      Arb.Register<Libraries.NonNullString>();
      Arb.Register<Libraries.TwoUniqueInt32s>();

      Prop.ForAll<string, (int, int)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //a_Binding_of_TestClass_has_been_created
   //WHEN
   //Set
   //THEN
   //OnPropertyChanged_was_not_fired_AND_Pull_returns_newValue

   [TestMethod]
   public void GIVEN_a_Binding_of_TestClass_has_been_created_WHEN_Set_THENOnPropertyChanged_was_not_fired_AND__Pull_returns_newValue()
   {
      static Property Property(string                                       propertyName,
                               (TestClass initialValue, TestClass newValue) args)
      {
         //Arrange
         var dataContext       = TestableDataContext.Create();
         var onPropertyChanged = FakePropertyChangedEventHandler.Create(handler => dataContext.PropertyChanged += handler);

         dataContext.CreateBinding(propertyName,
                                   args.initialValue);

         //Act
         dataContext.Set(propertyName,
                         args.newValue);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         args.newValue,
                         dataContext.Pull<TestClass>(propertyName))
           .And(WasNotFired(nameof(DataContext),
                            onPropertyChanged));
         ;
      }

      Arb.Register<Libraries.NonNullString>();
      Arb.Register<Libraries.TwoUniqueTestClasses>();

      Prop.ForAll<string, (TestClass, TestClass)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //a_Binding_of_TestStruct_has_been_created
   //WHEN
   //Set
   //THEN
   //OnPropertyChanged_was_not_fired_AND_Pull_returns_newValue

   [TestMethod]
   public void GIVEN_a_Binding_of_TestStruct_has_been_created_WHEN_Set_THENOnPropertyChanged_was_not_fired_AND__Pull_returns_newValue()
   {
      static Property Property(string                                         propertyName,
                               (TestStruct initialValue, TestStruct newValue) args)
      {
         //Arrange
         var dataContext       = TestableDataContext.Create();
         var onPropertyChanged = FakePropertyChangedEventHandler.Create(handler => dataContext.PropertyChanged += handler);

         dataContext.CreateBinding(propertyName,
                                   args.initialValue);

         //Act
         dataContext.Set(propertyName,
                         args.newValue);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         args.newValue,
                         dataContext.Pull<TestStruct>(propertyName))
           .And(WasNotFired(nameof(DataContext),
                            onPropertyChanged));
      }

      Arb.Register<Libraries.NonNullString>();
      Arb.Register<Libraries.TwoUniqueTestStructs>();

      Prop.ForAll<string, (TestStruct, TestStruct)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}