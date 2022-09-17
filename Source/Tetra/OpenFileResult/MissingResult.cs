namespace Tetra;

internal sealed class MissingResult<T> : IOpenFileResult<T>
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static MissingResult<T> Create(Message          message,
                                         AbsoluteFilePath path)
      => new(new(message,
                 path));

   /* ------------------------------------------------------------ */
   // IOpenFileResult<T> Methods
   /* ------------------------------------------------------------ */

   public IOpenFileResult<T> Do(Action<Locked>  whenLocked,
                                Action<Missing> whenMissing,
                                Action<T>       whenOpen)
      => throw new NotImplementedException();

   /* ------------------------------------------------------------ */

   public IOpenFileResult<TNew> Map<TNew>(Func<T, TNew> whenOpen)
      => new MissingResult<TNew>(Content);

   /* ------------------------------------------------------------ */

   public TNew Reduce<TNew>(Func<Locked, TNew>  whenLocked,
                            Func<Missing, TNew> whenMissing,
                            Func<T, TNew>       whenOpen)
      => whenMissing(Content);

   /* ------------------------------------------------------------ */
   // Internal Fields
   /* ------------------------------------------------------------ */

   internal readonly Missing Content;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private MissingResult(Missing content)
      => Content = content;

   /* ------------------------------------------------------------ */
}