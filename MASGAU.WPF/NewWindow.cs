﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media.Animation;
using System.Windows.Controls;
using System.Reflection;
using Communication.WPF;
namespace MASGAU {
    public class NewWindow: ACommunicationWindow {

        public NewWindow() {

        }

        protected bool toggleMinimize() {
            if (this.WindowState == System.Windows.WindowState.Minimized) {
                this.WindowState = System.Windows.WindowState.Normal;
                return false;
            } else {
                this.WindowState = System.Windows.WindowState.Minimized;
                return true;
            }
        }



        protected string getPath(Environment.SpecialFolder root, string description, string path) {

            System.Windows.Forms.FolderBrowserDialog pathBrowser = new System.Windows.Forms.FolderBrowserDialog();
            if(path!=null)
                pathBrowser.SelectedPath = path;

            if (root == null)
                pathBrowser.RootFolder = Environment.SpecialFolder.MyComputer;
            else
                pathBrowser.RootFolder = root;

            if (description != null)
                pathBrowser.Description = description;

            if (pathBrowser.ShowDialog(WPFHelpers.GetIWin32Window(this)) != System.Windows.Forms.DialogResult.Cancel) {
                return pathBrowser.SelectedPath;
            } else {
                return null;
            }
        }



        public bool changeSyncPath() {
            string old_path = Core.settings.sync_path;
            string new_path = null;
            System.Windows.Forms.FolderBrowserDialog folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            folderBrowser.ShowNewFolderButton = true;
            folderBrowser.Description = "Choose where the saves will be synced.";
            folderBrowser.SelectedPath = old_path;
            bool try_again = false;
            do {
                if (folderBrowser.ShowDialog(this.GetIWin32Window()) == System.Windows.Forms.DialogResult.OK) {
                    new_path = folderBrowser.SelectedPath;
                    if (PermissionsHelper.isReadable(new_path)) {
                        if (PermissionsHelper.isWritable(new_path)) {
                            Core.settings.sync_path = new_path;
                            if (new_path != old_path)
                                Core.rebuild_sync = true;
                            return new_path != old_path;
                        } else {
                            this.displayError("Config File Error", "You don't have permission to write to the selected sync folder:" + Environment.NewLine + new_path);
                            try_again = true;
                        }
                    } else {
                        this.displayError("Config File Error", "You don't have permission to read from the selected sync folder:" + Environment.NewLine + new_path);
                        try_again = true;
                    }
                } else {
                    try_again = false;
                }
            } while (try_again);
            return false;
        }
    }
}
