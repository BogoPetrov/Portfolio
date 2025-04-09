using System.Reflection;
using System.Text;

namespace MyReflectionApp
{
    public class HtmlDocGenerator
    {
        public static void GenerateHtmlDocumentation(string outputPath)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            var types = assembly
                .GetTypes()
                .Where(t => t.IsClass && t.GetCustomAttribute<DocumentedAttribute>() != null);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<html><head><meta charset='UTF-8'><title>Документация</title></head><body>");
            sb.AppendLine("<h1>Автоматично генерирана документация</h1>");

            foreach (Type type in types)
            {
                var attr = type.GetCustomAttribute<DocumentedAttribute>();
                sb.AppendLine($"<h2>{type.Name}</h2>");
                sb.AppendLine($"<p>{attr?.Description}</p>");

                sb.AppendLine("<h3>Свойства:</h3><ul>");
                foreach (var prop in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
                {
                    sb.AppendLine($"<li><b>{prop.Name}</b>: {prop.PropertyType.Name}</li>");
                }
                sb.AppendLine("</ul>");

                sb.AppendLine("<h3>Методи</h3><ul>");
                foreach (var method in type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly))
                {
                    var paramList = string.Join(", ", method.GetParameters().Select(p => $"{p.ParameterType.Name} {p.Name}"));
                    sb.AppendLine($"<li>{method.ReturnType.Name} <b>{method.Name}</b>({paramList})</li>");
                }
                sb.AppendLine("</ul>");
            }
            sb.AppendLine("</body></html>");
            File.WriteAllText(outputPath, sb.ToString());

            Console.Write($"HTML documentation created successfully!");
        }
    }
}