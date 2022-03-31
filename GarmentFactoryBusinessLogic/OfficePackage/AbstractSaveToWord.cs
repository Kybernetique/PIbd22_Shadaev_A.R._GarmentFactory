using GarmentFactoryBusinessLogic.OfficePackage.HelperEnums;
using GarmentFactoryBusinessLogic.OfficePackage.HelperModels;
using System.Collections.Generic;

namespace GarmentFactoryBusinessLogic.OfficePackage
{
    public abstract class AbstractSaveToWord
    {
        public void CreateDoc(WordInfo info)
        {
            CreateWord(info);
            CreateParagraph(new WordParagraph
            {
                Texts = new List<(string, WordTextProperties)> { (info.Title, new
WordTextProperties { Bold = true, Size = "24", }) },
                TextProperties = new WordTextProperties
                {
                    Size = "24",
                    JustificationType = WordJustificationType.Center
                }
            });
            foreach (var textile in info.Textiles)
            {
                CreateParagraph(new WordParagraph
                {
                    Texts = new List<(string, WordTextProperties)> {
(textile.TextileName, new WordTextProperties { Size = "24", }) },
                    TextProperties = new WordTextProperties
                    {
                        Size = "24",
                        JustificationType = WordJustificationType.Both
                    }
                });
            }
            SaveWord(info);
        }

        // Создание doc-файла
        protected abstract void CreateWord(WordInfo info);

        // Создание абзаца с текстом
        protected abstract void CreateParagraph(WordParagraph paragraph);

        // Сохранение файла
        protected abstract void SaveWord(WordInfo info);
    }
}
