public class ThroneInheritance {
    public class Person {
        public string name;
        public bool alive;
        public List<string> successors;
    }
    public Dictionary<string, Person> kingdom = new Dictionary<string, Person>();
    public string king_name;
    public ThroneInheritance(string kingName) {
        Person king = new Person();
        king.name = kingName;
        king.successors = new List<string>();
        king.alive = true;
        kingdom.Add(kingName, king);
        king_name = kingName;
    }
    
    public void Birth(string parentName, string childName) {
        Person child = new Person();
        child.name = childName;
        child.alive = true;
        child.successors = new List<string>();
        kingdom[parentName].successors.Add(childName);
        kingdom.Add(childName, child);
    }
    
    public void Death(string name) {
        kingdom[name].alive = false;
    }
    
    public void DFS(string person, IList<string> cur0rder) {
        if (kingdom[person].alive) {
            cur0rder.Add(person);
        }
        foreach (string child in kingdom[person].successors) {
            DFS(child, cur0rder);
        }
    }
    public IList<string> GetInheritanceOrder() {
        IList<string> cur0rder = new List<string>();
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