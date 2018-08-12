using System.IO;
using System.Text.RegularExpressions;
using SubModifier.Entities;
using SubModifier.Interfaces;

namespace SubModifier.Services
{
    public class VttSubtitleManager : ISubManager
    {
        public void TransformSubtitle(Subtitle subtitle)
        {
            if (!subtitle.Transform)
            {
                return;
            }
            #region Reading & Replacing
            string text = File.ReadAllText(subtitle.Path);
            string pattern = @"(WEBVTT(\n)+)|(WEBVTT(\r\n)+)|(WEBVTT(\r)+)";

            Regex rgx = new Regex(pattern, RegexOptions.IgnoreCase);
            string replacement = "";
            string result = rgx.Replace(text, replacement);

            string timePattern = @"\p{Sc}*(?<hours>\s?\d{2}):(?<minutes>\s?\d{2}):(?<seconds>\s?\d{2}).(?<miliseconds>\s?\d{3})\p{Sc}*";
            string timeReplacement = "${hours}:${minutes}:${seconds},${miliseconds}";
            string timeResult = Regex.Replace(result, timePattern, timeReplacement);
            #endregion Reading & Replacing

            #region Moving File
            string subsFolder = Path.Combine(subtitle.FolderPath, "SubsVTT");
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
                File.WriteAllText(newPath, timeResult);
            }
            #endregion Write Srt File

            subtitle.Success = true;           
        }
    }
}