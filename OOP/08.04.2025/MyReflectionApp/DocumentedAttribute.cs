namespace MyReflectionApp
{
    [AttributeUsage(AttributeTargets.Class)]
    public class DocumentedAttribute(string description) : Attribute
    {
        public string Description { get; set; } = description;
    }
}
