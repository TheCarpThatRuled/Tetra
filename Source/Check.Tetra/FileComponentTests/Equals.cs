using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.FileComponentTests;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.FileComponent)]
// ReSharper disable once InconsistentNaming
public class Equals
{
   /* ------------------------------------------------------------ */
   // public bool Equals(object? obj)
   /* ------------------------------------------------------------ */

   //GIVEN
   //FileComponent_AND_obj_is_null_or_a_non_equatable_type
   //WHEN
   //Equals_AND_obj_is_a_nullable_object
   //THEN
   //false_is_returned

   [TestMethod]
   public void
      GIVEN_FileComponent_AND_obj_is_null_or_a_non_equatable_type_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_false_is_returned()
   {
      static Property Property(FileComponent fileComponent,
                               object? obj)
      {
         //Act
         var actual = fileComponent.Equals(obj);

         //Assert
         return IsFalse(AssertMessages.ReturnValue,
                        actual);
      }

      Arb.Register<ObjIsNullOrANonEquatableType>();
      Arb.Register<Libraries.FileComponent>();

      Prop.ForAll<FileComponent, object?>(Property)
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
   //FileComponent
   //WHEN
   //Equals_AND_obj_is_a_nullable_object
   //THEN
   //is_reflexive

   [TestMethod]
   public void GIVEN_FileComponent_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_is_reflexive()
   {
      static Property Property(FileComponent original)
      {
         //Arrange
         var copy = FileComponent.Create(original.Value());

         //Act
         //Assert
         return EqualsIsReflexive(original,
                                  copy);
      }

      Arb.Register<Libraries.FileComponent>();

      Prop.ForAll<FileComponent>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //FileComponent
   //WHEN
   //Equals_AND_obj_is_a_nullable_object
   //THEN
   //is_symmetric

   [TestMethod]
   public void GIVEN_FileComponent_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_is_symmetric()
   {
      Arb.Register<Libraries.FileComponent>();

      Prop.ForAll<FileComponent, FileComponent>(EqualsIsSymmetric)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //FileComponent
   //WHEN
   //Equals
   //AND
   //obj_is_a_nullable_object
   //THEN
   //is_transitive

   [TestMethod]
   public void GIVEN_FileComponent_WHEN_Equals_AND_obj_is_a_nullable_object_THEN_is_transitive()
   {
      Arb.Register<Libraries.TransitiveFileComponents>();

      Prop.ForAll<(FileComponent, FileComponent, FileComponent)>(EqualsIsTransitive<FileComponent>)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // bool Equals(FileComponent? other)
   /* ------------------------------------------------------------ */

   //GIVEN
   //FileComponent_AND_other_is_null
   //WHEN
   //Equals_AND_other_is_a_nullable_FileComponent
   //THEN
   //false_is_returned

   [TestMethod]
   public void
      GIVEN_FileComponent_AND_other_is_null_WHEN_Equals_AND_other_is_a_nullable_FileComponent_THEN_false_is_returned()
   {
      static Property Property(FileComponent value)
      {
         //act
         var actual = value.Equals(null);

         //Assert
         return IsFalse(AssertMessages.ReturnValue,
                        actual);
      }

      Arb.Register<Libraries.FileComponent>();

      Prop.ForAll<FileComponent>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //FileComponent_AND_this_is_a_some
   //WHEN
   //Equals_AND_other_is_a_nullable_FileComponent
   //THEN
   //is_reflexive

   [TestMethod]
   public void
      GIVEN_FileComponent_AND_this_is_a_some_WHEN_Equals_AND_other_is_a_nullable_FileComponent_THEN_is_reflexive()
   {
      static Property Property(FileComponent original)
      {
         //Arrange
         var copy = FileComponent.Create(original.Value());

         //Act
         //Assert
         return IEquatableIsReflexive(original,
                                      copy);
      }

      Arb.Register<Libraries.FileComponent>();

      Prop.ForAll<FileComponent>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //FileComponent
   //WHEN
   //Equals_AND_other_is_a_nullable_FileComponent
   //THEN
   //is_symmetric

   [TestMethod]
   public void GIVEN_FileComponent_WHEN_Equals_AND_other_is_a_nullable_FileComponent_THEN_is_symmetric()
   {
      Arb.Register<Libraries.FileComponent>();

      Prop.ForAll<FileComponent, FileComponent>(IEquatableIsSymmetric)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //FileComponent
   //WHEN
   //Equals_AND_other_is_a_nullable_FileComponent
   //THEN
   //is_transitive

   [TestMethod]
   public void GIVEN_FileComponent_WHEN_Equals_AND_other_is_a_nullable_FileComponent_THEN_is_transitive()
   {
      Arb.Register<Libraries.TransitiveFileComponents>();

      Prop.ForAll<(FileComponent, FileComponent, FileComponent)>(IEquatableIsTransitive<FileComponent>)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}