using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ConsoleApp1
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Hello World!");
        }
    }
    public class VariableRename
    {
        public static string rename(string text, string oldname, string newname)
        {
            try
            {
                if (text != null && oldname != null && newname != null)
                {
                    string pattern = @"\b" + oldname + @"\b";
                    bool isText = false;

                    string[] stringSeparators = new string[] { "\r\n" };
                    string[] wordsTmp = text.Split(stringSeparators, StringSplitOptions.None);
                    string text2 = "";
                    for (int i = 0; i < wordsTmp.Length; i++)
                    {
                        text2 += wordsTmp[i];
                    }
                    string[] words = text.Split(' ');

                    int wordsCount = words.Length;
                    if (wordsCount > 0)
                    {
                        string[] wordsWithoutCarriageReturn = { };
                        //string[] stringSeparators = new string[] { "\n" };
                        for (int i = 0; i < wordsCount; i++)
                        {
                            int lastBumpInd = Convert.ToString(words.GetValue(i)).IndexOf('\"');
                            int lastCarriageReturnInd = Convert.ToString(words.GetValue(i)).IndexOf("\n");
                            if (lastBumpInd != -1)
                            {
                                isText ^= true;
                                if (Convert.ToString(words.GetValue(i)).IndexOf('\"', ++lastBumpInd) != -1)
                                {
                                    isText ^= true;
                                }
                                continue;
                            }
                            if (lastCarriageReturnInd != -1)
                            {
                                words[i] = Regex.Replace(words[i], oldname, newname);
                                /*string strTmp = Convert.ToString(words.GetValue(i));
                                wordsWithoutCarriageReturn = strTmp.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);

                                for (int index = 0; index < wordsWithoutCarriageReturn.Length; index++)
                                    if (wordsWithoutCarriageReturn[index] == oldname)
                                        wordsWithoutCarriageReturn[index] = newname;

                                string strTmp2 = "";
                                for (int j = 0; j < wordsWithoutCarriageReturn.Length; j++)
                                {
                                    strTmp2 += wordsWithoutCarriageReturn[i] + "\n";
                                }
                                strTmp2 = strTmp2.Remove(strTmp2.Length - 1, 1);
                                words[i].Replace(words[i], strTmp2);*/
                            }
                            if (!isText && (Convert.ToString(words.GetValue(i)) == oldname || Convert.ToString(words.GetValue(i)) == (oldname + ';')))
                            {
                                if (Convert.ToString(words.GetValue(i)) == (oldname + ';'))
                                {
                                    words.SetValue((newname + ';'), i);
                                }
                                else
                                {
                                    words.SetValue(newname, i);
                                }
                            }
                        }
                        text = "";
                        for (int i = 0; i < wordsCount; i++)
                        {
                            text += Convert.ToString(words.GetValue(i)) + ' ';
                        }
                        text = text.Remove(text.Length - 1, 1);
                        Console.WriteLine(text);
                        //text.Trim();
                    }
                    return text;
                }
                else
                {
                    throw new ArgumentNullException("Some arguments are null / some argument is null");
                }
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine($"{e.GetType().Name}: argument is null");
                throw e;
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.GetType().Name}: something went wrong");
                throw e;
            }
        }
    }

    public class MethodExtraction
    {
        public static string ExtractMethod(string text, string method, string name)
        {
            try
            {
                if (text != null && method != null && name != null)
                {
                    string function = name + "()";

                    if (!text.Contains(function))
                    {
                        if (text.Contains(method))
                        {
                            while (text.Contains(method))
                            {
                                text = text.Replace(method, name + "();");
                            }
                            text = text.Insert(0, ConstructMethod(name, method));
                            return text;
                        }
                        else
                        {
                            return text;
                        }
                    }
                    else
                        return text;
                }
                else
                {
                    throw new ArgumentNullException("Some arguments are null / some argument is null");
                }
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine($"{e.GetType().Name}: argument is null");
                throw e;
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.GetType().Name}: something went wrong");
                throw e;
            }
        }
        public static string ConstructMethod(string methodName, string methodText)
        {
            string allMethodText = "";

            allMethodText = "void " + methodName + "()\r\n" +
                "{" + methodText + "}\r\n";
            return allMethodText;
        }
       
    }

        public class Refactor
        {
            public static string RenameMethod(string oldName, string newName, string fileContents)
            {
                var strings = MethodIndexes(oldName, fileContents);
                fileContents = ReplaceByIndexes(fileContents, strings, oldName, newName);
                return fileContents;
            }

            public static string ReplaceMagicNumber(string number, string CName, string fileContents)
            {
                var type = NumericType(number);
                var strings = MagicNumberIndexes(number, fileContents);
                var prefix = "";
                if (strings.Any())
                {
                    prefix = $"const {type} {CName} = {number};\r\n";
                    fileContents = ReplaceByIndexes(fileContents, strings, number, CName);
                }
                return prefix + fileContents;
            }

            private static string ReplaceByIndexes(string str, IEnumerable<int> indexes, string old, string new_)
            {
                var indexes_ = new List<int>(indexes);
                for (int i = 0; i < indexes_.Count; i++)
                {
                    str = str.Remove(indexes_[i], old.Length)
                             .Insert(indexes_[i], new_);
                    indexes_ = indexes_.Select(x => x - old.Length + new_.Length)
                                       .ToList();
                }
                return str;
            }

            private static IEnumerable<int> ItemIndexes(string item, string fileContents)
            {
                for (
                    int start = 0,
                        index = fileContents.IndexOf(item, start);
                    start < fileContents.Length && index != -1;
                    start = index + item.Length,
                        index = fileContents.IndexOf(item, start)
                )
                {
                    yield return index;
                }
            }


            private static IEnumerable<int> Indexes(string item, string fileContents, Func<int, bool> checkIndex)
            {
                var commentsAndQuotes = Comments(fileContents).Concat(Quotes(fileContents));
                return ItemIndexes(item, fileContents)
                    .Where(i => IsInCode(i, commentsAndQuotes) && checkIndex(i));
            }

            private static IEnumerable<int> MethodIndexes(string name, string fileContents)
            {
                return Indexes(name, fileContents, (x) =>
                {
                    return
                     fileContents[x - 1] == '.' || fileContents[x - 1] == ' ' &&
                        fileContents[x + name.Length] == '(';

                });
            }

            private static IEnumerable<int> MagicNumberIndexes(string number, string fileContents)
            {
                return Indexes(number, fileContents, (x) =>
                {
                    return !("" + fileContents[x - 1] + fileContents[x + number.Length])
                        .Any(Char.IsLetterOrDigit);
                });
            }

            private static bool IsInCode(int index, IEnumerable<(int, int)> commentsAndQuotes)
            {
                return !commentsAndQuotes.Any(r => index > r.Item1 && index < r.Item2);
            }

            public static string NumericType(string number)
            {
                bool isInteger = int.TryParse(number, out _);
                if (isInteger)
                {
                    return "int";
                }
                bool isDouble = Double.TryParse(number, System.Globalization.NumberStyles.Any, CultureInfo.InvariantCulture, out _);
                if (isDouble)
                {
                    return "double";
                }
                throw new ArgumentException($"{number} is not a number");
            }

            public static IEnumerable<String> PairwiseStr(String str)
            {
                return str.Zip(str.Skip(1), (a, b) => "" + a + b);
            }

            public static List<(int, int)> Quotes(string fileContents)
            {
                var quotes = new List<(int, int)>();
                bool inQuotes = false;
                int index = 0;
                int quotesStart = 0;
                foreach (var ch in fileContents)
                {
                    // start of quotes
                    var inQuotes_ = ch == '\"';
                    if (!inQuotes && inQuotes_)
                    {
                        quotesStart = index;
                    }

                    // end of quotes
                    bool notInQuotes = inQuotes && ch == '\"';

                    inQuotes |= inQuotes_;
                    if (notInQuotes)
                    {
                        inQuotes = false;
                        quotes.Add((quotesStart, index));
                    }
                    index++;
                }
                if (inQuotes)
                {
                    quotes.Add((quotesStart, index));
                }

                return quotes;
            }

            public static List<(int, int)> Comments(string fileContents)
            {
                var comments = new List<(int, int)>();
                bool inSingleComment = false;
                bool inMultiComment = false;
                int index = 0;
                int commentStart = 0;
                foreach (var pair in PairwiseStr(fileContents))
                {
                    // start of comment
                    var inSingleComment_ = pair == "//";
                    var inMultiComment_ = pair == "/*" && !inSingleComment;
                    if (!inSingleComment && inSingleComment_ ||
                        !inMultiComment && inMultiComment_)
                    {
                        commentStart = index;
                    }

                    // end of comment
                    bool notInSingleComment = inSingleComment && pair[0] == '\n';
                    bool notInMultiComment = inMultiComment && pair == "*/";

                    inSingleComment |= inSingleComment_;
                    inMultiComment |= inMultiComment_;
                    if (notInSingleComment || notInMultiComment)
                    {
                        inSingleComment = false;
                        inMultiComment = false;
                        comments.Add((commentStart, index));
                    }
                    index++;
                }
                if (inSingleComment || inMultiComment)
                {
                    comments.Add((commentStart, index));
                }
                return comments;
            }
        }
}
