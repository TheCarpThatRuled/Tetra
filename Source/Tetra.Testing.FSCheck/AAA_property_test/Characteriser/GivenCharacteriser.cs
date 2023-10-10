namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class AAA_property_test<TState>
{
   public sealed class GivenCharacteriser
   {
      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly List<string> _briefCharacterisation = new();
      private readonly List<string> _fullCharacterisation  = new();

      /* ------------------------------------------------------------ */
      // Private Constructors
      /* ------------------------------------------------------------ */

      private GivenCharacteriser() { }
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public GivenCharacteriser AddClauseToBriefCharacterisation
      (
         string clause
      )
      {
         _briefCharacterisation.Add(clause);

         return this;
      }

      /* ------------------------------------------------------------ */

      public GivenCharacteriser AddClauseToCharacterisation
      (
         string clause
      )
         => AddClauseToBriefCharacterisation(clause)
           .AddClauseToFullCharacterisation(clause);

      /* ------------------------------------------------------------ */

      public GivenCharacteriser AddClauseToFullCharacterisation
      (
         string clause
      )
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

      // ReSharper disable once MemberHidesStaticFromOuterClass
      internal WhenCharacteriser When()
         => new(_briefCharacterisation.Materialise(),
                _fullCharacterisation.Materialise());

      /* ------------------------------------------------------------ */
   }
}