namespace Tetra.Testing;

partial class AAATest
{
   public sealed class GivenCharacteriser
   {
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public GivenCharacteriser AddClauseToCharacterisation(string clause)
      {
         _characterisation.Add(clause);

         return this;
      }

      /* ------------------------------------------------------------ */

      public GivenCharacteriser AddClauseToFullCharacterisation(string clause)
      {
         _fullCharacterisation.Add(clause);

         return this;
      }

      /* ------------------------------------------------------------ */
      // Internal Factory Functions
      /* ------------------------------------------------------------ */

      internal static GivenCharacteriser Create()
         => new();

      /* ------------------------------------------------------------ */
      // Internal Methods
      /* ------------------------------------------------------------ */

      internal WhenCharacteriser When()
         => new(_characterisation.Materialise(),
                _fullCharacterisation.Materialise());

      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly List<string> _characterisation     = new();
      private readonly List<string> _fullCharacterisation = new();

      /* ------------------------------------------------------------ */
      // Private Constructors
      /* ------------------------------------------------------------ */

      private GivenCharacteriser() { }

      /* ------------------------------------------------------------ */
   }
}