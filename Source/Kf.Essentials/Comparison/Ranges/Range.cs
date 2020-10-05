namespace Kf.Essentials.Comparison.Ranges
{
    /// <summary>
    /// Abstract base implementation of <see cref="IRange{T}"/>.
    /// </summary>
    public class Range<T> : IRange<T>
    {
        /// <summary>
        /// The minimum value of the range.
        /// </summary>
        public T Minimum { get; private set; }

        /// <summary>
        /// The maximul value of the range.
        /// </summary>
        public T Maximum { get; private set; }

        /// <summary>
        /// Creates a new <see cref="Range{T}"/>.
        /// </summary>
        /// <param name="minimum">The minimum value of the range.</param>
        /// <param name="maximum">The maximul value of the range.</param>
        public Range(T minimum, T maximum)
            => (Minimum, Maximum)
             = (minimum, maximum);
    }
}
