public class FileSystem {
    Dictionary<string, Path> file_system = new Dictionary<string, Path>();
    public class Path {
        public bool is_file_path;
        public List<string> directories;
        public string content;
    }
    public FileSystem() {
        Path path = new Path();
        path.is_file_path = false;
        path.directories = new List<string>();
        path.content = "";
        file_system.Add("/", path);
    }
    
    public IList<string> Ls(string path) {
        if (file_system[path].is_file_path) {
            string[] pathes = path.Split('/');
            return [pathes[pathes.Length - 1]];
        }
        file_system[path].directories.Sort(StringComparer.Ordinal);
        return file_system[path].directories;
    }
    
    public void Mkdir(string path) {
        string[] pathes = path.Split('/');
        string curr_str = "";
        string prev_str = "/";
        for (int i = 1; i < pathes.Length; ++i) {
            if (i > 1) {
                prev_str = curr_str;
            }
            curr_str += "/" + pathes[i];
            if (!file_system.ContainsKey(curr_str)) {
                file_system[prev_str].directories.Add(pathes[i]);
                Path new_path = new Path();
                new_path.is_file_path = false;
                new_path.directories = new List<string>();
                new_path.content = "";
                file_system.Add(curr_str, new_path);
            }
        }
    }
    
    public void AddContentToFile(string filePath, string content) {
        if (!file_system.ContainsKey(filePath)) {
            string[] pathes = filePath.Split('/');
            string curr_str = "";
            string prev_str = "/";
            for (int i = 1; i < pathes.Length; ++i) {
                if (i > 1) {
                    prev_str = curr_str;
                }
                curr_str += "/" + pathes[i];
                if (!file_system.ContainsKey(curr_str)) {
                    file_system[prev_str].directories.Add(pathes[i]);
                    Path new_path = new Path();
                    new_path.is_file_path = false;
                    new_path.directories = new List<string>();
                    new_path.content = "";
                    file_system.Add(curr_str, new_path);
                }
            }
            file_system[filePath].is_file_path = true;
            file_system[filePath].content = content;
        }
        else {
            file_system[filePath].is_file_path = true;
            file_system[filePath].content += content;
        }
    }
    
    public string ReadContentFromFile(string filePath) {
        return file_system[filePath].content;
    }
}

/**
 * Your FileSystem object will be instantiated and called as such:
 * FileSystem obj = new FileSystem();
 * IList<string> param_1 = obj.Ls(path);
 * obj.Mkdir(path);
 * obj.AddContentToFile(filePath,content);
 * string param_4 = obj.ReadContentFromFile(filePath);
 */