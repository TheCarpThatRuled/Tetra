namespace Check;

public sealed class FakeNewType
{
   /* ------------------------------------------------------------ */
   //  Fields
   /* ------------------------------------------------------------ */

   public readonly string Characterisation;

   /* ------------------------------------------------------------ */
   //  object Overridden Methods
   /* ------------------------------------------------------------ */

   public override string ToString()
      => Characterisation;

   /* ------------------------------------------------------------ */
   //  Factory Functions
   /* ------------------------------------------------------------ */

   public static FakeNewType Create(string characterisation)
      => new(characterisation);

   /* ------------------------------------------------------------ */
   //  Private Constructors
   /* ------------------------------------------------------------ */

   private FakeNewType(string characterisation)
      => Characterisation = characterisation;

   /* ------------------------------------------------------------ */
}