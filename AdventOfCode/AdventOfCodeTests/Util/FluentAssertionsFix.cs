using System.Diagnostics.CodeAnalysis;

namespace AdventOfCodeTests.Util
{
    public static class FluentAssertionsFix
    {
        public static void ShouldNotBeNull([NotNull] this object? o)
        {
            o.Should().NotBeNull();
            if (o == null)
            {
                throw new ArgumentNullException(nameof(o));
            }
        }
    }
}
