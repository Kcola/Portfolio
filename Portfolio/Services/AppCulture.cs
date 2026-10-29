using System.Collections.Generic;

namespace Portfolio.Services;

public static class AppCulture
{
    public static IReadOnlyList<string> Supported { get; } = new[] { "en", "es", "fr", "de", "pt", "ja" };
}
