namespace Tetra.Testing;

public sealed partial class AAATest : ICharacterisable
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static DefineGiven Factory()
      => new(Create);

   /* ------------------------------------------------------------ */
   // ICharacterisable Methods
   /* ------------------------------------------------------------ */

   public string BriefCharacterisation()
      => _briefCharacterisation;

   /* ------------------------------------------------------------ */

   public string FullCharacterisation()
      => _fullCharacterisation;

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public Given Create()
      => new(_test);

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly string                          _briefCharacterisation;
   private readonly string                          _fullCharacterisation;
   private readonly Func<Disposables, Func<Action>> _test;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private AAATest(string                          briefCharacterisation,
                   string                          fullCharacterisation,
                   Func<Disposables, Func<Action>> test)
   {
      _briefCharacterisation = briefCharacterisation;
      _fullCharacterisation  = fullCharacterisation;
      _test                  = test;
   }

   /* ------------------------------------------------------------ */
   // Private Factory Functions
   /* ------------------------------------------------------------ */

   private static AAATest Create(Func<Disposables, Func<Action>> test,
                                 Characteriser                   characteriser)
      => new(characteriser.GenerateBriefCharacterisation(),
             characteriser.GenerateFullCharacterisation(),
             test);

   /* ------------------------------------------------------------ */
}