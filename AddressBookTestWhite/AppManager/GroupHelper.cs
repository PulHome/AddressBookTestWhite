using System.Collections.Generic;
using System.Linq;

using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems.TreeItems;
using System.Windows.Automation;
using TestStack.White.InputDevices;
using TestStack.White.WindowsAPI;
using System;

namespace AddressBookTestWhite
{
    public class GroupHelper : HelperBase
    {
        public static string GROUP_WIN_TITLE = "Group editor";
        public GroupHelper(ApplicationManager appMan) : base(appMan) { }
        public List<GroupData> GetGroupList()
        {
            List<GroupData> list = new List<GroupData>();
            Window dialogGroups = OpenGroupsDialog();
            Tree tree = dialogGroups.Get<Tree>("uxAddressTreeView");
            TreeNode root = tree.Nodes[0];
            foreach (var nodeItem in root.Nodes)
            {
                list.Add(new GroupData()
                {
                    Name = nodeItem.Text
                });
            }
            CloseGroupsDialog(dialogGroups);
            return list;
        }

        public void Remove(GroupData toBeRemoved)
        {
            Window dialog = OpenGroupsDialog();
            //Select a group to remove
            Tree tree = dialog.Get<Tree>("uxAddressTreeView");
            TreeNode root = tree.Nodes[0];
            foreach (var nodeItem in root.Nodes)
            {
                if (nodeItem.Text == toBeRemoved.Name)
                {
                    nodeItem.Select();
                }

            }
            dialog.Get<Button>("uxDeleteAddressButton").Click();
            Window confirmRemoval = dialog.ModalWindow("Delete group");
            confirmRemoval.Get<Button>("uxOKAddressButton").Click();
            CloseGroupsDialog(dialog);
        }

        public void Add(GroupData newGroup)
        {
            Window dialog = OpenGroupsDialog();
            dialog.Get<Button>("uxNewAddressButton").Click();
            TextBox textBox = (TextBox)dialog.Get(SearchCriteria.ByControlType(ControlType.Edit));
            textBox.Enter(newGroup.Name);
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
            CloseGroupsDialog(dialog);
        }


        private Window OpenGroupsDialog()
        {
            //проверка, что окно уже не открыто
            if (!manager.MainWindow.ModalWindows().Select(wind => wind.Title).Contains(GROUP_WIN_TITLE))
            {
                manager.MainWindow.Get<Button>("groupButton").Click();
            }

            return manager.MainWindow.ModalWindow(GROUP_WIN_TITLE);
        }
        private void CloseGroupsDialog(Window dialog)
        {
            dialog.Get<Button>("uxCloseAddressButton").Click();
        }

    }
}
