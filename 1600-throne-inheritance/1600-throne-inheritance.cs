public class ThroneInheritance {
    /*

    dictionary, string name -> Person class
        - bool is_alive
        - list of successors

    */
    public class Person {
        public bool is_alive;
        public List<string> successors;
    }
    string king_name;
    Dictionary<string, Person> kingdom = new Dictionary<string, Person>();
    public ThroneInheritance(string kingName) {
        // intitialize king person, add it to the map
        Person king = new Person();
        king.is_alive = true;
        king.successors = new List<string>();
        kingdom.Add(kingName, king);
        king_name = kingName;
    }
    
    public void Birth(string parentName, string childName) {
        // intialize child person, add it to the map and add it to the parent's list of sucessors
        Person child = new Person();
        child.is_alive = true;
        child.successors = new List<string>();
        kingdom.Add(childName, child);
        kingdom[parentName].successors.Add(childName);
    }
    
    public void Death(string name) {
        // mark as dead with bool
        kingdom[name].is_alive = false;
    }

    public void DFS(string name, List<string> cur0rder) {
        foreach (string child in kingdom[name].successors) {
            if (kingdom[child].is_alive) {
                cur0rder.Add(child);
            }
            DFS(child, cur0rder);
        }
    }
    
    public IList<string> GetInheritanceOrder() {
        // preorder traversal, dfs
        // recursively, calling each successor of a parent
        List<string> cur0rder = new List<string>();
        if (kingdom[king_name].is_alive) {
            cur0rder.Add(king_name);
        }
        DFS(king_name, cur0rder);
        return cur0rder;
    }
}

/**
 * Your ThroneInheritance object will be instantiated and called as such:
 * ThroneInheritance obj = new ThroneInheritance(kingName);
 * obj.Birth(parentName,childName);
 * obj.Death(name);
 * IList<string> param_3 = obj.GetInheritanceOrder();
 */