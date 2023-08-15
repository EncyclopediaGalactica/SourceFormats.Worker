namespace EncyclopediaGalactica.RestApiSdkGenerator.Generator.Generator.Managers.StringManager;

public partial class StringManagerImpl
{
    /// <inheritdoc />
    public string? CheckIfLastCharIsDotAndRemoveIt(string? s1)
    {
        if (string.IsNullOrEmpty(s1) || string.IsNullOrWhiteSpace(s1))
        {
            return s1;
        }

        if (s1.EndsWith("."))
        {
            return s1.Substring(1);
        }

        return s1;
    }
}