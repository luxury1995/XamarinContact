using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ContactApp.ViewModels.Extension
{
    public class Grouping<TK, T> : ObservableCollection<T>
    {
        public TK Key { get; private set; }

        public Grouping(TK key, IEnumerable<T> items)
        {
            Key = key;
            foreach (var item in items)
                Items.Add(item);
        }

        public Grouping()
        {
        }
    }
}
