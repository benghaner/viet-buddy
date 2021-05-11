using System;

namespace VietBuddy.Web.Shared
{
    public class AppState
    {
        public event Action WordListChanged;
        public void NotifyWordListChanged() => WordListChanged?.Invoke();
    }
}