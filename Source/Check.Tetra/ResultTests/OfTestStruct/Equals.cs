using FsCheck;
using static Tetra.Testing.Properties;

namespace Check.ResultTests.OfTestStruct;

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
   //Result_of_TestStruct_AND_obj_is_null_or_a_non_equatable_type
   //WHEN
   //Equals_AND_obj_is_a_nullable_object
   //THEN
   //false_is_returned

   [TestMethod]
   public void
      GIVEN_Result_of_TestStruct_AND_obj_is_null_or_a_non_equatable_type_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_false_is_returned()
   {
      static Property Property(IResult<TestStruct> result,
                               object? obj)
      {
         //Act
         var actual = result.Equals(obj);

         //Assert
         return IsFalse(AssertMessages.ReturnValue,
                        actual);
      }

      Arb.Register<Libraries.ResultOfTestStruct>();
      Arb.Register<ObjIsNullOrANonEquatableType>();

      Prop.ForAll<IResult<TestStruct>, object?>(Property)
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

      public static Arbitrary<object?> Obj()
         => Gen
           .OneOf(Gen.Constant(default(object?)),
                  Generators.TestClass()
                            .Select(x => (object?)x),
                  Generators.UInt32()
                            .Select(x => (object?)x),
                  Generators.String()
                            .Select(x => (object?)x),
                  Generators.Result(Generators.Int32())
                            .Select(x => (object?)x),
                  Generators.Result(Generators.TestClass())
                            .Select(x => (object?)x))
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Result_of_TestStruct_AND_this_is_a_success
   //WHEN
   //Equals_AND_obj_is_a_nullable_object
   //THEN
   //is_reflexive

   [TestMethod]
   public void GIVEN_Result_of_TestStruct_AND_this_is_a_success_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_is_reflexive()
   {
      //Arrange
      var original = Result<TestStruct>.Success();
      var copy     = Result<TestStruct>.Success();

      //Act
      //Assert
      Assert.That
            .EqualsIsReflexive(original,
                               copy);
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Result_of_TestStruct_AND_this_is_a_failure
   //WHEN
   //Equals_AND_obj_is_a_nullable_object
   //THEN
   //is_reflexive

   [TestMethod]
   public void GIVEN_Result_of_TestStruct_AND_this_is_a_failure_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_is_reflexive()
   {
      static Property Property(TestStruct value)
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

      Arb.Register<Libraries.TestStruct>();

      Prop.ForAll<TestStruct>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Result_of_TestStruct
   //WHEN
   //Equals_AND_obj_is_a_nullable_object
   //THEN
   //is_symmetric

   [TestMethod]
   public void GIVEN_Result_of_TestStruct_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_is_symmetric()
   {
      Arb.Register<Libraries.ResultOfTestStruct>();

      Prop.ForAll<IResult<TestStruct>, IResult<TestStruct>>(EqualsIsSymmetric)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Result_of_TestStruct
   //WHEN
   //Equals
   //AND
   //obj_is_a_nullable_object
   //THEN
   //is_transitive

   [TestMethod]
   public void GIVEN_Result_of_TestStruct_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_is_transitive()
   {
      Arb.Register<Libraries.TransitiveResultsOfTestStruct>();

      Prop.ForAll<(IResult<TestStruct>, IResult<TestStruct>, IResult<TestStruct>)>(EqualsIsTransitive<IResult<TestStruct>>)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Result_of_TestStruct_AND_obj_is_a_TestStruct
   //WHEN
   //Equals
   //AND
   //obj_is_a_nullable_object
   //THEN
   //is_transitive

   [TestMethod]
   public void GIVEN_Result_of_TestStruct_AND_obj_is_a_TestStruct_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_is_transitive()
   {
      Arb.Register<Library_ResultOfTestStruct_AND_ObjIsAnTestStruct>();

      Prop.ForAll<(IResult<TestStruct>, TestStruct, TestStruct)>(EqualsIsTransitive)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   // ReSharper disable once ClassNeverInstantiated.Local
   // ReSharper disable once InconsistentNaming
   private sealed class Library_ResultOfTestStruct_AND_ObjIsAnTestStruct
   {
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public static Arbitrary<(IResult<TestStruct>, TestStruct, TestStruct)> Type()
         => Generators
           .TransitiveResultsAndT(Generators.TestStruct(),
                                 Generators.TwoUniqueTestStructs())
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */
}