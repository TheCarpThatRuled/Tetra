using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.VolumeComponentTests;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.VolumeComponent)]
// ReSharper disable once InconsistentNaming
public class Equals
{
   /* ------------------------------------------------------------ */
   // bool Equals(object? obj)
   /* ------------------------------------------------------------ */

   //GIVEN
   //Volume_AND_obj_is_null_or_a_non_equatable_type
   //WHEN
   //Equals_AND_obj_is_a_nullable_object
   //THEN
   //false_is_returned

   [TestMethod]
   public void
      GIVEN_Volume_AND_obj_is_null_or_a_non_equatable_type_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_false_is_returned()
   {
      static Property Property(VolumeComponent volume,
                               object?         obj)
      {
         //Act
         var actual = volume.Equals(obj);

         //Assert
         return IsFalse(AssertMessages.ReturnValue,
                        actual);
      }

      Arb.Register<ObjIsNullOrANonEquatableType>();
      Arb.Register<Libraries.VolumeComponent>();

      Prop.ForAll<VolumeComponent, object?>(Property)
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
   //VolumeComponent
   //WHEN
   //Equals_AND_obj_is_a_nullable_object
   //THEN
   //is_reflexive

   [TestMethod]
   public void GIVEN_Volume_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_is_reflexive()
   {
      static Property Property(VolumeComponent original)
      {
         //Arrange
         var copy = VolumeComponent.Create(original.Value()[0]);

         //Act
         //Assert
         return EqualsIsReflexive(original,
                                  copy);
      }

      Arb.Register<Libraries.VolumeComponent>();

      Prop.ForAll<VolumeComponent>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //VolumeComponent
   //WHEN
   //Equals_AND_obj_is_a_nullable_object
   //THEN
   //is_symmetric

   [TestMethod]
   public void GIVEN_Volume_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_is_symmetric()
   {
      Arb.Register<Libraries.VolumeComponent>();

      Prop.ForAll<VolumeComponent, VolumeComponent>(EqualsIsSymmetric)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //VolumeComponent
   //WHEN
   //Equals
   //AND
   //obj_is_a_nullable_object
   //THEN
   //is_transitive

   [TestMethod]
   public void GIVEN_Volume_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_is_transitive()
   {
      Arb.Register<Libraries.TransitiveVolumeComponents>();

      Prop.ForAll<(VolumeComponent, VolumeComponent, VolumeComponent)>(EqualsIsTransitive<VolumeComponent>)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // bool Equals(VolumeComponent? other)
   /* ------------------------------------------------------------ */

   //GIVEN
   //Volume_AND_other_is_null
   //WHEN
   //Equals_AND_other_is_a_nullable_Volume
   //THEN
   //false_is_returned

   [TestMethod]
   public void
      GIVEN_Volume_AND_other_is_null_WHEN_Equals_AND_other_is_a_nullable_Volume_THEN_false_is_returned()
   {
      static Property Property(VolumeComponent value)
      {
         //act
         var actual = value.Equals(null);

         //Assert
         return IsFalse(AssertMessages.ReturnValue,
                        actual);
      }

      Arb.Register<Libraries.VolumeComponent>();

      Prop.ForAll<VolumeComponent>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Volume_AND_this_is_a_some
   //WHEN
   //Equals_AND_other_is_a_nullable_Volume
   //THEN
   //is_reflexive

   [TestMethod]
   public void
      GIVEN_Volume_AND_this_is_a_some_WHEN_Equals_AND_other_is_a_nullable_Volume_THEN_is_reflexive()
   {
      static Property Property(VolumeComponent original)
      {
         //Arrange
         var copy = VolumeComponent.Create(original.Value()[0]);

         //Act
         //Assert
         return IEquatableIsReflexive(original,
                                      copy);
      }

      Arb.Register<Libraries.VolumeComponent>();

      Prop.ForAll<VolumeComponent>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //VolumeComponent
   //WHEN
   //Equals_AND_other_is_a_nullable_Volume
   //THEN
   //is_symmetric

   [TestMethod]
   public void GIVEN_Volume_WHEN_Equals_AND_other_is_a_nullable_Volume_THEN_is_symmetric()
   {
      Arb.Register<Libraries.VolumeComponent>();

      Prop.ForAll<VolumeComponent, VolumeComponent>(IEquatableIsSymmetric)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //VolumeComponent
   //WHEN
   //Equals_AND_other_is_a_nullable_Volume
   //THEN
   //is_transitive

   [TestMethod]
   public void GIVEN_Volume_WHEN_Equals_AND_other_is_a_nullable_Volume_THEN_is_transitive()
   {
      Arb.Register<Libraries.TransitiveVolumeComponents>();

      Prop.ForAll<(VolumeComponent, VolumeComponent, VolumeComponent)>(IEquatableIsTransitive<VolumeComponent>)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}