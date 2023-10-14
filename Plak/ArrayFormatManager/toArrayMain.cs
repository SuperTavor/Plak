using System;

namespace Plak.ArrayFormatManager
{
    class toArrayMain
    {
        public string[] origScript = new string[0];
        public List<string> headers = new List<string>();
        public List<string> choices = new List<string>();
        public List<string> syscalls = new List<string>();
        public static void start(FileInfo input)
        {
            toArrayMain toBranch = new toArrayMain();
            toBranch.origScript = File.ReadAllLines(input.FullName);
            var arrays = arraySorter(toBranch.origScript);
            foreach (string header in arrays.Item1)
            {
                Console.WriteLine(header);
            }
            foreach (string choice in arrays.Item2)
            {
                Console.WriteLine(choice);
            }
            foreach (string syscall in arrays.Item3)
            {
                Console.WriteLine(syscall);
            }
        }
        static (string[], string[], string[]) arraySorter(string[] origScript)
        {
            toArrayMain thisclass = new toArrayMain();
            foreach (var line in origScript)
            {

                if (line.Trim().StartsWith("-") && !line.Trim().StartsWith("--"))
                {
                    var choiceLvl = getChoiceLevel(line);
                    header header = new header();
                    header.init(line, choiceLvl, thisclass);

                }
                else if (line.Trim().StartsWith("--"))
                {
                    var choiceLvl = getChoiceLevel(line);
                    choice choice = new choice();
                    choice.init(line, choiceLvl, thisclass);

                }
                else if (line.Trim().StartsWith("[") && line.Trim().Contains("]"))
                {
                    var choiceLvl = getChoiceLevel(line);
                    syscall syscall = new syscall();
                    syscall.init(line, choiceLvl, thisclass);
                }
                else
                {
                    throwSyntaxError("Not a valid prefix at line " + thisclass.getIndexInFile(line) + ": " + line.Trim());
                }
            }
            return (thisclass.headers.ToArray(), thisclass.choices.ToArray(), thisclass.syscalls.ToArray());
        }
        static int getChoiceLevel(string line)
        {
            int level = 0;
            int spacesPerIndentation = 4;

            foreach (char ch in line)
            {
                if (ch == ' ')
                {
                    level++;
                }
                else if (ch == '\t')
                {
                    level += spacesPerIndentation;
                }
                else
                {
                    break;
                }
            }

            return level / spacesPerIndentation;
        }

        public static void throwSyntaxError(string message)
        {
            throw new Exception(message);
        }
        public int getIndexInFile(string input)
        {
            return Array.IndexOf(origScript, input) + 1;
        }
    }

}
