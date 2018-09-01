using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JamesFrowen.PackageUpdater.GUI
{
    public abstract class NamedFolderListGUI<T> where T : NamedFolder, new()
    {
        protected abstract string VisableName { get; }
        protected virtual void extraItemSetup(ListViewItem item) { }

        private NamedFolderList<T> list;
        private ListView view;

        public NamedFolderListGUI(NamedFolderList<T> namedFolderList, ListView view)
        {
            this.list = namedFolderList;
            this.view = view;
        }

        public void RefreshListView()
        {
            RefreshListView(this.view);
        }
        public void RefreshListView(ListView view)
        {
            view.Items.Clear();
            var range = this.CreateListViewItems();
            view.Items.AddRange(range);
        }
        public ListViewItem[] CreateListViewItems()
        {
            return this.list.Select(x =>
            {
                var item = new ListViewItem(x.Value.Name);
                item.SubItems.Add(x.Value.Path);
                extraItemSetup(item);

                return item;
            }).ToArray();
        }


        public void CheckAndRemoveSelected()
        {
            this.CheckAndRemoveSelected(this.view);
        }
        public void CheckAndRemoveSelected(ListView view)
        {
            var selected = view.SelectedItems;

            var str = new StringBuilder();
            str.AppendFormat("Are you sure you want to delete {0}?\n", this.VisableName);
            var names = new List<string>();
            for (int i = 0; i < selected.Count; i++)
            {
                if (i != 0) { str.Append(", "); }
                names.Add(selected[i].Text);
                str.Append(selected[i].Text);
            }

            if (MessageBox.Show(str.ToString(), "Are you Sure?", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.RemoveMatches(names);
                this.RefreshListView(view);
            }
        }
        public void RemoveMatches(List<string> names)
        {
            foreach (var name in names)
            {
                this.removeItem(name);
            }
        }
        private void removeItem(string name)
        {
            this.list.Remove(name);
        }

        public void CheckAndAddItem()
        {
            var createForm = new CreateNamedFolderForm();
            createForm.CreateNamedFolder((name, path) =>
            {
                var item = new T { Name = name, Path = path };
                this.list.Add(name, item);
                this.RefreshListView();

                createForm.Close();
                createForm.Dispose();
            });
        }
    }
}
