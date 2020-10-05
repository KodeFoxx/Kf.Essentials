namespace Kf.Essentials.Comparison.Ranges
{
    /// <summary>
    /// Specifies a range between a minimum and maximum value of <typeparamref name="T"/>.
    /// </summary>
    public interface IRange<T>
    {
        /// <summary>
        /// The minimum value of the range.
        /// </summary>
        T Minimum { get; }

        /// <summary>
        /// The maximul value of the range.
        /// </summary>
        T Maximum { get; }
    }
}
