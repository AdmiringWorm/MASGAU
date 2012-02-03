using System;
using System.Collections;

public struct file_holder {
    public string absolute_path, relative_path, file_name, owner, relative_root, absolute_root;
}

public struct backup_holder
{
    public string game_name, owner, file_name, file_date;
//    public GameData data;
}

public struct user_holder {
	public string name;
}

public struct root_holder {
    public string path, registry, shortcut, game, append_path, detract_path;
}

public struct playstation_id {
    public string prefix, suffix;
}

public struct monitor_file {
    public string root, path;
}

public struct monitor_dir {
	public string path, game;
}