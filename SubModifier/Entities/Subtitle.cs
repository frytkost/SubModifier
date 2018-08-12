using System;

namespace SubModifier.Entities
{
    public class Subtitle
    {
        public Subtitle(string path)
        {
            Id = Guid.NewGuid();
            Path = path;
            NameWithOutExtension = System.IO.Path.GetFileNameWithoutExtension(path);
            Name = System.IO.Path.GetFileName(path);
            FolderPath = System.IO.Path.GetDirectoryName(path);
            Extension = System.IO.Path.GetExtension(path);
            Transform = true;
        }
        public Guid Id { get; }

        public string Name { get; }

        public string Extension { get; }

        public string NameWithOutExtension { get; }

        public string Path { get; }

        public string FolderPath { get; }

        public bool Transform { get; set; }

        public bool? Success { get; set; }
    }
}