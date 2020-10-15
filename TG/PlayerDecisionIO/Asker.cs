using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
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

        public static T Ask<T>(Label questionLabel, IEnumerable<T> options, bool canCancel = false) where T : IAskerOption
        {
            var f = new AskerForm<T>(questionLabel, options, canCancel);
            f.ShowDialog();
            return f.PickedAskerOptions.FirstOrDefault();
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