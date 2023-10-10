using FsCheck;
using static Tetra.Testing.Properties;

namespace Check.AbsoluteFilePathTests;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.AbsoluteFilePath)]
// ReSharper disable once InconsistentNaming
public class Equals
{
   /* ------------------------------------------------------------ */
   // bool Equals(object? obj);
   /* ------------------------------------------------------------ */

   //GIVEN
   //AbsoluteFilePath_AND_obj_is_null_or_a_non_equatable_type
   //WHEN
   //Equals_AND_obj_is_a_nullable_object
   //THEN
   //false_is_returned

   [TestMethod]
   public void
      GIVEN_AbsoluteFilePath_AND_obj_is_null_or_a_non_equatable_type_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_false_is_returned()
   {
      static Property Property
      (
         AbsoluteFilePath absoluteFilePath,
         object?          obj
      )
      {
         //Act
         var actual = absoluteFilePath.Equals(obj);

         //Assert
         return IsFalse(AssertMessages.ReturnValue,
                        actual);
      }

      Arb.Register<ObjIsNullOrANonEquatableType>();
      Arb.Register<Libraries.AbsoluteFilePath>();

      Prop.ForAll<AbsoluteFilePath, object?>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //AbsoluteFilePath
   //WHEN
   //Equals_AND_obj_is_a_nullable_object
   //THEN
   //is_reflexive

   [TestMethod]
   public void GIVEN_AbsoluteFilePath_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_is_reflexive()
   {
      static Property Property
         (
            (AbsoluteFilePath original, AbsoluteFilePath copy) args
         )
         //Arrange
         //Act
         //Assert
         => EqualsIsReflexive(args.original,
                              args.copy);

      Arb.Register<Libraries.TwoIdenticalAbsoluteFilePaths>();

      Prop.ForAll<(AbsoluteFilePath, AbsoluteFilePath )>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //AbsoluteFilePath
   //WHEN
   //Equals_AND_obj_is_a_nullable_object
   //THEN
   //is_symmetric

   [TestMethod]
   public void GIVEN_AbsoluteFilePath_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_is_symmetric()
   {
      Arb.Register<Libraries.AbsoluteFilePath>();

      Prop.ForAll<AbsoluteFilePath, AbsoluteFilePath>(EqualsIsSymmetric)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //AbsoluteFilePath
   //WHEN
   //Equals
   //AND
   //obj_is_a_nullable_object
   //THEN
   //is_transitive

   [TestMethod]
   public void GIVEN_AbsoluteFilePath_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_is_transitive()
   {
      Arb.Register<Libraries.TransitiveAbsoluteFilePaths>();

      Prop.ForAll<(AbsoluteFilePath, AbsoluteFilePath, AbsoluteFilePath)>(EqualsIsTransitive<AbsoluteFilePath>)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // bool Equals(AbsoluteFilePath? other);
   /* ------------------------------------------------------------ */

   //GIVEN
   //AbsoluteFilePath_AND_other_is_null
   //WHEN
   //Equals_AND_other_is_a_nullable_AbsoluteFilePath
   //THEN
   //false_is_returned

   [TestMethod]
   public void
      GIVEN_AbsoluteFilePath_AND_other_is_null_WHEN_Equals_AND_other_is_a_nullable_AbsoluteFilePath_THEN_false_is_returned()
   {
      static Property Property
      (
         AbsoluteFilePath value
      )
      {
         //act
         var actual = value.Equals(null);

         //Assert
         return IsFalse(AssertMessages.ReturnValue,
                        actual);
      }

      Arb.Register<Libraries.AbsoluteFilePath>();

      Prop.ForAll<AbsoluteFilePath>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //AbsoluteFilePath_AND_this_is_a_some
   //WHEN
   //Equals_AND_other_is_a_nullable_AbsoluteFilePath
   //THEN
   //is_reflexive

   [TestMethod]
   public void
      GIVEN_AbsoluteFilePath_AND_this_is_a_some_WHEN_Equals_AND_other_is_a_nullable_AbsoluteFilePath_THEN_is_reflexive()
   {
      static Property Property
         (
            (AbsoluteFilePath original, AbsoluteFilePath copy) args
         )
         //Arrange
         //Act
         //Assert
         => IEquatableIsReflexive(args.original,
                                  args.copy);

      Arb.Register<Libraries.TwoIdenticalAbsoluteFilePaths>();

      Prop.ForAll<(AbsoluteFilePath, AbsoluteFilePath)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //AbsoluteFilePath
   //WHEN
   //Equals_AND_other_is_a_nullable_AbsoluteFilePath
   //THEN
   //is_symmetric

   [TestMethod]
   public void GIVEN_AbsoluteFilePath_WHEN_Equals_AND_other_is_a_nullable_AbsoluteFilePath_THEN_is_symmetric()
   {
      Arb.Register<Libraries.AbsoluteFilePath>();

      Prop.ForAll<AbsoluteFilePath, AbsoluteFilePath>(IEquatableIsSymmetric)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //AbsoluteFilePath
   //WHEN
   //Equals_AND_other_is_a_nullable_AbsoluteFilePath
   //THEN
   //is_transitive

   [TestMethod]
   public void GIVEN_AbsoluteFilePath_WHEN_Equals_AND_other_is_a_nullable_AbsoluteFilePath_THEN_is_transitive()
   {
      Arb.Register<Libraries.TransitiveAbsoluteFilePaths>();

      Prop.ForAll<(AbsoluteFilePath, AbsoluteFilePath, AbsoluteFilePath)>(IEquatableIsTransitive<AbsoluteFilePath>)
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
                  Generators.Int32()
                            .Select(x => (object?) x),
                  Generators.String()
                            .Select(x => (object?) x))
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */
}