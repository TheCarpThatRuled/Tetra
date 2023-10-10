namespace Check;

public sealed class FakeLeft
{
   /* ------------------------------------------------------------ */
   //  Fields
   /* ------------------------------------------------------------ */

   public readonly string Characterisation;

   /* ------------------------------------------------------------ */
   //  Private Constructors
   /* ------------------------------------------------------------ */

   private FakeLeft
   (
      string characterisation
   )
      => Characterisation = characterisation;

   /* ------------------------------------------------------------ */
   //  object Overridden Methods
   /* ------------------------------------------------------------ */

   public override string ToString()
      => Characterisation;

   /* ------------------------------------------------------------ */
   //  Factory Functions
   /* ------------------------------------------------------------ */

   public static FakeLeft Create
   (
      string characterisation
   )
      => new(characterisation);

   /* ------------------------------------------------------------ */
}