using FsCheck;

namespace Tetra.Testing;

// ReSharper disable InconsistentNaming
public sealed partial class AAA_property_test<TState> : ICharacterisable
{
   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly string                                          _briefCharacterisation;
   private readonly string                                          _fullCharacterisation;
   private readonly Func<Disposables, TState, Func<Func<Property>>> _test;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private AAA_property_test
   (
      string                                          briefCharacterisation,
      string                                          fullCharacterisation,
      Func<Disposables, TState, Func<Func<Property>>> test
   )
   {
      _briefCharacterisation = briefCharacterisation;
      _fullCharacterisation  = fullCharacterisation;
      _test                  = test;
   }

   /* ------------------------------------------------------------ */
   // ICharacterisable Methods
   /* ------------------------------------------------------------ */

   public string BriefCharacterisation()
      => _briefCharacterisation;

   /* ------------------------------------------------------------ */

   public string FullCharacterisation()
      => _fullCharacterisation;
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static DefineGiven<TGiven> GIVEN<TGiven>
   (
      IArrange<TGiven> given
   )
      where TGiven : IArranges
      => DefineGiven<TGiven>
        .Create(given);

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public Given Create()
      => new(_test);

   /* ------------------------------------------------------------ */
   // Private Factory Functions
   /* ------------------------------------------------------------ */

   private static AAA_property_test<TState> Create
   (
      Func<Disposables, TState, Func<Func<Property>>> test,
      Characteriser                                   characteriser
   )
      => new(characteriser.GenerateBriefCharacterisation(),
             characteriser.GenerateFullCharacterisation(),
             test);

   /* ------------------------------------------------------------ */
}