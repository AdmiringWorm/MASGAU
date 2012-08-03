﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Text.RegularExpressions;
using System.IO;
using MASGAU.Location;
using MASGAU.Location.Holders;
using GameSaveInfo;
namespace MASGAU {
    public class CustomGameVersion: GameVersion {
        public CustomGameVersion(GameSaveInfo.Game parent, DirectoryInfo location, string saves, string ignores): base(parent, "Windows", "Custom") {

            DetectedLocations locs = Core.locations.interpretPath(location.FullName);
            DetectedLocationPathHolder loc = locs.getMostAccurateLocation();

            if (loc.EV == EnvironmentVariable.VirtualStore) {
                string drive = Path.GetPathRoot(loc.full_dir_path);
                string new_path = Path.Combine(drive, loc.Path);
                loc = Core.locations.interpretPath(new_path).getMostAccurateLocation();
            }

            switch (loc.EV) {
                case EnvironmentVariable.ProgramFiles:
                case EnvironmentVariable.ProgramFilesX86:
                case EnvironmentVariable.Drive:
                    loc.EV = EnvironmentVariable.InstallLocation;
                    break;
            }

            this.Locations.Paths.Add(loc);


            FileType type = this.addFileType("Custom");

            SaveFile save = type.addSave(saves, null);
            if (ignores != null && ignores != "") {
                ExceptFile except = save.addException(ignores, null);
                save.Excepts.Add(except);
            }
            type.Add(save);
            this.FileTypes.Add("Custom",type);

            if (Core.settings.EmailSender != null)
                this.Contributors.Add(Core.settings.EmailSender);
            else
                this.Contributors.Add("Anonymous");

        }


        public CustomGameVersion(GameSaveInfo.Game parent, XmlElement element): base(parent,element) {

        }

    }

}
