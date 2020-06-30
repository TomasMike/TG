using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TG.Forms;

namespace TG
{
    public static class Asker
    {
        public static IAskerOption Ask(IEnumerable<IAskerOption> options, bool canCancel)
        {
            var f = new AskerForm(options);
            f.ShowDialog();
        }

        public static AskerPlayerOption PickOnePlayer(bool canCancel)
        {
            var options = new List<Option<AskerPlayerOption>>();

            for (int i = 0; i < SaveManager.CurrentSaveSheet.Players.Count; i++)
            {
                options.Add(new Option<AskerPlayerOption>((AskerPlayerOption)i));
            }

            return Ask(options, canCancel).option;
        }


    }

    public enum AskerPlayerOption
    {
        Player1,
        Player2,
        Player3,
        Player4
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



    public interface IAskerOption
    {
        string GetOptionDescription();
    }

    public class Option<T> : IAskerOption
    {
        public Option(T item)
        {
            option = item;
        }

        public T option;
        public string TextDescription;
        public string GetOptionDescription()
        {
            return typeof(T).IsEnum ? option.ToString() : TextDescription;
        }
    }

}
