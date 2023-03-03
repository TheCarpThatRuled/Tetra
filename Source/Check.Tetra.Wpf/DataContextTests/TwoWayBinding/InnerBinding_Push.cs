using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.DataContextTests.TwoWayBinding;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.DataContext)]
// ReSharper disable once InconsistentNaming
public class InnerBinding_Push
{
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_TwoWayBinding_of_int_has_been_created
   //WHEN
   //the_inner_binding_has_Push_called
   //THEN
   //OnPropertyChanged_was_fired_once_with_propertyName_AND_Pull_returns_newValue

   [TestMethod]
   public void GIVEN_a_TwoWayBinding_of_int_has_been_created_the_inner_binding_has_Push_called_THEN_OnPropertyChanged_was_fired_once_with_propertyName_AND_Pull_returns_newValue()
   {
      static Property Property(string                           propertyName,
                               (int initialValue, int newValue) args)
      {
         //Arrange
         var binding           = Bind.To(args.initialValue);
         var dataContext       = TestableDataContext.Create();
         var onPropertyChanged = FakePropertyChangedEventHandler.Create(x => dataContext.PropertyChanged += x);

         dataContext.CreateBinding(propertyName,
                                   binding);

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
   //a_TwoWayBinding_of_TestClass_has_been_created
   //WHEN
   //the_inner_binding_has_Push_called
   //THEN
   //OnPropertyChanged_was_fired_once_with_propertyName_AND_Pull_returns_newValue

   [TestMethod]
   public void
      GIVEN_a_TwoWayBinding_of_TestClass_has_been_created_the_inner_binding_has_Push_called_THEN_OnPropertyChanged_was_fired_once_with_propertyName_AND_Pull_returns_newValue()
   {
      static Property Property(string                                       propertyName,
                               (TestClass initialValue, TestClass newValue) args)
      {
         //Arrange
         var binding           = Bind.To(args.initialValue);
         var dataContext       = TestableDataContext.Create();
         var onPropertyChanged = FakePropertyChangedEventHandler.Create(x => dataContext.PropertyChanged += x);

         dataContext.CreateBinding(propertyName,
                                   binding);


         //Act
         binding.Push(args.newValue);

         //Assert
         return WasFiredOnce(nameof(DataContext),
                             onPropertyChanged,
                             propertyName)
           .And(AreEqual(AssertMessages.ReturnValue,
                         args.newValue,
                         dataContext.Pull<TestClass>(propertyName)));
      }

      Arb.Register<Libraries.NonNullString>();
      Arb.Register<Libraries.TwoUniqueTestClasses>();

      Prop.ForAll<string, (TestClass, TestClass)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //a_TwoWayBinding_of_TestStruct_has_been_created
   //WHEN
   //the_inner_binding_has_Push_called
   //THEN
   //OnPropertyChanged_was_fired_once_with_propertyName_AND_Pull_returns_newValue

   [TestMethod]
   public void
      GIVEN_a_TwoWayBinding_of_TestStruct_has_been_created_the_inner_binding_has_Push_called_THEN_OnPropertyChanged_was_fired_once_with_propertyName_AND_Pull_returns_newValue()
   {
      static Property Property(string                                         propertyName,
                               (TestStruct initialValue, TestStruct newValue) args)
      {
         //Arrange
         var binding           = Bind.To(args.initialValue);
         var dataContext       = TestableDataContext.Create();
         var onPropertyChanged = FakePropertyChangedEventHandler.Create(x => dataContext.PropertyChanged += x);

         dataContext.CreateBinding(propertyName,
                                   binding);

         //Act
         binding.Push(args.newValue);

         //Assert
         return WasFiredOnce(nameof(DataContext),
                             onPropertyChanged,
                             propertyName)
           .And(AreEqual(AssertMessages.ReturnValue,
                         args.newValue,
                         dataContext.Pull<TestStruct>(propertyName)));
      }

      Arb.Register<Libraries.NonNullString>();
      Arb.Register<Libraries.TwoUniqueTestStructs>();

      Prop.ForAll<string, (TestStruct, TestStruct)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}