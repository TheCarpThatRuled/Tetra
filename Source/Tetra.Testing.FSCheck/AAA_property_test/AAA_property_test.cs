using FsCheck;

namespace Tetra.Testing;

// ReSharper disable InconsistentNaming
public sealed partial class AAA_property_test<TParameters> : ICharacterised
{
   /* ------------------------------------------------------------ */
   // Fields
   /* ------------------------------------------------------------ */

   public readonly Type Library;

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly string                                               _characterisation;
   private readonly Func<TParameters, Disposables, Func<Func<Property>>> _test;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private AAA_property_test
   (
      string                                               characterisation,
      Type                                                 library,
      Func<TParameters, Disposables, Func<Func<Property>>> test
   )
   {
      _characterisation = characterisation;
      Library           = library;
      _test             = test;
   }

   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static DefineInitialGiven LIBRARY<TLibrary>()
      => DefineInitialGiven.Create(typeof(TLibrary));

   /* ------------------------------------------------------------ */
   // Internal Factory Functions
   /* ------------------------------------------------------------ */

   internal static AAA_property_test<TParameters> Create
   (
      string                                               characterisation,
      Type                                                 library,
      Func<TParameters, Disposables, Func<Func<Property>>> test
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
      TParameters parameters
   )
      => new(parameters,
             _test);

   /* ------------------------------------------------------------ */
}