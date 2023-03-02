using System.ComponentModel;
using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.DataContextTests.OneWayOneWayBinding;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.DataContext)]
public class Pull
{
   /* ------------------------------------------------------------ */
   // public T Pull()
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_OneWayBinding_of_int_has_been_created
   //WHEN
   //Pull
   //THEN
   //initialValue_is_returned

   [TestMethod]
   public void GIVEN_a_OneWayBinding_of_int_has_been_created_WHEN_Pull_THEN_initialValue_is_returned()
   {
      static Property Property(string propertyName,
                               int    initialValue)
      {
         //Arrange
         var binding     = Bind.To(initialValue);
         var dataContext = TestableDataContext.Create();

         dataContext.CreateBinding(propertyName,
                                   binding as IOneWayBinding<int>);

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
   //a_OneWayBinding_of_TestClass_has_been_created
   //WHEN
   //Pull
   //THEN
   //initialValue_is_returned

   [TestMethod]
   public void GIVEN_a_OneWayBinding_of_TestClass_has_been_created_WHEN_Pull_THEN_initialValue_is_returned()
   {
      static Property Property(string    propertyName,
                               TestClass initialValue)
      {
         //Arrange
         var binding     = Bind.To(initialValue);
         var dataContext = TestableDataContext.Create();

         dataContext.CreateBinding(propertyName,
                                   binding as IOneWayBinding<TestClass>);

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
   //a_OneWayBinding_of_TestStruct_has_been_created
   //WHEN
   //Pull
   //THEN
   //initialValue_is_returned

   [TestMethod]
   public void GIVEN_a_OneWayBinding_of_TestStruct_has_been_created_WHEN_Pull_THEN_initialValue_is_returned()
   {
      static Property Property(string     propertyName,
                               TestStruct initialValue)
      {
         //Arrange
         var binding     = Bind.To(initialValue);
         var dataContext = TestableDataContext.Create();

         dataContext.CreateBinding(propertyName,
                                   binding as IOneWayBinding<TestStruct>);

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
   // Inner Binding pushed
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_OneWayBinding_of_int_has_been_created_AND_the_inner_binding_has_Push_called
   //WHEN
   //Pull
   //THEN
   //OnPropertyChanged_was_fired_once_with_propertyName_AND_newValue_is_returned

   [TestMethod]
   public void GIVEN_a_OneWayBinding_of_int_has_been_created_AND_the_inner_binding_has_Push_called_WHEN_Pull_THEN_OnPropertyChanged_was_fired_once_with_propertyName_AND_newValue_is_returned()
   {
      static Property Property(string propertyName,
                               (int    initialValue, int newValue) args)
      {
         //Arrange
         var binding           = Bind.To(args.initialValue);
         var dataContext       = TestableDataContext.Create();
         var onPropertyChanged = FakePropertyChangedEventHandler.Create(x=> dataContext.PropertyChanged += x);

         dataContext.CreateBinding(propertyName,
                                   binding as IOneWayBinding<int>);

         binding.Push(args.newValue);

         //Act
         var actual = dataContext.Pull<int>(propertyName);

         //Assert
         return WasFiredOnce(nameof(DataContext),
                             onPropertyChanged,
                             propertyName)
           .And(AreEqual(AssertMessages.ReturnValue,
                         args.newValue,
                         actual));
      }

      Arb.Register<Libraries.NonNullString>();
      Arb.Register<Libraries.TwoUniqueInt32s>();

      Prop.ForAll<string, (int, int)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //a_OneWayBinding_of_TestClass_has_been_created_AND_the_inner_binding_has_Push_called
   //WHEN
   //Pull
   //THEN
   //OnPropertyChanged_was_fired_once_with_propertyName_AND_newValue_is_returned

   [TestMethod]
   public void GIVEN_a_OneWayBinding_of_TestClass_has_been_created_AND_the_inner_binding_has_Push_called_WHEN_Pull_THEN_OnPropertyChanged_was_fired_once_with_propertyName_AND_newValue_is_returned()
   {
      static Property Property(string                           propertyName,
                               (TestClass initialValue, TestClass newValue) args)
      {
         //Arrange
         var binding           = Bind.To(args.initialValue);
         var dataContext       = TestableDataContext.Create();
         var onPropertyChanged = FakePropertyChangedEventHandler.Create(x => dataContext.PropertyChanged += x);

         dataContext.CreateBinding(propertyName,
                                   binding as IOneWayBinding<TestClass>);

         binding.Push(args.newValue);

         //Act
         var actual = dataContext.Pull<TestClass>(propertyName);

         //Assert
         return WasFiredOnce(nameof(DataContext),
                             onPropertyChanged,
                             propertyName)
           .And(AreEqual(AssertMessages.ReturnValue,
                         args.newValue,
                         actual));
      }

      Arb.Register<Libraries.NonNullString>();
      Arb.Register<Libraries.TwoUniqueTestClasses>();

      Prop.ForAll<string, (TestClass, TestClass)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //a_OneWayBinding_of_TestStruct_has_been_created_AND_the_inner_binding_has_Push_called
   //WHEN
   //Pull
   //THEN
   //OnPropertyChanged_was_fired_once_with_propertyName_AND_newValue_is_returned

   [TestMethod]
   public void GIVEN_a_OneWayBinding_of_TestStruct_has_been_created_AND_the_inner_binding_has_Push_called_WHEN_Pull_THEN_OnPropertyChanged_was_fired_once_with_propertyName_AND_newValue_is_returned()
   {
      static Property Property(string                           propertyName,
                               (TestStruct initialValue, TestStruct newValue) args)
      {
         //Arrange
         var binding           = Bind.To(args.initialValue);
         var dataContext       = TestableDataContext.Create();
         var onPropertyChanged = FakePropertyChangedEventHandler.Create(x => dataContext.PropertyChanged += x);

         dataContext.CreateBinding(propertyName,
                                   binding as IOneWayBinding<TestStruct>);

         binding.Push(args.newValue);

         //Act
         var actual = dataContext.Pull<TestStruct>(propertyName);

         //Assert
         return WasFiredOnce(nameof(DataContext),
                             onPropertyChanged,
                             propertyName)
           .And(AreEqual(AssertMessages.ReturnValue,
                         args.newValue,
                         actual));
      }

      Arb.Register<Libraries.NonNullString>();
      Arb.Register<Libraries.TwoUniqueTestStructs>();

      Prop.ForAll<string, (TestStruct, TestStruct)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}