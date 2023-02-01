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

   public string Characterisation()
      => _characterisation;

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

   private readonly string                          _characterisation;
   private readonly string                          _fullCharacterisation;
   private readonly Func<Disposables, Func<Action>> _test;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private AAATest(string                          characterisation,
                   string                          fullCharacterisation,
                   Func<Disposables, Func<Action>> test)
   {
      _characterisation     = characterisation;
      _fullCharacterisation = fullCharacterisation;
      _test                 = test;
   }

   /* ------------------------------------------------------------ */
   // Private Factory Functions
   /* ------------------------------------------------------------ */

   private static AAATest Create(Func<Disposables, Func<Action>> test,
                                 Characteriser                   characteriser)
      => new(characteriser.GenerateCharacterisation(),
             characteriser.GenerateFullCharacterisation(),
             test);

   /* ------------------------------------------------------------ */
}