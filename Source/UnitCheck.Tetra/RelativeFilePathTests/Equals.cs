using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.RelativeFilePathTests;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.RelativeFilePath)]
// ReSharper disable once InconsistentNaming
public class Equals
{
   /* ------------------------------------------------------------ */
   // public bool Equals(object? obj)
   /* ------------------------------------------------------------ */

   //GIVEN
   //RelativeFilePath_AND_obj_is_null_or_a_non_equatable_type
   //WHEN
   //Equals_AND_obj_is_a_nullable_object
   //THEN
   //false_is_returned

   [TestMethod]
   public void
      GIVEN_RelativeFilePath_AND_obj_is_null_or_a_non_equatable_type_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_false_is_returned()
   {
      static Property Property(RelativeFilePath RelativeFilePath,
                               object?          obj)
      {
         //Act
         var actual = RelativeFilePath.Equals(obj);

         //Assert
         return IsFalse(AssertMessages.ReturnValue,
                        actual);
      }

      Arb.Register<ObjIsNullOrANonEquatableType>();
      Arb.Register<Libraries.RelativeFilePath>();

      Prop.ForAll<RelativeFilePath, object?>(Property)
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
                  Generators.Int32()
                            .Select(x => (object?) x),
                  Generators.String()
                            .Select(x => (object?) x))
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //RelativeFilePath
   //WHEN
   //Equals_AND_obj_is_a_nullable_object
   //THEN
   //is_reflexive

   [TestMethod]
   public void GIVEN_RelativeFilePath_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_is_reflexive()
   {
      static Property Property((RelativeFilePath original, RelativeFilePath copy) args)
      {
         //Arrange
         //Act
         //Assert
         return EqualsIsReflexive(args.original,
                                  args.copy);
      }

      Arb.Register<Libraries.TwoIdenticalRelativeFilePaths>();

      Prop.ForAll<(RelativeFilePath, RelativeFilePath )>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //RelativeFilePath
   //WHEN
   //Equals_AND_obj_is_a_nullable_object
   //THEN
   //is_symmetric

   [TestMethod]
   public void GIVEN_RelativeFilePath_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_is_symmetric()
   {
      Arb.Register<Libraries.RelativeFilePath>();

      Prop.ForAll<RelativeFilePath, RelativeFilePath>(EqualsIsSymmetric)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //RelativeFilePath
   //WHEN
   //Equals
   //AND
   //obj_is_a_nullable_object
   //THEN
   //is_transitive

   [TestMethod]
   public void GIVEN_RelativeFilePath_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_is_transitive()
   {
      Arb.Register<Libraries.TransitiveRelativeFilePaths>();

      Prop.ForAll<(RelativeFilePath, RelativeFilePath, RelativeFilePath)>(EqualsIsTransitive<RelativeFilePath>)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // public bool Equals(RelativeFilePath? other)
   /* ------------------------------------------------------------ */

   //GIVEN
   //RelativeFilePath_AND_other_is_null
   //WHEN
   //Equals_AND_other_is_a_nullable_RelativeFilePath
   //THEN
   //false_is_returned

   [TestMethod]
   public void
      GIVEN_RelativeFilePath_AND_other_is_null_WHEN_Equals_AND_other_is_a_nullable_RelativeFilePath_THEN_false_is_returned()
   {
      static Property Property(RelativeFilePath value)
      {
         //act
         var actual = value.Equals(null);

         //Assert
         return IsFalse(AssertMessages.ReturnValue,
                        actual);
      }

      Arb.Register<Libraries.RelativeFilePath>();

      Prop.ForAll<RelativeFilePath>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //RelativeFilePath_AND_this_is_a_some
   //WHEN
   //Equals_AND_other_is_a_nullable_RelativeFilePath
   //THEN
   //is_reflexive

   [TestMethod]
   public void
      GIVEN_RelativeFilePath_AND_this_is_a_some_WHEN_Equals_AND_other_is_a_nullable_RelativeFilePath_THEN_is_reflexive()
   {
      static Property Property((RelativeFilePath original, RelativeFilePath copy) args)
      {
         //Arrange
         //Act
         //Assert
         return IEquatableIsReflexive(args.original,
                                      args.copy);
      }

      Arb.Register<Libraries.TwoIdenticalRelativeFilePaths>();

      Prop.ForAll<(RelativeFilePath, RelativeFilePath)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //RelativeFilePath
   //WHEN
   //Equals_AND_other_is_a_nullable_RelativeFilePath
   //THEN
   //is_symmetric

   [TestMethod]
   public void GIVEN_RelativeFilePath_WHEN_Equals_AND_other_is_a_nullable_RelativeFilePath_THEN_is_symmetric()
   {
      Arb.Register<Libraries.RelativeFilePath>();

      Prop.ForAll<RelativeFilePath, RelativeFilePath>(IEquatableIsSymmetric<RelativeFilePath>)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //RelativeFilePath
   //WHEN
   //Equals_AND_other_is_a_nullable_RelativeFilePath
   //THEN
   //is_transitive

   [TestMethod]
   public void GIVEN_RelativeFilePath_WHEN_Equals_AND_other_is_a_nullable_RelativeFilePath_THEN_is_transitive()
   {
      Arb.Register<Libraries.TransitiveRelativeFilePaths>();

      Prop.ForAll<(RelativeFilePath, RelativeFilePath, RelativeFilePath)>(IEquatableIsTransitive<RelativeFilePath>)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}