using System.ServiceModel.Syndication;

namespace rardk.web.ServiceLayer;

public static class ServiceLayerExtensions
{
    public static bool ParseYesOrNo(this string? text)
    {
        return string.Equals(text, "Yes", StringComparison.OrdinalIgnoreCase);
    }

    public static string? ReadElementExtension(this SyndicationItem item, string extensionName, string extensionNamespace)
    {
        var elementExtensions = item.ElementExtensions
            .ReadElementExtensions<string>(extensionName, extensionNamespace);
        return elementExtensions.FirstOrDefault();
    }
}