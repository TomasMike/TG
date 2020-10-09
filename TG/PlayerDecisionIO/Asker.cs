using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TG.CoreStuff;
using TG.Enums;
using TG.Forms;
using TG.SavingLoading;

namespace TG.PlayerDecisionIO
{
    public static class Asker
    {
        public static T Ask<T>(string question, IEnumerable<T> options, bool canCancel = false) where T : IAskerOption
        {
            var f = new AskerForm<T>(question, options, canCancel);
            f.ShowDialog();
            return f.PickedAskerOptions.FirstOrDefault();
        }
      

        public static T Ask<T>(string question,Dictionary<int,T> options, bool canCancel)
        {
            var optionsList = new List<Option<T>>();

            foreach (var item in options)
            {
                //optionsList.Add(new Option<T> { });
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

    public interface IAskerOption
    {
        string GetOptionDescription();
    }

    public class Option<T> : IAskerOption
    {
        public Option(T item)
        {
            InnerOption = item;
        }

        public T InnerOption;
        public string TextDescription;

        public string GetOptionDescription()
        {
            return typeof(T).IsEnum ? InnerOption.ToString() : TextDescription;
        }
    }
}