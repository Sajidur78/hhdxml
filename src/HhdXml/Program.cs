using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HhdXml
{
    class Program
    {
        static unsafe void Main(string[] cliArgs)
        {
            var inputFile = string.Empty;
            var inputXml = string.Empty;
            string outputFile;

            var args = ParseArguments(cliArgs);

            if (args.Count == 1 && string.IsNullOrEmpty(args[string.Empty].FirstOrDefault()))
            {
                ShowHelp();
                return;
            }

            if (args.TryGetValue("help", out _))
            {
                ShowHelp();
                return;
            }

            if (args.TryGetValue("hhd", out var hhdValues))
            {
                var name = hhdValues.FirstOrDefault();
                if (string.IsNullOrEmpty(name))
                {
                    Console.WriteLine("Invalid input file.");
                    return;
                }

                try
                {
                    if (!File.Exists(name))
                    {
                        Console.WriteLine("File not found!");
                        return;
                    }

                    inputFile = name;
                }
                catch
                {
                    Console.WriteLine("Invalid filename.");
                    return;
                }
            }
            else
            {
                var name = args[string.Empty].FirstOrDefault();
                if (string.IsNullOrEmpty(name))
                {
                    Console.WriteLine("Invalid input file.");
                    return;
                }

                try
                {
                    if (!File.Exists(name))
                    {
                        Console.WriteLine("File not found!");
                        return;
                    }

                    if (name.EndsWith(".hhd", StringComparison.OrdinalIgnoreCase))
                        inputFile = name;
                    else if (name.EndsWith(".xml", StringComparison.OrdinalIgnoreCase))
                        inputXml = name;
                }
                catch
                {
                    Console.WriteLine("Invalid filename.");
                    return;
                }
            }

            if (args.TryGetValue("xml", out var xmlValues))
            {
                var name = xmlValues.FirstOrDefault();
                if (string.IsNullOrEmpty(name))
                {
                    Console.WriteLine("Invalid input file.");
                    return;
                }

                try
                {
                    if (!File.Exists(name))
                    {
                        Console.WriteLine("File not found!");
                        return;
                    }

                    inputXml = name;
                }
                catch
                {
                    Console.WriteLine("Invalid filename.");
                    return;
                }
            }

            if (args.TryGetValue("output_file", out var outputValues))
            {
                var name = outputValues.FirstOrDefault();
                if (string.IsNullOrEmpty(name))
                {
                    Console.WriteLine("Invalid input file.");
                    return;
                }

                try
                {
                    outputFile = Path.GetFullPath(name);
                }
                catch
                {
                    Console.WriteLine("Invalid filename.");
                    return;
                }
            }
            else
            {
                outputFile = Path.ChangeExtension(string.IsNullOrEmpty(inputFile) ? inputXml : inputFile, string.IsNullOrEmpty(inputXml) ? ".xml" : ".hhd");
            }

            if (string.IsNullOrEmpty(inputXml))
            {
                var buffer = File.ReadAllBytes(inputFile);

                fixed (byte* buf = buffer)
                {
                    var sceneData = (FxSceneData*)buf;
                    var serializer = new XmlSerializer(typeof(FxSceneData));
                    serializer.Serialize(File.Create(outputFile), *sceneData);
                }
            }
            else
            {
                var serializer = new XmlSerializer(typeof(FxSceneData));
                using (var stream = new FileStream(inputXml, FileMode.Open, FileAccess.Read))
                {
                    var sceneData = (FxSceneData)serializer.Deserialize(stream);
                    var buffer = new byte[sizeof(FxSceneData)];
                    fixed (byte* bufferPtr = buffer)
                        *(FxSceneData*)bufferPtr = sceneData;

                    File.WriteAllBytes(outputFile, buffer);
                }
            }
        }

        static Dictionary<string, List<string>> ParseArguments(string[] args, string prefix = "--")
        {
            var result = new Dictionary<string, List<string>>();
            List<string> selectedArgs = new List<string>();
            result[string.Empty] = selectedArgs;

            foreach (var arg in args)
            {
                if (arg.StartsWith(prefix))
                {
                    selectedArgs = new List<string>();
                    result[arg.Substring(prefix.Length)] = selectedArgs;
                    continue;
                }

                selectedArgs.Add(arg);
            }

            return result;
        }

        static void ShowHelp()
        {
            Console.Write(@"hhdxml: A tool for converting Sonic Lost World (PC) hhd files to xml and back.
Arguments:
    --help (Show this help message)
    --hhd input_file (Input hhd file to use)
    --xml input_xml (Input xml file to use, if converting back to hhd)
    --output_file output_file (Path to output file)

Examples:
    hhdxml.exe --hhd w1a01.hhd --output_file w1a01.xml
    hhdxml.exe --xml w1a01.xml --output_file w1a01.hhd
    hhdxml.exe w1a01.hhd

");
        }
    }
}
