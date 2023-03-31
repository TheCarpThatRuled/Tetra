using FsCheck;
using static Tetra.Testing.Properties;

namespace Check.ResultTests.OfTestClass;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.Result)]
// ReSharper disable once InconsistentNaming
public class Equals
{
   /* ------------------------------------------------------------ */
   // bool Equals(object? obj);
   /* ------------------------------------------------------------ */

   //GIVEN
   //Result_of_TestClass_AND_obj_is_null_or_a_non_equatable_type
   //WHEN
   //Equals_AND_obj_is_a_nullable_object
   //THEN
   //false_is_returned

   [TestMethod]
   public void
      GIVEN_Result_of_TestClass_AND_obj_is_null_or_a_non_equatable_type_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_false_is_returned()
   {
      static Property Property(IResult<TestClass> result,
                               object? obj)
      {
         //Act
         var actual = result.Equals(obj);

         //Assert
         return IsFalse(AssertMessages.ReturnValue,
                        actual);
      }

      Arb.Register<Libraries.ResultOfTestClass>();
      Arb.Register<ObjIsNullOrANonEquatableType>();

      Prop.ForAll<IResult<TestClass>, object?>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   // ReSharper disable once ClassNeverInstantiated.Local
   // ReSharper disable once InconsistentNaming
   private sealed class ObjIsNullOrANonEquatableType
   {
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      // ReSharper disable once UnusedMember.Local
      public static Arbitrary<object?> Obj()
         => Gen
           .OneOf(Gen.Constant(default(object?)),
                  Generators.TestStruct()
                            .Select(x => (object?)x),
                  Generators.UInt32()
                            .Select(x => (object?)x),
                  Generators.String()
                            .Select(x => (object?)x),
                  Generators.Result(Generators.Int32())
                            .Select(x => (object?)x),
                  Generators.Result(Generators.TestStruct())
                            .Select(x => (object?)x))
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Result_of_TestClass_AND_this_is_a_success
   //WHEN
   //Equals_AND_obj_is_a_nullable_object
   //THEN
   //is_reflexive

   [TestMethod]
   public void GIVEN_Result_of_TestClass_AND_this_is_a_success_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_is_reflexive()
   {
      //Arrange
      var original = Result<TestClass>.Success();
      var copy     = Result<TestClass>.Success();

      //Act
      //Assert
      Assert.That
            .EqualsIsReflexive(original,
                               copy);
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Result_of_TestClass_AND_this_is_a_failure
   //WHEN
   //Equals_AND_obj_is_a_nullable_object
   //THEN
   //is_reflexive

   [TestMethod]
   public void GIVEN_Result_of_TestClass_AND_this_is_a_failure_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_is_reflexive()
   {
      static Property Property(TestClass value)
      {
         //Arrange
         var original = Tetra.Result.Failure(value);
         var copy     = Tetra.Result.Failure(value);

         //Act
         //Assert
         return EqualsIsReflexive(original,
                                  copy,
                                  value);
      }

      Arb.Register<Libraries.TestClass>();

      Prop.ForAll<TestClass>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Result_of_TestClass
   //WHEN
   //Equals_AND_obj_is_a_nullable_object
   //THEN
   //is_symmetric

   [TestMethod]
   public void GIVEN_Result_of_TestClass_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_is_symmetric()
   {
      Arb.Register<Libraries.ResultOfTestClass>();

      Prop.ForAll<IResult<TestClass>, IResult<TestClass>>(EqualsIsSymmetric)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Result_of_TestClass
   //WHEN
   //Equals
   //AND
   //obj_is_a_nullable_object
   //THEN
   //is_transitive

   [TestMethod]
   public void GIVEN_Result_of_TestClass_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_is_transitive()
   {
      Arb.Register<Libraries.TransitiveResultsOfTestClass>();

      Prop.ForAll<(IResult<TestClass>, IResult<TestClass>, IResult<TestClass>)>(EqualsIsTransitive<IResult<TestClass>>)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Result_of_TestClass_AND_obj_is_a_TestStruct
   //WHEN
   //Equals
   //AND
   //obj_is_a_nullable_object
   //THEN
   //is_transitive

   [TestMethod]
   public void GIVEN_Result_of_TestClass_AND_obj_is_a_TestStruct_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_is_transitive()
   {
      Arb.Register<Library_ResultOfTestClass_AND_ObjIsATestClass>();

      Prop.ForAll<(IResult<TestClass>, TestClass, TestClass)>(EqualsIsTransitive)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   // ReSharper disable once ClassNeverInstantiated.Local
   // ReSharper disable once InconsistentNaming
   private sealed class Library_ResultOfTestClass_AND_ObjIsATestClass
   {
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      // ReSharper disable once UnusedMember.Local
      public static Arbitrary<(IResult<TestClass>, TestClass, TestClass)> Type()
         => Generators
           .TransitiveResultsAndT(Generators.TestClass(),
                                 Generators.TwoUniqueTestClasses())
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */
}