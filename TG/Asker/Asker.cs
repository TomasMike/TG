using System.Collections.Generic;

namespace TG
{
    public static class Asker
    {
      

        
    }

    public static class OldAsker
    {
        public static string AskText(string question)
        {
            var q = new QuestionForm(question);
            q.ShowDialog();
            return q.stringOutput;
        }

        public static int AskInt(string question)
        {
            var q = new QuestionForm(question);
            q.Mode = QuestionType.Int;
            q.ShowDialog();
            return q.intOutput;
        }

        public static string AskOneFromDropdown(string question, IEnumerable<QuestionFromComboBoxItem> items)
        {
            var q = new QuestionForm(question, items);
            q.Show();
            return q.stringOutput;
        }
    }
}
