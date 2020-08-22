using System;
using System.Collections.Generic;
using System.Linq;
using TG.Enums;
using TG.Forms;
using TG.SavingLoading;

namespace TG.PlayerDecisionIO
{
    public static class Asker
    {
        public static IAskerOption<T> Ask<T>(string question, IEnumerable<IAskerOption<T>> options, bool canCancel)
        {
            var f = new AskerForm<T>(question, options, canCancel);
            f.ShowDialog();
            return f.PickedAskerOptions.FirstOrDefault();
        }

        public static PlayerNumber PickOnePlayer(string question, bool canCancel)
        {
            var options = new List<Option<PlayerNumber>>();

            for (int i = 0; i < SaveManager.CurrentSaveSheet.Players.Count; i++)
            {
                options.Add(new Option<PlayerNumber>((PlayerNumber)i));
            }

            return Ask(question, options, canCancel).GetOptionObject();
        }

        public static T Ask<T>(string question,Dictionary<int,T> options, bool canCancel)
        {
            var optionsList = new List<Option<T>>();

            foreach (var item in options)
            {
                optionsList.Add(new Option<T> { });
            }
            
            throw new NotImplementedException();
        }
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

    public interface IAskerOption<T>
    {
        string GetOptionDescription();

        T GetOptionObject();
    }

    public class Option<T> : IAskerOption<T>
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

        public T GetOptionObject()
        {
            return option;
        }
    }
}