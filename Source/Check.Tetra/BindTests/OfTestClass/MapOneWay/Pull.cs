﻿using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.BindTests.OfTestClass.MapOneWay;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.Bind)]
public class Pull
{
   /* ------------------------------------------------------------ */
   // public T Pull()
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_Binding_of_TestClass_mapped_with_a_Func_of_TestClass_to_int
   //WHEN
   //Pull
   //THEN
   //mapFrom_was_invoked_once_with_inner_value_AND_outerValue_is_returned

   [TestMethod]
   public void GIVEN_a_Binding_of_TestClass_mapped_with_a_Func_of_TestClass_to_int_WHEN_Pull_THEN_mapFrom_was_invoked_once_with_inner_value_AND_outerValue_is_returned()
   {
      static Property Property(TestClass innerValue,
                               int       outerValue)
      {
         //Arrange
         var innerBinding = Bind.To(innerValue);
         var mapFrom      = FakeFunction<TestClass, int>.Create(outerValue);

         var outerBinding = innerBinding.Map(mapFrom.Func);

         //Act
         var actual = outerBinding.Pull();

         //Assert
         return WasInvokedOnce(nameof(mapFrom),
                               innerValue,
                               mapFrom)
           .And(AreEqual(nameof(IOneWayBinding<int>.Pull),
                         outerValue,
                         actual));
      }

      Arb.Register<Libraries.TestClass>();

      Prop.ForAll<TestClass, int>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //a_Binding_of_TestClass_AND_a_Func_of_TestClass_to_TestClass
   //WHEN
   //Pull
   //THEN
   //mapFrom_was_invoked_once_with_inner_value_AND_outerValue_is_returned

   [TestMethod]
   public void GIVEN_a_Binding_of_TestClass_mapped_with_a_Func_of_TestClass_to_TestClass_WHEN_Pull_THEN_mapFrom_was_invoked_once_with_inner_value_AND_outerValue_is_returned()
   {
      static Property Property((TestClass innerValue, TestClass outerValue) args)
      {
         //Arrange
         var innerBinding = Bind.To(args.innerValue);
         var mapFrom      = FakeFunction<TestClass, TestClass>.Create(args.outerValue);

         var outerBinding = innerBinding.Map(mapFrom.Func);

         //Act
         var actual = outerBinding.Pull();

         //Assert
         return WasInvokedOnce(nameof(mapFrom),
                               args.innerValue,
                               mapFrom)
           .And(AreEqual(nameof(IOneWayBinding<TestClass>.Pull),
                         args.outerValue,
                         actual));
      }

      Arb.Register<Libraries.TwoUniqueTestClasses>();

      Prop.ForAll<(TestClass, TestClass )>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //a_Binding_of_TestClass_AND_a_Func_of_TestClass_to_TestStruct
   //WHEN
   //Pull
   //THEN
   //mapFrom_was_invoked_once_with_inner_value_AND_outerValue_is_returned

   [TestMethod]
   public void GIVEN_a_Binding_of_TestClass_mapped_with_a_Func_of_TestClass_to_TestStruct_WHEN_Pull_THEN_mapFrom_was_invoked_once_with_inner_value_AND_outerValue_is_returned()
   {
      static Property Property(TestClass  innerValue,
                               TestStruct outerValue)
      {
         //Arrange
         var innerBinding = Bind.To(innerValue);
         var mapFrom      = FakeFunction<TestClass, TestStruct>.Create(outerValue);

         var outerBinding = innerBinding.Map(mapFrom.Func);

         //Act
         var actual = outerBinding.Pull();

         //Assert
         return WasInvokedOnce(nameof(mapFrom),
                               innerValue,
                               mapFrom)
           .And(AreEqual(nameof(IOneWayBinding<TestStruct>.Pull),
                         outerValue,
                         actual));
      }

      Arb.Register<Libraries.TestClass>();
      Arb.Register<Libraries.TestStruct>();

      Prop.ForAll<TestClass, TestStruct>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // Inner binding pushes
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_Binding_of_TestClass_mapped_with_a_Func_of_TestClass_to_int_AND_the_inner_binding_has_Push_called
   //WHEN
   //Pull
   //THEN
   //updated_was_invoked_once_AND_mapFrom_was_invoked_once_with_inner_value_AND_outerValue_is_returned

   [TestMethod]
   public void
      GIVEN_a_Binding_of_TestClass_mapped_with_a_Func_of_TestClass_to_int_AND_the_inner_binding_has_Push_called_WHEN_Pull_THEN_updated_was_invoked_once_AND_mapFrom_was_invoked_once_with_inner_value_AND_outerValue_is_returned()
   {
      static Property Property((TestClass firstInnerValue, TestClass secondInnerValue) args,
                               int                                                     outerValue)
      {
         //Arrange
         var innerBinding = Bind.To(args.firstInnerValue);
         var mapFrom      = FakeFunction<TestClass, int>.Create(outerValue);
         var updated      = FakeAction.Create();

         var outerBinding = innerBinding.Map(mapFrom.Func);
         outerBinding.OnUpdated(updated.Action);

         innerBinding.Push(args.secondInnerValue);

         //Act
         var actual = outerBinding.Pull();

         //Assert
         return WasInvokedOnce(nameof(updated),
                               updated)
               .And(WasInvokedOnce(nameof(mapFrom),
                                   args.secondInnerValue,
                                   mapFrom))
               .And(AreEqual(nameof(IOneWayBinding<int>.Pull),
                             outerValue,
                             actual));
      }

      Arb.Register<Libraries.TwoUniqueTestClasses>();

      Prop.ForAll<(TestClass, TestClass), int>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //a_Binding_of_TestClass_mapped_with_a_Func_of_TestClass_to_TestClass_AND_the_inner_binding_has_Push_called
   //WHEN
   //Pull
   //THEN
   //updated_was_invoked_once_AND_mapFrom_was_invoked_once_with_inner_value_AND_outerValue_is_returned

   [TestMethod]
   public void
      GIVEN_a_Binding_of_TestClass_mapped_with_a_Func_of_TestClass_to_TestClass_AND_the_inner_binding_has_Push_called_WHEN_Pull_THEN_updated_was_invoked_once_AND_mapFrom_was_invoked_once_with_inner_value_AND_outerValue_is_returned()
   {
      static Property Property((TestClass firstInnerValue, TestClass secondInnerValue, TestClass outerValue) args)
      {
         //Arrange
         var innerBinding = Bind.To(args.firstInnerValue);
         var mapFrom      = FakeFunction<TestClass, TestClass>.Create(args.outerValue);
         var updated      = FakeAction.Create();

         var outerBinding = innerBinding.Map(mapFrom.Func);
         outerBinding.OnUpdated(updated.Action);

         innerBinding.Push(args.secondInnerValue);

         //Act
         var actual = outerBinding.Pull();

         //Assert
         return WasInvokedOnce(nameof(updated),
                               updated)
               .And(WasInvokedOnce(nameof(mapFrom),
                                   args.secondInnerValue,
                                   mapFrom))
               .And(AreEqual(nameof(IOneWayBinding<TestClass>.Pull),
                             args.outerValue,
                             actual));
      }

      Arb.Register<Libraries.ThreeUniqueTestClasses>();

      Prop.ForAll<(TestClass, TestClass, TestClass)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //a_Binding_of_TestClass_mapped_with_a_Func_of_TestClass_to_TestStruct_AND_the_inner_binding_has_Push_called
   //WHEN
   //Pull
   //THEN
   //updated_was_invoked_once_AND_mapFrom_was_invoked_once_with_inner_value_AND_outerValue_is_returned

   [TestMethod]
   public void
      GIVEN_a_Binding_of_TestClass_mapped_with_a_Func_of_TestClass_to_TestStruct_AND_the_inner_binding_has_Push_called_WHEN_Pull_THEN_updated_was_invoked_once_AND_mapFrom_was_invoked_once_with_inner_value_AND_outerValue_is_returned()
   {
      static Property Property((TestClass firstInnerValue, TestClass secondInnerValue) args,
                               TestStruct                                              outerValue)
      {
         //Arrange
         var innerBinding = Bind.To(args.firstInnerValue);
         var mapFrom      = FakeFunction<TestClass, TestStruct>.Create(outerValue);
         var updated      = FakeAction.Create();

         var outerBinding = innerBinding.Map(mapFrom.Func);
         outerBinding.OnUpdated(updated.Action);

         innerBinding.Push(args.secondInnerValue);

         //Act
         var actual = outerBinding.Pull();

         //Assert
         return WasInvokedOnce(nameof(updated),
                               updated)
               .And(WasInvokedOnce(nameof(mapFrom),
                                   args.secondInnerValue,
                                   mapFrom))
               .And(AreEqual(nameof(IOneWayBinding<TestStruct>.Pull),
                             outerValue,
                             actual));
      }

      Arb.Register<Libraries.TestStruct>();
      Arb.Register<Libraries.TwoUniqueTestClasses>();

      Prop.ForAll<(TestClass, TestClass), TestStruct>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}