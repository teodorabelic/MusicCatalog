using MusicCatalog.Model;
using MusicCatalog.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatalog.Controller
{
    internal class MusicEditorController
    {
        private MusicEditorService musicEditorService;

        public MusicEditorController()
        {
            musicEditorService = new MusicEditorService();
        }

        public List<MusicEditor> GetAllMusicEditors()
        {
            return musicEditorService.GetAllMusicEditors();
        }

        public MusicEditor GetMusicEditorById(int id)
        {
            return musicEditorService.GetMusicEditorById(id);
        }

        public void CreateMusicEditor(MusicEditor editor)
        {
            musicEditorService.CreateMusicEditor(editor);
        }

        public void UpdateMusicEditor(MusicEditor editor)
        {
            musicEditorService.UpdateMusicEditor(editor);
        }

        public void DeleteMusicEditor(int id)
        {
            musicEditorService.DeleteMusicEditor(id);
        }
    }
}
