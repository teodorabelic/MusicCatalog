using MusicCatalog.Model;
using MusicCatalog.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatalog.Service
{
    internal class MusicEditorService
    {
        private MusicEditorRepository musicEditorRepository;

        public MusicEditorService()
        {
            musicEditorRepository = MusicEditorRepository.GetInstance();
        }

        public List<MusicEditor> GetAllMusicEditors()
        {
            return musicEditorRepository.GetAll();
        }

        public MusicEditor GetMusicEditorById(int id)
        {
            return musicEditorRepository.GetById(id);
        }

        public void CreateMusicEditor(MusicEditor editor)
        {
            musicEditorRepository.Create(editor);
        }

        public void UpdateMusicEditor(MusicEditor editor)
        {
            musicEditorRepository.Update(editor);
        }

        public void DeleteMusicEditor(int id)
        {
            musicEditorRepository.Delete(id);
        }
    }
}
