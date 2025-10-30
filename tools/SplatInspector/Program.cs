using System;
using System.IO;
using System.Linq;
using System.Reflection;

class Program
{
    static void Main(string[] args)
    {
        var path = args.Length > 0 ? args[0] : ".";
        if (File.Exists(path))
        {
            InspectFile(path);
        }
        else if (Directory.Exists(path))
        {
            foreach (var dll in Directory.EnumerateFiles(path, "*.dll"))
            {
                InspectFile(dll);
            }
        }
        else
        {
            Console.WriteLine("Path not found: " + path);
        }
    }

    static void InspectFile(string dll)
    {
        try
        {
            var an = AssemblyName.GetAssemblyName(dll);
            Console.WriteLine($"\n{Path.GetFileName(dll)} - {an.Version} - {an.FullName}");
            var asm = Assembly.LoadFrom(dll);
            Console.WriteLine(" Referenced assemblies:");
            foreach (var r in asm.GetReferencedAssemblies())
            {
                Console.WriteLine(" " + r.FullName);
            }
            var locType = asm.GetType("Splat.Locator");
            if (locType != null)
            {
                Console.WriteLine(" Found Splat.Locator in " + dll);
                var prop = locType.GetProperty("CurrentMutable", BindingFlags.Public | BindingFlags.Static);
                Console.WriteLine(" CurrentMutable prop: " + (prop != null ? prop.PropertyType.FullName : "<missing>"));
                var methods = locType.GetMethods(BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance | BindingFlags.DeclaredOnly);
                Console.WriteLine(" Methods on Splat.Locator:");
                foreach (var m in methods.OrderBy(m => m.Name))
                {
                    Console.WriteLine(" " + m.Name + " -> " + m.ReturnType.FullName + "(" + string.Join(",", m.GetParameters().Select(p => p.ParameterType.Name)) + ")");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{Path.GetFileName(dll)} - error: " + ex.Message);
        }
    }
}
