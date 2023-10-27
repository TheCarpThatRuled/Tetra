namespace Tetra.Testing;

// ReSharper disable InconsistentNaming
public sealed partial class AAA_test : ICharacterisable
{
   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly string                          _briefCharacterisation;
   private readonly string                          _fullCharacterisation;
   private readonly Func<Disposables, Func<Action>> _test;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private AAA_test
   (
      string                          briefCharacterisation,
      string                          fullCharacterisation,
      Func<Disposables, Func<Action>> test
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

   private static AAA_test Create
   (
      Func<Disposables, Func<Action>> test,
      Characteriser                   characteriser
   )
      => new(characteriser.GenerateBriefCharacterisation(),
             characteriser.GenerateFullCharacterisation(),
             test);

   /* ------------------------------------------------------------ */
}