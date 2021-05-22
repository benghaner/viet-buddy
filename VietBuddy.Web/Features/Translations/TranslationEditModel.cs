using System.Text.Json;

namespace VietBuddy.Web.Features.Translations
{
    public class TranslationEditModel
    {
        public Translation Translation { get; set; }
        public bool IsNew { get => Translation.Id == null; }

        public TranslationEditModel()
        {
            Translation = new Translation();
        }

        public TranslationEditModel(Translation translation)
        {
            string json = JsonSerializer.Serialize<Translation>(translation);
            Translation = JsonSerializer.Deserialize<Translation>(json);
        }
    }
}