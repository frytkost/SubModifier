using System.Collections.Generic;
using System.Threading.Tasks;
using SubModifier.Entities;
using SubModifier.Interfaces;
using SubModifier.Services;
using Unity;

namespace SubModifier.BusinessLogic
{
    internal class SubtitleManager
    {
        private ISubManager _manager;
        private readonly IUnityContainer _unityContainer;

        public SubtitleManager()
        {
            _unityContainer = BuildContainer();
        }

        public void TransformSubtitle(Subtitle subtitle)
        {
            string containerName = subtitle.Extension.Remove(0, 1);
            _manager = _unityContainer.Resolve<ISubManager>(containerName.ToUpper());
            _manager.TransformSubtitle(subtitle);
        }

        public void TransformSubtitles(List<Subtitle> subtitles)
        {
            Parallel.ForEach(subtitles, TransformSubtitle);
        }

        public static IUnityContainer BuildContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<ISubManager, TtmlSubtitleManager>("TTML");
            currentContainer.RegisterType<ISubManager, VttSubtitleManager>("VTT");
            return currentContainer;
        }
    }
}