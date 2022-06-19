using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.VolumeRootedFilePathTests;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.VolumeRootedFilePath)]
// ReSharper disable once InconsistentNaming
public class Equals
{
   /* ------------------------------------------------------------ */
   // bool Equals(object? obj)
   /* ------------------------------------------------------------ */

   //GIVEN
   //VolumeRootedFilePath_AND_obj_is_null_or_a_non_equatable_type
   //WHEN
   //Equals_AND_obj_is_a_nullable_object
   //THEN
   //false_is_returned

   [TestMethod]
   public void
      GIVEN_VolumeRootedFilePath_AND_obj_is_null_or_a_non_equatable_type_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_false_is_returned()
   {
      static Property Property(VolumeRootedFilePath VolumeRootedFilePath,
                               object? obj)
      {
         //Act
         var actual = VolumeRootedFilePath.Equals(obj);

         //Assert
         return IsFalse(actual);
      }

      Arb.Register<ObjIsNullOrANonEquatableType>();
      Arb.Register<Libraries.VolumeRootedFilePath>();

      Prop.ForAll<VolumeRootedFilePath, object?>(Property)
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
                            .Select(x => (object?)x),
                  Generators.String()
                            .Select(x => (object?)x))
           .ToArbitrary();

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //VolumeRootedFilePath
   //WHEN
   //Equals_AND_obj_is_a_nullable_object
   //THEN
   //is_reflexive

   [TestMethod]
   public void GIVEN_VolumeRootedFilePath_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_is_reflexive()
   {
      static Property Property((VolumeRootedFilePath original, VolumeRootedFilePath copy) args)
      {
         //Arrange
         //Act
         //Assert
         return EqualsIsReflexive(args.original,
                                  args.copy);
      }

      Arb.Register<Libraries.TwoIdenticalVolumeRootedFilePaths>();

      Prop.ForAll<(VolumeRootedFilePath, VolumeRootedFilePath )>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //VolumeRootedFilePath
   //WHEN
   //Equals_AND_obj_is_a_nullable_object
   //THEN
   //is_symmetric

   [TestMethod]
   public void GIVEN_VolumeRootedFilePath_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_is_symmetric()
   {
      Arb.Register<Libraries.VolumeRootedFilePath>();

      Prop.ForAll<VolumeRootedFilePath, VolumeRootedFilePath>(EqualsIsSymmetric)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //VolumeRootedFilePath
   //WHEN
   //Equals
   //AND
   //obj_is_a_nullable_object
   //THEN
   //is_transitive

   [TestMethod]
   public void GIVEN_VolumeRootedFilePath_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_is_transitive()
   {
      Arb.Register<Libraries.TransitiveVolumeRootedFilePaths>();

      Prop.ForAll<(VolumeRootedFilePath, VolumeRootedFilePath, VolumeRootedFilePath)>(EqualsIsTransitive<VolumeRootedFilePath>)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // bool Equals(VolumeRootedFilePath? other)
   /* ------------------------------------------------------------ */

   //GIVEN
   //VolumeRootedFilePath_AND_other_is_null
   //WHEN
   //Equals_AND_other_is_a_nullable_VolumeRootedFilePath
   //THEN
   //false_is_returned

   [TestMethod]
   public void
      GIVEN_VolumeRootedFilePath_AND_other_is_null_WHEN_Equals_AND_other_is_a_nullable_VolumeRootedFilePath_THEN_false_is_returned()
   {
      static Property Property(VolumeRootedFilePath value)
      {
         //act
         var actual = value.Equals(null);

         //Assert
         return IsFalse(actual);
      }

      Arb.Register<Libraries.VolumeRootedFilePath>();

      Prop.ForAll<VolumeRootedFilePath>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //VolumeRootedFilePath_AND_this_is_a_some
   //WHEN
   //Equals_AND_other_is_a_nullable_VolumeRootedFilePath
   //THEN
   //is_reflexive

   [TestMethod]
   public void
      GIVEN_VolumeRootedFilePath_AND_this_is_a_some_WHEN_Equals_AND_other_is_a_nullable_VolumeRootedFilePath_THEN_is_reflexive()
   {
      static Property Property((VolumeRootedFilePath original, VolumeRootedFilePath copy) args)
      {
         //Arrange
         //Act
         //Assert
         return IEquatableIsReflexive<AbsoluteFilePath>(args.original,
                                                             args.copy);
      }

      Arb.Register<Libraries.TwoIdenticalVolumeRootedFilePaths>();

      Prop.ForAll<(VolumeRootedFilePath, VolumeRootedFilePath)>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //VolumeRootedFilePath
   //WHEN
   //Equals_AND_other_is_a_nullable_VolumeRootedFilePath
   //THEN
   //is_symmetric

   [TestMethod]
   public void GIVEN_VolumeRootedFilePath_WHEN_Equals_AND_other_is_a_nullable_VolumeRootedFilePath_THEN_is_symmetric()
   {
      Arb.Register<Libraries.VolumeRootedFilePath>();

      Prop.ForAll<VolumeRootedFilePath, VolumeRootedFilePath>(IEquatableIsSymmetric<AbsoluteFilePath>)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //VolumeRootedFilePath
   //WHEN
   //Equals_AND_other_is_a_nullable_VolumeRootedFilePath
   //THEN
   //is_transitive

   [TestMethod]
   public void GIVEN_VolumeRootedFilePath_WHEN_Equals_AND_other_is_a_nullable_VolumeRootedFilePath_THEN_is_transitive()
   {
      Arb.Register<Libraries.TransitiveVolumeRootedFilePaths>();

      Prop.ForAll<(VolumeRootedFilePath, VolumeRootedFilePath, VolumeRootedFilePath)>(IEquatableIsTransitive<AbsoluteFilePath, VolumeRootedFilePath>)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}