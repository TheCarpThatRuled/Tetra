namespace Tetra.Testing;

// ReSharper disable InconsistentNaming
public sealed partial class AAA_property_test : ICharacterised
{
   /* ------------------------------------------------------------ */
   // Fields
   /* ------------------------------------------------------------ */

   public readonly Arbitrary<Parameters> Library;

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly string                                              _characterisation;
   private readonly Func<Parameters, Disposables, Func<Func<Property>>> _test;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private AAA_property_test
   (
      string                                              characterisation,
      Arbitrary<Parameters>                               library,
      Func<Parameters, Disposables, Func<Func<Property>>> test
   )
   {
      _characterisation = characterisation;
      _test             = test;

      Library = library;
   }

   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static DefineInitialGiven LIBRARY(Arbitrary<Parameters> library)
      => DefineInitialGiven
        .Create(library);

   /* ------------------------------------------------------------ */
   // Internal Factory Functions
   /* ------------------------------------------------------------ */

   internal static AAA_property_test Create
   (
      string                                              characterisation,
      Arbitrary<Parameters>                               library,
      Func<Parameters, Disposables, Func<Func<Property>>> test
   )
      => new(characterisation,
             library,
             test);

   /* ------------------------------------------------------------ */
   // ICharacterised Methods
   /* ------------------------------------------------------------ */

   public string Characterisation()
      => _characterisation;

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public Given Create
   (
      Parameters parameters
   )
      => new(parameters,
             _test);

   /* ------------------------------------------------------------ */
}