using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;
using SubModifier.Entities;
using SubModifier.Interfaces;

namespace SubModifier.Services
{
    public class TtmlSubtitleManager : ISubManager
    {
        public void TransformSubtitle(Subtitle subtitle)
        {
            #region Reading & Replacing
            string text = File.ReadAllText(subtitle.Path);

            XElement xElementTree = XElement.Parse(text);
            IEnumerable<XElement> textElements = from el in xElementTree?.Descendants()
                where el.NodeType == XmlNodeType.Element && el.Name?.LocalName == "p" && el.FirstAttribute?.Name?.LocalName == "begin"
                                                 select el;
            string textResult = "";
            int count = 1;

            //1
            //00:00:43,640 --> 00:00:47,020
            //text
            //
            //2
            StringBuilder builder = new StringBuilder();
            string timePattern = @"\p{Sc}*(?<hours>\s?\d{2}):(?<minutes>\s?\d{2}):(?<seconds>\s?\d{2}).(?<miliseconds>\s?\d{3})\p{Sc}*";
            string timeReplacement = "${hours}:${minutes}:${seconds},${miliseconds}";

            foreach (XElement element in textElements)
            {
                //LineNumber
                builder.AppendLine(count.ToString());

                //00:00:43,640 --> 00:00:47,020
                #region TimeLines
                var begingAttr = element.Attributes().FirstOrDefault(x => x.Name?.LocalName == "begin");
                var endAttr = element.Attributes().FirstOrDefault(x => x.Name?.LocalName == "end");

                if(begingAttr == null || endAttr == null) continue;

                string beginTime = Regex.Replace(begingAttr.Value, timePattern, timeReplacement);
                string endTime = Regex.Replace(endAttr.Value, timePattern, timeReplacement);
                string separator = " --> ";

                builder.Append(beginTime);
                builder.Append(separator);
                builder.AppendLine(endTime);
                #endregion TimeLines

                //text
                #region Text
                string pattern = @"\n\s+";
                string[] splitResult = Regex.Split(element.Value, pattern);
                foreach (string result in splitResult)
                {
                    if(string.IsNullOrEmpty(result) || string.IsNullOrWhiteSpace(result)) continue;
                    string textDecoratorPattern = @"<[a-z]>|</[a-z]>";
                    string textToAdd = Regex.Replace(result, textDecoratorPattern, "");
                    builder.AppendLine(textToAdd);
                }
                #endregion Text

                //ExtraLine
                builder.AppendLine();
                count++;
            }
            textResult = builder.ToString();
            #endregion Reading & Replacing

            #region Moving File
            string subsFolder = Path.Combine(subtitle.FolderPath, "SubsTTML");
            Directory.CreateDirectory(subsFolder);
            string subNewPath = Path.Combine(subsFolder, subtitle.Name);
            Directory.Move(subtitle.Path, subNewPath);
            #endregion Moving File

            #region Write Srt File
            string newPath = Path.ChangeExtension(subtitle.Path, "srt");
            if (!string.IsNullOrEmpty(newPath))
            {
                using (StreamWriter sw = new StreamWriter(newPath, false))
                {
                    sw.Close();
                }
                File.WriteAllText(newPath, textResult);
            }
            #endregion Write Srt File

            subtitle.Success = true;
        }
    }
}