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

        }
        static (string[], string[], string[]) arraySorter(string[] origScript)
        {
            toArrayMain thisclass = new toArrayMain();
            var lineIndex = 1;
            foreach (var line in origScript)
            {

                if (line.Trim().StartsWith("-") && !line.Trim().StartsWith("--"))
                {
                    var choiceLvl = getChoiceLevel(line);
                    header header = new header();
                    header.init(line, choiceLvl, thisclass, lineIndex);

                }
                else if (line.Trim().StartsWith("--"))
                {
                    var choiceLvl = getChoiceLevel(line);
                    choice choice = new choice();
                    choice.init(line, choiceLvl, thisclass, lineIndex);

                }
                else if (line.Trim().StartsWith("[") && line.Trim().Contains("]"))
                {
                    var choiceLvl = getChoiceLevel(line);
                    syscall syscall = new syscall();
                    syscall.init(line, choiceLvl, thisclass, lineIndex);
                }
                else
                {
                    throwSyntaxError("Not a valid prefix at line " + lineIndex + ": " + line.Trim());
                }
                lineIndex++;
            }

            return (thisclass.headers.ToArray(), thisclass.choices.ToArray(), thisclass.syscalls.ToArray());
        }
        static int getChoiceLevel(string line, int spacesPerIndentation = 4)
        {
            if (string.IsNullOrWhiteSpace(line))
                return 0;

            int level = 0;
            int i = 0;

            while (i < line.Length)
            {
                char ch = line[i];
                if (ch == ' ')
                {
                    int spacesCount = 0;
                    while (i < line.Length && line[i] == ' ')
                    {
                        spacesCount++;
                        i++;
                    }
                    level += spacesCount;
                }
                else if (ch == '\t')
                {
                    level += spacesPerIndentation;
                    i++;
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
